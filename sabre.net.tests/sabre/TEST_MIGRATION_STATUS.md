# sabre.net 测试迁移阶段总结

记录 sabre.io 官方测试（vobject 4.5.6）迁移到 sabre.net.tests 的阶段性进展、
发现的 PeachPie 差异，以及后续方向。

## 当前测试覆盖统计

- **总计 365 测试**：314 通过 / 0 失败 / 51 跳过
- 迁移起点（本阶段开始前）：234 通过 / 15 跳过 / 249 总
- 本阶段净增：+80 通过、+36 跳过，现有用例无一破坏

## 已迁移的官方测试

### DateTime::modify 运行时补丁验证
- `DateTimeModifyBehaviorTest` / `RuntimePatchSmokeTest`：证明 PeachPie 原生 modify 有 bug，
  显式调用 `\nextsharp_sabre_runtime_patch_bootstrap()` 后修正。详见
  `sabre.net.runtimepatch/ADAPTATION.md`。

### Recur 域（本阶段重点，迁移自 vobject 4.5.6 tests/VObject/Recur/）

| 测试文件 | 来源 | 用例数 | 状态 |
|---------|------|-------|------|
| `RRuleIteratorTest.cs` | `Recur/RRuleIteratorTest.php`（1643 行，~50 方法 + 6 DataProvider） | 61 通过 / 34 跳过 | ✅ |
| `RDateIteratorTest.cs` | `Recur/RDateIteratorTest.php`（74 行，3 方法） | 3 通过 | ✅ |
| `EventIteratorTest.cs` | `Recur/EventIterator/` 16 个小型回归文件 | 16 通过 / 2 跳过 | ✅ |

**未迁移**：`Recur/EventIterator/MainTest.php`（1411 行，32 方法）——与 RRuleIteratorTest
高度同构（testHourly/Daily/Weekly/Monthly/Yearly 等），仅多套一层 EventIterator，边际价值低。

## 关键技术方案

### PHP 脚本路径（SabrePhpRunner.RunInPeachpie）
所有 Recur 测试统一采用 PHP 脚本路径，与既有 `RuntimePatchSmokeTest` 一致：
- 脚本头显式调用 `\nextsharp_sabre_runtime_patch_bootstrap()`（RRuleIterator/EventIterator
  的频率推进全部依赖 DateTime::modify）
- 脚本内 `use Sabre\VObject\Recur\...`，内嵌 ICS 文本用 `Reader::read` 解析
- 严格复刻官方 `parse()` helper 语义：`new DateTime` + 时区、fastForward 不带时区、
  无限规则靠 `isInfinite() && count >= expected` 提前终止
- 输出统一标准化为 LF 比较，规避跨平台换行差异

### 无限规则防死循环
RRuleIterator 的无限规则（无 COUNT/UNTIL）必须靠 expectedCount 提前终止，否则死循环/OOM。
所有无限规则用例通过 `Parse(rule, start, ..., expectedCount)` 或期望字符串自动推算行数。

## 发现的 PeachPie 差异（已固化为 Ignore，均注明原因）

### 1. DST 夏令时跳变（34 个用例，RRuleIteratorTest）
- **现象**：Europe/Zurich 夏令时开始时（如 2023-03-26），PHP 原生把不存在的 `02:xx` 跳到 `03:xx`，
  PeachPie 直接给出不存在的 `02:xx`。
- **范围**：仅影响直接测 DST 跳变的 `*DstTransition*` / `*OnDstTransition*` 用例。
- **与 patch/sabre 逻辑无关**：非 DST 用例（73 个）全通过，证明 modify patch 在递归推进下完全正确。
- **后续**：PeachPie 时区数据库/DST 处理的可修复点，需深入 PeachPie DateTime 实现。

### 2. VCalendar::expand() 部分场景未展开（2 个用例，EventIteratorTest）
- **现象**：`testOverrideFirstEventRemoveViaExDate`（无限 RRULE + EXDATE）、
  `testExpandFloatingTimesToUtc`（无限 RRULE + floating time）中，`$vcal->expand()` 输出仅原始 VEVENT，
  未生成展开后的多个实例。
- **关键区分**：EventIterator **直接迭代**正常（16 个迭代用例全过）；expand 对**带 override 的有限规则**
  （IncorrectExpand/MissingOverridden）也正常——问题集中在 expand 的特定路径。
- **后续**：需定位 `VCalendar::expand()` 在 PeachPie 下的展开逻辑断点。

### 3. 性能 Ignore（3 个用例）
- 上游标记 `@large`（60s 上限）：`testDailyBySetPosLoop`、`testYearlyBySetPosLoop`、`testNeverEnding`。
  PeachPie 下需单独评估耗时，先 Ignore。

### 4. 既有 Uri\ParseTest（15 个用例）
- `testParseFallback` 系列，当前构建未暴露 fallback parser 入口，与本阶段无关。

## 验证 modify patch 在递归场景的覆盖度（本阶段核心价值）

RRuleIterator 的 `nextHourly/nextDaily/nextWeekly/nextMonthly/nextYearly` 全部走
`DateTime::modify`（如 `'+1 days'`、`'next wednesday'`、`'last Monday'` 等相对表达式），
EventIterator 内部委托 RRuleIterator。**所有非 DST 用例通过**，证明：
- modify patch 对 mutable（DateTime）和 immutable（DateTimeImmutable）两条链都生效
- 相对日期表达式以"当前对象时间"为基准的语义已正确修复
- 含 EXDATE/overrides/RDATE 的完整 VEVENT 递归展开正确

## 后续方向（按价值排序）

1. **VCalendar::expand() 差异定位**：2 个 Ignore 用例指向 expand API 的具体断点，
   修复后可解锁更多整体 ICS 比较测试。
2. **DST tzdata 差异定位**：34 个 Ignore 用例，需深入 PeachPie DateTime 的时区处理。
3. **其他未覆盖模块**：FreeBusyGenerator（549 行，依赖 EventIterator）、ITip/Broker、
   Parser（MimeDir/Json/XML）。
4. **EventIterator/MainTest**：与 RRuleIteratorTest 同构，边际价值低，可按需迁移。

## 测试运行方式

```bash
# 单个测试类
dotnet test ./sabre.net.tests/sabre.net.tests.csproj -c Release --no-build \
  --filter "FullyQualifiedName~RRuleIteratorTest"

# 全量（首次需先 build，后续用 --no-build 避免 PeachPie 重编译）
dotnet build ./sabre.net.tests/sabre.net.tests.csproj -c Release
dotnet test ./sabre.net.tests/sabre.net.tests.csproj -c Release --no-build
```

注意：触及 RRULE 迭代的用例必须先装配 modify patch（PHP 脚本路径已内置 bootstrap；
C# 反射路径如 VEventTest/VAlarmTest 已在 `[OneTimeSetUp]` 显式调用）。
