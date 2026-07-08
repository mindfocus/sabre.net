# sabre.net.runtimepatch 适配说明

本程序集通过 [Harmony](https://github.com/pardeike/Harmony) 对 PeachPie 的
`DateTime::modify` / `DateTimeImmutable::modify` 做运行时补丁，**不修改 PeachPie 源码，
也不修改上游 sabre/vobject 业务逻辑**。

## 背景（为什么需要这个补丁）

PeachPie 当前 `DateTime::modify($modifier)` 的实现把相对日期表达式按“现在”解析，
而 PHP 语义应以**当前对象时间**为基准。这会导致 sabre 的递归/迭代逻辑产生偏差：

- `RRuleIterator` 周期推进时，`modify('+1 week')` 等相对表达式参考点错乱，
  曾导致从 `2013-04` 直接跳到 `2026-07`，进而引发 `EventIterator` 死循环。
- 全天事件（`VALUE=DATE`）的 `modify('+1 day')` 计算 `effectiveEnd` 时也偏移。

实测影响：`VEventTest.testInTimeRange_AllDay`、
`VEventTest.testInTimeRange_NoInstancesAfterExDate` 在未打补丁时会失败或挂死。

## 补丁内容

- 前置（Prefix）拦截 `Pchp.Library.DateTime.DateTime.modify` 与
  `DateTimeImmutable.modify`。
- 读取实例当前的 `DateTimeValue`（`LocalTime` + `LocalTimeZone`），
  调用内部 `DateInfo.Parse(modifier, currentLocalTime, ...)` 以**当前对象时间为基准**
  重新解析，构造新的 `DateTimeValue` 写回。
- 解析失败时回退到 PeachPie 原实现（`return true`），保证向后兼容。

## 调用约定（重要）

补丁**不会自动装配**。曾经尝试过 `[ModuleInitializer]` 自动装配，但加载时机不可靠
（程序集被引用不代表模块初始化器一定在第一次 `modify` 调用前执行），已放弃该思路。

**当前阶段约定：在使用任何受影响的 sabre.net 能力前，必须显式触发装配。**
按宿主类型分两种入口：

### 1. PHP 宿主 / PeachPie 脚本路径

在脚本入口（或框架引导）尽早调用：

```php
\nextsharp_sabre_runtime_patch_bootstrap();
```

返回 `true` 表示补丁已装配。该函数幂等，多次调用安全。

适用场景：通过 PeachPie 执行的 PHP 代码、`RuntimePatchSmokeTest` 这类以 PHP
脚本方式验证补丁的测试。

### 2. C# 宿主 / 纯反射调用路径

直接调用 `RuntimePatchBootstrap.nextsharp_sabre_runtime_patch_bootstrap()`，
或等价的 `DateTimeModifyPatch.EnsureApplied()`（后者为 `internal`，仅同程序集/友元可见）：

```csharp
using Nextsharp.Sabre.RuntimePatch;

RuntimePatchBootstrap.nextsharp_sabre_runtime_patch_bootstrap();
```

适用场景：测试项目里以 C# 反射直接驱动 sabre 组件的用例（如 `VEventTest`、
`VAlarmTest`）。这类测试**不经过 PHP 脚本路径**，PHP 可见的
`\nextsharp_sabre_runtime_patch_bootstrap()` 不会自然触发，必须由 C# 侧显式装配。

推荐放在 NUnit 的 `[OneTimeSetUp]` 中，确保测试类加载时即完成装配：

```csharp
[OneTimeSetUp]
public void EnsureRuntimePatchApplied()
{
    RuntimePatchBootstrap.nextsharp_sabre_runtime_patch_bootstrap();
}
```

## 哪些入口在运行前必须先完成补丁初始化

凡是会进入以下 sabre 调用链的入口，都必须先完成补丁装配，否则存在结果偏差或
死循环风险：

| 受影响的 sabre 入口 | 触发的相对日期路径 | 风险 |
|--------------------|-------------------|------|
| `VEvent::isInTimeRange()` | 全天事件 `effectiveEnd` 经 `modify('+1 day')` | 结果偏差 |
| `VEvent::isInTimeRange()` 含 `RRULE` | `RRuleIterator::next()` 周期推进 `modify(...)` | **死循环** |
| `VEvent::isInTimeRange()` 含 `EXDATE` | 同上 + 排除实例比较 | **死循环** |
| `VAlarm::isInTimeRange()` 含相对 `TRIGGER`（如 `-P1D` / `-PT10M`） | 触发时间相对 `DUE`/`DTEND` 计算 | 结果偏差 |
| 任何调用 `Sabre\VObject\Recur\EventIterator` / `RRuleIterator` 的代码 | 周期推进 | **死循环** |

> 判断准则：只要代码路径可能调用 `DateTime::modify(<相对表达式>)`，
> 就必须先装配补丁。纯解析 / 读写 / 序列化的入口（Reader、Writer、Property、
> Parameter、DateTimeParser 等）不依赖 `modify`，无需前置装配。

## 幂等性与线程安全

- `DateTimeModifyPatch.EnsureApplied()` 内部用锁 + `_applied` 标志保证幂等，
  重复调用安全。
- Harmony 补丁本身是进程级、一次装配长期生效。

## 测试验证现状

- `RuntimePatchSmokeTest` / `DateTimeModifyBehaviorTest`：验证 PHP 路径下补丁生效。
- `VEventTest` / `VAlarmTest`：C# 反射路径，已在 `[OneTimeSetUp]` 装配补丁，
  含 `AllDay`、`NoInstancesAfterExDate` 等原死循环用例，现已全部通过。
- 全量 `sabre.net.tests`：234 通过 / 15 跳过 / 0 失败（跳过均为 `Uri\ParseTest`
  中 `testParseFallback` 系列，因当前构建未暴露 fallback parser 入口而显式 `[Ignore]`，
  与本补丁无关）。

## 依赖

- `Lib.Harmony` 2.x
- `Peachpie.Library` / `Peachpie.Runtime` 1.1.13（被补丁目标所在程序集）
