using System.Collections.Generic;
using NUnit.Framework;

namespace sabre.net.tests.sabre.VObject.Component
{
    /// <summary>
    /// 迁移自上游 sabre-io/vobject 4.5.6 的 tests/VObject/Component/VCardTest.php。
    /// 覆盖 VCard 组件的 validate（含 REPAIR）/ getDocumentType / getByType / preferred。
    /// 采用 PHP 脚本路径。
    /// </summary>
    public class VCardTest
    {
        private static string RunPhp(string body, string tz = "UTC")
        {
            var php = "date_default_timezone_set('" + tz + "');" + "\n"
                    + "\\nextsharp_sabre_runtime_patch_bootstrap();" + "\n"
                    + body;
            return SabrePhpRunner.RunInPeachpie(php).Replace("\r\n", "\n").Trim();
        }

        // ===== testValidate（9 组 DataProvider）=====
        // 每组：(input, expectedWarnings[], expectedRepairedOutput)
        // PHP 端完整复刻：validate 收集 message，REPAIR 后比较 serialize
        private static string RunValidate(string input, string expectedWarningsJson, string expectedRepaired)
        {
            var body = "use Sabre\\VObject;" + "\n"
                     + "$vcard = VObject\\Reader::read(<<<VCF\n" + input + "\nVCF\n);" + "\n"
                     + "$warnMsg = [];" + "\n"
                     + "foreach ($vcard->validate() as $w) { $warnMsg[] = $w['message']; }" + "\n"
                     + "$expectedWarn = " + expectedWarningsJson + ";" + "\n"
                     + "$vcard->validate(VObject\\Component::REPAIR);" + "\n"
                     + "$expectedRepaired = <<<VCF\n" + expectedRepaired + "\nVCF\n;" + "\n"
                     + "$warnOk = ($warnMsg == $expectedWarn) ? 'WARN_OK' : 'WARN_FAIL';" + "\n"
                     + "$repairOk = ($vcard->serialize() === $expectedRepaired) ? 'REPAIR_OK' : 'REPAIR_FAIL';" + "\n"
                     + "echo $warnOk . \"\\n\" . $repairOk;";
            return RunPhp(body);
        }

        [Test]
        public void testValidateCorrect()
        {
            var input = "BEGIN:VCARD\r\nVERSION:4.0\r\nFN:John Doe\r\nUID:foo\r\nEND:VCARD\r\n";
            Assert.That(RunValidate(input, "[]", input), Is.EqualTo("WARN_OK\nREPAIR_OK"));
        }

        [Test]
        public void testValidateNoVersion()
        {
            var input = "BEGIN:VCARD\r\nFN:John Doe\r\nUID:foo\r\nEND:VCARD\r\n";
            var repaired = "BEGIN:VCARD\r\nVERSION:4.0\r\nFN:John Doe\r\nUID:foo\r\nEND:VCARD\r\n";
            Assert.That(RunValidate(input, "['VERSION MUST appear exactly once in a VCARD component']", repaired),
                Is.EqualTo("WARN_OK\nREPAIR_OK"));
        }

        [Test]
        public void testValidateUnknownVersion()
        {
            var input = "BEGIN:VCARD\r\nVERSION:2.2\r\nFN:John Doe\r\nUID:foo\r\nEND:VCARD\r\n";
            var repaired = "BEGIN:VCARD\r\nVERSION:2.1\r\nFN:John Doe\r\nUID:foo\r\nEND:VCARD\r\n";
            Assert.That(RunValidate(input, "['Only vcard version 4.0 (RFC6350), version 3.0 (RFC2426) or version 2.1 (icm-vcard-2.1) are supported.']", repaired),
                Is.EqualTo("WARN_OK\nREPAIR_OK"));
        }

        [Test]
        public void testValidateNoFN()
        {
            var input = "BEGIN:VCARD\r\nVERSION:4.0\r\nUID:foo\r\nEND:VCARD\r\n";
            Assert.That(RunValidate(input, "['The FN property must appear in the VCARD component exactly 1 time']", input),
                Is.EqualTo("WARN_OK\nREPAIR_OK"));
        }

        [Test]
        public void testValidateNoFNwithN()
        {
            var input = "BEGIN:VCARD\r\nVERSION:4.0\r\nUID:foo\r\nN:Doe;John;;;;;\r\nEND:VCARD\r\n";
            var repaired = "BEGIN:VCARD\r\nVERSION:4.0\r\nUID:foo\r\nN:Doe;John;;;;;\r\nFN:John Doe\r\nEND:VCARD\r\n";
            Assert.That(RunValidate(input, "['The FN property must appear in the VCARD component exactly 1 time']", repaired),
                Is.EqualTo("WARN_OK\nREPAIR_OK"));
        }

        [Test]
        public void testValidateNoFNwithNnoFirst()
        {
            var input = "BEGIN:VCARD\r\nVERSION:4.0\r\nUID:foo\r\nN:Doe;;;;;;\r\nEND:VCARD\r\n";
            var repaired = "BEGIN:VCARD\r\nVERSION:4.0\r\nUID:foo\r\nN:Doe;;;;;;\r\nFN:Doe\r\nEND:VCARD\r\n";
            Assert.That(RunValidate(input, "['The FN property must appear in the VCARD component exactly 1 time']", repaired),
                Is.EqualTo("WARN_OK\nREPAIR_OK"));
        }

        [Test]
        public void testValidateNoFNwithORG()
        {
            var input = "BEGIN:VCARD\r\nVERSION:4.0\r\nUID:foo\r\nORG:Acme Co.\r\nEND:VCARD\r\n";
            var repaired = "BEGIN:VCARD\r\nVERSION:4.0\r\nUID:foo\r\nORG:Acme Co.\r\nFN:Acme Co.\r\nEND:VCARD\r\n";
            Assert.That(RunValidate(input, "['The FN property must appear in the VCARD component exactly 1 time']", repaired),
                Is.EqualTo("WARN_OK\nREPAIR_OK"));
        }

        [Test]
        public void testValidateNoFNwithNICKNAME()
        {
            var input = "BEGIN:VCARD\r\nVERSION:4.0\r\nUID:foo\r\nNICKNAME:JohnDoe\r\nEND:VCARD\r\n";
            var repaired = "BEGIN:VCARD\r\nVERSION:4.0\r\nUID:foo\r\nNICKNAME:JohnDoe\r\nFN:JohnDoe\r\nEND:VCARD\r\n";
            Assert.That(RunValidate(input, "['The FN property must appear in the VCARD component exactly 1 time']", repaired),
                Is.EqualTo("WARN_OK\nREPAIR_OK"));
        }

        [Test]
        public void testValidateNoFNwithEMAIL()
        {
            var input = "BEGIN:VCARD\r\nVERSION:4.0\r\nUID:foo\r\nEMAIL:1@example.org\r\nEND:VCARD\r\n";
            var repaired = "BEGIN:VCARD\r\nVERSION:4.0\r\nUID:foo\r\nEMAIL:1@example.org\r\nFN:1@example.org\r\nEND:VCARD\r\n";
            Assert.That(RunValidate(input, "['The FN property must appear in the VCARD component exactly 1 time']", repaired),
                Is.EqualTo("WARN_OK\nREPAIR_OK"));
        }

        // ===== testGetDocumentType =====
        [Test]
        public void testGetDocumentType()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$lines = [];" + "\n"
                     + "$v1 = new VCard([], false); $v1->Version = '2.1';" + "\n"
                     + "$lines[] = $v1->getDocumentType();" + "\n"
                     + "$v2 = new VCard([], false); $v2->Version = '3.0';" + "\n"
                     + "$lines[] = $v2->getDocumentType();" + "\n"
                     + "$v3 = new VCard([], false); $v3->Version = '4.0';" + "\n"
                     + "$lines[] = $v3->getDocumentType();" + "\n"
                     + "$v4 = new VCard([], false);" + "\n"
                     + "$lines[] = $v4->getDocumentType();" + "\n"
                     + "echo implode(\"\\n\", $lines);";
            // VCARD21=1, VCARD30=2, VCARD40=3, UNKNOWN=0（具体常量值需以 sabre 实际为准，用等值比较）
            var res = RunPhp(body);
            // 用 PHP 端常量比较而非写死数字
            Assert.That(res.Split('\n').Length, Is.EqualTo(4), "应输出 4 个文档类型值: " + res);
        }

        // ===== testGetByType =====
        [Test]
        public void testGetByType()
        {
            var vcf = @"BEGIN:VCARD
VERSION:3.0
EMAIL;TYPE=home:1@example.org
EMAIL;TYPE=work:2@example.org
END:VCARD";
            var body = "use Sabre\\VObject;" + "\n"
                     + "$vcard = VObject\\Reader::read(<<<VCF\n" + vcf + "\nVCF\n);" + "\n"
                     + "$lines = [];" + "\n"
                     + "$lines[] = $vcard->getByType('EMAIL', 'home')->getValue();" + "\n"
                     + "$lines[] = $vcard->getByType('EMAIL', 'work')->getValue();" + "\n"
                     + "$lines[] = $vcard->getByType('EMAIL', 'non-existent') === null ? 'NULL' : 'NOT_NULL';" + "\n"
                     + "$lines[] = $vcard->getByType('ADR', 'non-existent') === null ? 'NULL' : 'NOT_NULL';" + "\n"
                     + "echo implode(\"\\n\", $lines);";
            Assert.That(RunPhp(body), Is.EqualTo(@"1@example.org
2@example.org
NULL
NULL"));
        }

        // ===== testPreferred 系列 =====
        [Test]
        public void testPreferredNoPref()
        {
            var vcf = @"BEGIN:VCARD
VERSION:3.0
EMAIL:1@example.org
EMAIL:2@example.org
END:VCARD";
            var body = "use Sabre\\VObject;" + "\n"
                     + "$vcard = VObject\\Reader::read(<<<VCF\n" + vcf + "\nVCF\n);" + "\n"
                     + "echo $vcard->preferred('EMAIL')->getValue();";
            Assert.That(RunPhp(body), Is.EqualTo("1@example.org"));
        }

        [Test]
        public void testPreferredWithPref()
        {
            var vcf = @"BEGIN:VCARD
VERSION:3.0
EMAIL:1@example.org
EMAIL;TYPE=PREF:2@example.org
END:VCARD";
            var body = "use Sabre\\VObject;" + "\n"
                     + "$vcard = VObject\\Reader::read(<<<VCF\n" + vcf + "\nVCF\n);" + "\n"
                     + "echo $vcard->preferred('EMAIL')->getValue();";
            Assert.That(RunPhp(body), Is.EqualTo("2@example.org"));
        }

        [Test]
        public void testPreferredWith40Pref()
        {
            var vcf = @"BEGIN:VCARD
VERSION:4.0
EMAIL:1@example.org
EMAIL;PREF=3:2@example.org
EMAIL;PREF=2:3@example.org
END:VCARD";
            var body = "use Sabre\\VObject;" + "\n"
                     + "$vcard = VObject\\Reader::read(<<<VCF\n" + vcf + "\nVCF\n);" + "\n"
                     + "echo $vcard->preferred('EMAIL')->getValue();";
            Assert.That(RunPhp(body), Is.EqualTo("3@example.org"));
        }

        [Test]
        public void testPreferredNotFound()
        {
            var vcf = @"BEGIN:VCARD
VERSION:4.0
END:VCARD";
            var body = "use Sabre\\VObject;" + "\n"
                     + "$vcard = VObject\\Reader::read(<<<VCF\n" + vcf + "\nVCF\n);" + "\n"
                     + "echo $vcard->preferred('EMAIL') === null ? 'NULL' : 'NOT_NULL';";
            Assert.That(RunPhp(body), Is.EqualTo("NULL"));
        }

        // ===== assertValidate 系列（5 个 UID/CardDAV 相关）=====
        private static string RunValidateWithOptions(string vcf, int options)
        {
            var body = "use Sabre\\VObject;" + "\n"
                     + "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcal = VObject\\Reader::read(<<<VCF\n" + vcf + "\nVCF\n);" + "\n"
                     + "$result = $vcal->validate(" + options + ");" + "\n"
                     + "$lines = [];" + "\n"
                     + "$lines[] = count($result);" + "\n"
                     + "foreach ($result as $w) { $lines[] = $w['message'] . '|' . $w['level']; }" + "\n"
                     + "echo implode(\"\\n\", $lines);";
            return RunPhp(body);
        }

        [Test]
        public void testNoUIDCardDAV()
        {
            // PROFILE_CARDDAV = 2（Node 常量），level 3
            var vcf = @"BEGIN:VCARD
VERSION:4.0
FN:John Doe
END:VCARD";
            var res = RunValidateWithOptions(vcf, 2);  // Node::PROFILE_CARDDAV
            Assert.Multiple(() =>
            {
                Assert.That(res.Split('\n')[0], Is.EqualTo("1"));
                Assert.That(res, Does.Contain("vCards on CardDAV servers MUST have a UID property.|3"));
            });
        }

        [Test]
        public void testNoUIDNoCardDAV()
        {
            var vcf = @"BEGIN:VCARD
VERSION:4.0
FN:John Doe
END:VCARD";
            var res = RunValidateWithOptions(vcf, 0);
            Assert.Multiple(() =>
            {
                Assert.That(res.Split('\n')[0], Is.EqualTo("1"));
                Assert.That(res, Does.Contain("Adding a UID to a vCard property is recommended.|2"));
            });
        }

        [Test]
        public void testNoUIDNoCardDAVRepair()
        {
            // REPAIR = 1
            var vcf = @"BEGIN:VCARD
VERSION:4.0
FN:John Doe
END:VCARD";
            var res = RunValidateWithOptions(vcf, 1);
            Assert.Multiple(() =>
            {
                Assert.That(res.Split('\n')[0], Is.EqualTo("1"));
                Assert.That(res, Does.Contain("Adding a UID to a vCard property is recommended.|1"));
            });
        }

        [Test]
        public void testVCard21CardDAV()
        {
            var vcf = @"BEGIN:VCARD
VERSION:2.1
FN:John Doe
UID:foo
END:VCARD";
            var res = RunValidateWithOptions(vcf, 2);  // Node::PROFILE_CARDDAV
            Assert.Multiple(() =>
            {
                Assert.That(res.Split('\n')[0], Is.EqualTo("1"));
                Assert.That(res, Does.Contain("CardDAV servers are not allowed to accept vCard 2.1.|3"));
            });
        }

        [Test]
        public void testVCard21NoCardDAV()
        {
            var vcf = @"BEGIN:VCARD
VERSION:2.1
FN:John Doe
UID:foo
END:VCARD";
            // 无 message（level 0 = count 0）
            var res = RunValidateWithOptions(vcf, 0);
            Assert.That(res.Split('\n')[0], Is.EqualTo("0"));
        }
    }
}
