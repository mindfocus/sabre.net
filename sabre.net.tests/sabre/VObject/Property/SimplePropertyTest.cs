using System.Collections.Generic;
using NUnit.Framework;

namespace sabre.net.tests.sabre.VObject.Property
{
    /// <summary>
    /// 迁移自上游 sabre-io/vobject 4.5.6 的 tests/VObject/Property/ 下简单属性类型测试：
    /// Binary、Boolean、Float、Uri、Text、Compound，以及 Property/VCard（LanguageTag/PhoneNumber/DateAndOrTime）。
    /// 采用 PHP 脚本路径（SabrePhpRunner.RunInPeachpie）。
    /// </summary>
    public class SimplePropertyTest
    {
        private static string RunPhp(string body, string tz = "UTC")
        {
            var php = "date_default_timezone_set('" + tz + "');" + "\n"
                    + "\\nextsharp_sabre_runtime_patch_bootstrap();" + "\n"
                    + body;
            return SabrePhpRunner.RunInPeachpie(php).Replace("\r\n", "\n").Trim();
        }

        // ===== BinaryTest: PHOTO 多值应抛 InvalidArgumentException =====
        [Test]
        public void testBinaryMimeDirThrows()
        {
            var body = "use Sabre\\VObject;" + "\n"
                     + "try {" + "\n"
                     + "  $vcard = new VObject\\Component\\VCard(['VERSION' => '3.0']);" + "\n"
                     + "  $vcard->add('PHOTO', ['a', 'b']);" + "\n"
                     + "  echo 'NO_EXCEPTION';" + "\n"
                     + "} catch (\\InvalidArgumentException $e) {" + "\n"
                     + "  echo 'INVALID_ARGUMENT';" + "\n"
                     + "} catch (\\Throwable $e) {" + "\n"
                     + "  echo 'OTHER:' . get_class($e);" + "\n"
                     + "}";
            Assert.That(RunPhp(body), Is.EqualTo("INVALID_ARGUMENT"));
        }

        // ===== BooleanTest: BOOLEAN 类型值的 get/serialize =====
        [Test]
        public void testBooleanMimeDir()
        {
            var body = "use Sabre\\VObject;" + "\n"
                     + "$input = \"BEGIN:VCARD\\r\\nX-AWESOME;VALUE=BOOLEAN:TRUE\\r\\nX-SUCKS;VALUE=BOOLEAN:FALSE\\r\\nEND:VCARD\\r\\n\";" + "\n"
                     + "$vcard = VObject\\Reader::read($input);" + "\n"
                     + "$lines = [];" + "\n"
                     + "$lines[] = $vcard->{'X-AWESOME'}->getValue() ? 'TRUE' : 'FALSE';" + "\n"
                     + "$lines[] = $vcard->{'X-SUCKS'}->getValue() ? 'TRUE' : 'FALSE';" + "\n"
                     + "$lines[] = $vcard->{'X-AWESOME'}->getValueType();" + "\n"
                     + "$lines[] = ($vcard->serialize() === $input) ? 'EQUAL' : 'NOT_EQUAL';" + "\n"
                     + "echo implode(\"\\n\", $lines);";
            Assert.That(RunPhp(body), Is.EqualTo(@"TRUE
FALSE
BOOLEAN
EQUAL"));
        }

        // ===== FloatTest: FLOAT 类型值的 getParts/serialize =====
        [Test]
        public void testFloatMimeDir()
        {
            var body = "use Sabre\\VObject;" + "\n"
                     + "use Sabre\\VObject\\Property\\FloatValue;" + "\n"
                     + "$input = \"BEGIN:VCARD\\r\\nVERSION:4.0\\r\\nX-FLOAT;VALUE=FLOAT:0.234;1.245\\r\\nEND:VCARD\\r\\n\";" + "\n"
                     + "$mimeDir = new VObject\\Parser\\MimeDir($input);" + "\n"
                     + "$result = $mimeDir->parse($input);" + "\n"
                     + "$lines = [];" + "\n"
                     + "$lines[] = ($result->{'X-FLOAT'} instanceof FloatValue) ? 'FLOAT' : 'NOT_FLOAT';" + "\n"
                     + "// getParts 比较：用 == 弱类型比较（0.234 等数值）" + "\n"
                     + "$lines[] = ($result->{'X-FLOAT'}->getParts() == [0.234, 1.245]) ? 'EQUAL' : 'NOT_EQUAL';" + "\n"
                     + "$lines[] = ($result->serialize() === $input) ? 'EQUAL' : 'NOT_EQUAL';" + "\n"
                     + "echo implode(\"\\n\", $lines);";
            Assert.That(RunPhp(body), Is.EqualTo(@"FLOAT
EQUAL
EQUAL"));
        }

        // ===== UriTest: VCalendar 的 URL 属性序列化时自动补 VALUE=URI =====
        [Test]
        public void testUriAlwaysEncodeUriVCalendar()
        {
            var ics = @"BEGIN:VCALENDAR
VERSION:2.0
BEGIN:VEVENT
URL:http://example.org/
END:VEVENT
END:VCALENDAR";
            var body = "use Sabre\\VObject\\Reader;" + "\n"
                     + "$output = Reader::read(<<<ICS\n" + ics + "\nICS\n)->serialize();" + "\n"
                     + "echo strpos($output, 'URL;VALUE=URI:http://example.org/') !== false ? 'FOUND' : 'NOT_FOUND';";
            Assert.That(RunPhp(body), Is.EqualTo("FOUND"));
        }

        // ===== CompoundTest::testSetParts: ORG 多值转义 =====
        [Test]
        public void testCompoundSetParts()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$elem = $vcard->createProperty('ORG');" + "\n"
                     + "$elem->setParts(['ABC, Inc.', 'North American Division', 'Marketing;Sales']);" + "\n"
                     + "echo $elem->getValue() . \"\\n\" . count($elem->getParts());";
            Assert.That(RunPhp(body), Is.EqualTo(@"ABC\, Inc.;North American Division;Marketing\;Sales
3"));
        }

        [Test]
        public void testCompoundGetParts()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$elem = $vcard->createProperty('ORG');" + "\n"
                     + "$elem->setRawMimeDirValue('ABC\\, Inc.;North American Division;Marketing\\;Sales');" + "\n"
                     + "$parts = $elem->getParts();" + "\n"
                     + "echo count($parts) . \"\\n\" . $parts[2];";
            Assert.That(RunPhp(body), Is.EqualTo(@"3
Marketing;Sales"));
        }

        [Test]
        public void testCompoundGetPartsNull()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$elem = $vcard->createProperty('ORG', null);" + "\n"
                     + "echo count($elem->getParts());";
            Assert.That(RunPhp(body), Is.EqualTo("0"));
        }

        // ===== TextTest: VCard 2.1 序列化（含转义/折行/quoted-printable）=====
        // 用 PHP 端 assertEquals 比较，规避精确字符串差异
        [Test]
        public void testTextSerializeVCard21()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$doc = new VCard(['VERSION' => '2.1', 'PROP' => 'f;oo'], false);" + "\n"
                     + "$doc->PROP['ENCODING'] = 'QUOTED-PRINTABLE';" + "\n"
                     + "$doc->PROP['P1'] = 'V1';" + "\n"
                     + "$expected = \"BEGIN:VCARD\\r\\nVERSION:2.1\\r\\nPROP;P1=V1:f;oo\\r\\nEND:VCARD\\r\\n\";" + "\n"
                     + "echo $doc->serialize() === $expected ? 'EQUAL' : 'NOT_EQUAL';";
            Assert.That(RunPhp(body), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testTextSerializeVCard21Array()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$doc = new VCard(['VERSION' => '2.1', 'PROP' => ['f;oo', 'bar']], false);" + "\n"
                     + "$doc->PROP['ENCODING'] = 'QUOTED-PRINTABLE';" + "\n"
                     + "$doc->PROP['P1'] = 'V1';" + "\n"
                     + "$expected = \"BEGIN:VCARD\\r\\nVERSION:2.1\\r\\nPROP;P1=V1:f\\\\;oo;bar\\r\\nEND:VCARD\\r\\n\";" + "\n"
                     + "echo $doc->serialize() === $expected ? 'EQUAL' : 'NOT_EQUAL';";
            Assert.That(RunPhp(body), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testTextSerializeVCard21Fold()
        {
            // 80 个 x 折行：前 64 + 续行 16
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$doc = new VCard(['VERSION' => '2.1', 'PROP' => str_repeat('x', 80)], false);" + "\n"
                     + "$doc->PROP['ENCODING'] = 'QUOTED-PRINTABLE';" + "\n"
                     + "$doc->PROP['P1'] = 'V1';" + "\n"
                     + "$expected = \"BEGIN:VCARD\\r\\nVERSION:2.1\\r\\nPROP;P1=V1:\" . str_repeat('x', 64) . \"\\r\\n \" . str_repeat('x', 16) . \"\\r\\nEND:VCARD\\r\\n\";" + "\n"
                     + "echo $doc->serialize() === $expected ? 'EQUAL' : 'NOT_EQUAL';";
            Assert.That(RunPhp(body), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testTextSerializeQuotedPrintable()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$doc = new VCard(['VERSION' => '2.1', 'PROP' => \"foo\\r\\nbar\"], false);" + "\n"
                     + "$doc->PROP['ENCODING'] = 'QUOTED-PRINTABLE';" + "\n"
                     + "$doc->PROP['P1'] = 'V1';" + "\n"
                     + "$expected = \"BEGIN:VCARD\\r\\nVERSION:2.1\\r\\nPROP;P1=V1;ENCODING=QUOTED-PRINTABLE:foo=0D=0Abar\\r\\nEND:VCARD\\r\\n\";" + "\n"
                     + "echo $doc->serialize() === $expected ? 'EQUAL' : 'NOT_EQUAL';";
            Assert.That(RunPhp(body), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testTextSerializeQuotedPrintableFold()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$val = \"foo\\r\\nbarxxxxxxxxxxxxxxxxxxxxxxxxxxxxx\";" + "\n"
                     + "$doc = new VCard(['VERSION' => '2.1', 'PROP' => $val], false);" + "\n"
                     + "$doc->PROP['ENCODING'] = 'QUOTED-PRINTABLE';" + "\n"
                     + "$doc->PROP['P1'] = 'V1';" + "\n"
                     + "$expected = \"BEGIN:VCARD\\r\\nVERSION:2.1\\r\\nPROP;P1=V1;ENCODING=QUOTED-PRINTABLE:foo=0D=0Abarxxxxxxxxxxxxxxxxxxxxxxxxxx=\\r\\n xxx\\r\\nEND:VCARD\\r\\n\";" + "\n"
                     + "echo $doc->serialize() === $expected ? 'EQUAL' : 'NOT_EQUAL';";
            Assert.That(RunPhp(body), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testTextValidateMinimumPropValues()
        {
            // VCard 4.0 N 字段不足 5 段，validate 报 1 条；REPAIR 后补齐 5 段
            var vcf = @"BEGIN:VCARD
VERSION:4.0
UID:foo
FN:Hi!
N:A
END:VCARD";
            var body = "use Sabre\\VObject\\Reader;" + "\n"
                     + "use Sabre\\VObject\\Node;" + "\n"
                     + "$vcard = Reader::read(<<<VCF\n" + vcf + "\nVCF\n);" + "\n"
                     + "$lines = [];" + "\n"
                     + "$lines[] = count($vcard->validate());" + "\n"
                     + "$lines[] = count($vcard->N->getParts());" + "\n"
                     + "$vcard->validate(Node::REPAIR);" + "\n"
                     + "$lines[] = count($vcard->N->getParts());" + "\n"
                     + "echo implode(\"\\n\", $lines);";
            Assert.That(RunPhp(body), Is.EqualTo("1\n1\n5"));
        }

        // ===== Property/VCard/LanguageTagTest =====
        [Test]
        public void testLanguageTagMimeDir()
        {
            var body = "use Sabre\\VObject;" + "\n"
                     + "use Sabre\\VObject\\Property\\VCard\\LanguageTag;" + "\n"
                     + "$input = \"BEGIN:VCARD\\r\\nVERSION:4.0\\r\\nLANG:nl\\r\\nEND:VCARD\\r\\n\";" + "\n"
                     + "$mimeDir = new VObject\\Parser\\MimeDir($input);" + "\n"
                     + "$result = $mimeDir->parse($input);" + "\n"
                     + "$lines = [];" + "\n"
                     + "$lines[] = ($result->LANG instanceof LanguageTag) ? 'LANG_TAG' : 'NOT';" + "\n"
                     + "$lines[] = $result->LANG->getValue();" + "\n"
                     + "$lines[] = ($result->serialize() === $input) ? 'EQUAL' : 'NOT_EQUAL';" + "\n"
                     + "echo implode(\"\\n\", $lines);";
            Assert.That(RunPhp(body), Is.EqualTo(@"LANG_TAG
nl
EQUAL"));
        }

        [Test]
        public void testLanguageTagChangeAndSerialize()
        {
            var body = "use Sabre\\VObject;" + "\n"
                     + "use Sabre\\VObject\\Property\\VCard\\LanguageTag;" + "\n"
                     + "$input = \"BEGIN:VCARD\\r\\nVERSION:4.0\\r\\nLANG:nl\\r\\nEND:VCARD\\r\\n\";" + "\n"
                     + "$mimeDir = new VObject\\Parser\\MimeDir($input);" + "\n"
                     + "$result = $mimeDir->parse($input);" + "\n"
                     + "$result->LANG->setValue(['de']);" + "\n"
                     + "$expected = \"BEGIN:VCARD\\r\\nVERSION:4.0\\r\\nLANG:de\\r\\nEND:VCARD\\r\\n\";" + "\n"
                     + "echo $result->serialize() === $expected ? 'EQUAL' : 'NOT_EQUAL';";
            Assert.That(RunPhp(body), Is.EqualTo("EQUAL"));
        }

        // ===== Property/VCard/PhoneNumberTest =====
        [Test]
        public void testPhoneNumberParser()
        {
            var body = "use Sabre\\VObject;" + "\n"
                     + "use Sabre\\VObject\\Property\\VCard\\PhoneNumber;" + "\n"
                     + "$input = \"BEGIN:VCARD\\r\\nVERSION:3.0\\r\\nTEL;TYPE=HOME;VALUE=PHONE-NUMBER:+1234\\r\\nEND:VCARD\\r\\n\";" + "\n"
                     + "$vCard = VObject\\Reader::read($input);" + "\n"
                     + "$lines = [];" + "\n"
                     + "$lines[] = ($vCard->TEL instanceof PhoneNumber) ? 'PHONE' : 'NOT';" + "\n"
                     + "$lines[] = $vCard->TEL->getValueType();" + "\n"
                     + "$lines[] = ($vCard->serialize() === $input) ? 'EQUAL' : 'NOT_EQUAL';" + "\n"
                     + "echo implode(\"\\n\", $lines);";
            Assert.That(RunPhp(body), Is.EqualTo(@"PHONE
PHONE-NUMBER
EQUAL"));
        }

        // ===== Property/VCard/DateAndOrTimeTest =====
        // testGetJsonValue：14 组日期格式归一化（DataProvider）
        [TestCaseSource(nameof(DateAndOrTimeJsonCases))]
        public void testDateAndOrTimeGetJsonValue(string input, string output)
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$prop = $vcard->createProperty('BDAY', '" + input + "');" + "\n"
                     + "echo json_encode($prop->getJsonValue());";
            // getJsonValue 返回 [output]，json_encode 后 ["output"]
            Assert.That(RunPhp(body), Is.EqualTo("[\"" + output + "\"]"));
        }

        public static IEnumerable<object[]> DateAndOrTimeJsonCases()
        {
            yield return new object[] { "19961022T140000", "1996-10-22T14:00:00" };
            yield return new object[] { "--1022T1400", "--10-22T14:00" };
            yield return new object[] { "---22T14", "---22T14" };
            yield return new object[] { "19850412", "1985-04-12" };
            yield return new object[] { "1985-04", "1985-04" };
            yield return new object[] { "1985", "1985" };
            yield return new object[] { "--0412", "--04-12" };
            yield return new object[] { "T102200", "T10:22:00" };
            yield return new object[] { "T1022", "T10:22" };
            yield return new object[] { "T10", "T10" };
            yield return new object[] { "T-2200", "T-22:00" };
            yield return new object[] { "T102200Z", "T10:22:00Z" };
            yield return new object[] { "T102200-0800", "T10:22:00-0800" };
            yield return new object[] { "T--00", "T--00" };
        }

        [Test]
        public void testDateAndOrTimeSetParts()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$prop = $vcard->createProperty('BDAY');" + "\n"
                     + "$prop->setParts([new \\DateTime('2014-04-02 18:37:00')]);" + "\n"
                     + "echo $prop->getValue();";
            Assert.That(RunPhp(body), Is.EqualTo("20140402T183700Z"));
        }

        [Test]
        public void testDateAndOrTimeSetPartsDateTimeImmutable()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$prop = $vcard->createProperty('BDAY');" + "\n"
                     + "$prop->setParts([new \\DateTimeImmutable('2014-04-02 18:37:00')]);" + "\n"
                     + "echo $prop->getValue();";
            Assert.That(RunPhp(body), Is.EqualTo("20140402T183700Z"));
        }

        [Test]
        public void testDateAndOrTimeSetPartsTooManyThrows()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "try {" + "\n"
                     + "  $vcard = new VCard();" + "\n"
                     + "  $prop = $vcard->createProperty('BDAY');" + "\n"
                     + "  $prop->setParts([1, 2]);" + "\n"
                     + "  echo 'NO_EXCEPTION';" + "\n"
                     + "} catch (\\InvalidArgumentException $e) {" + "\n"
                     + "  echo 'INVALID_ARGUMENT';" + "\n"
                     + "} catch (\\Throwable $e) {" + "\n"
                     + "  echo 'OTHER:' . get_class($e);" + "\n"
                     + "}";
            Assert.That(RunPhp(body), Is.EqualTo("INVALID_ARGUMENT"));
        }

        [Test]
        public void testDateAndOrTimeSetPartsString()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$prop = $vcard->createProperty('BDAY');" + "\n"
                     + "$prop->setParts(['20140402T183700Z']);" + "\n"
                     + "echo $prop->getValue();";
            Assert.That(RunPhp(body), Is.EqualTo("20140402T183700Z"));
        }

        [Test]
        public void testDateAndOrTimeSetValueDateTime()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$prop = $vcard->createProperty('BDAY');" + "\n"
                     + "$prop->setValue(new \\DateTime('2014-04-02 18:37:00'));" + "\n"
                     + "echo $prop->getValue();";
            Assert.That(RunPhp(body), Is.EqualTo("20140402T183700Z"));
        }

        [Test]
        public void testDateAndOrTimeSetValueDateTimeImmutable()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$prop = $vcard->createProperty('BDAY');" + "\n"
                     + "$prop->setValue(new \\DateTimeImmutable('2014-04-02 18:37:00'));" + "\n"
                     + "echo $prop->getValue();";
            Assert.That(RunPhp(body), Is.EqualTo("20140402T183700Z"));
        }

        [Test]
        public void testDateAndOrTimeSetDateTimeOffset()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$prop = $vcard->createProperty('BDAY');" + "\n"
                     + "$prop->setValue(new \\DateTime('2014-04-02 18:37:00', new \\DateTimeZone('America/Toronto')));" + "\n"
                     + "echo $prop->getValue();";
            Assert.That(RunPhp(body), Is.EqualTo("20140402T183700-0400"));
        }

        [Test]
        public void testDateAndOrTimeGetDateTime()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$datetime = new \\DateTime('2014-04-02 18:37:00', new \\DateTimeZone('America/Toronto'));" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$prop = $vcard->createProperty('BDAY', $datetime);" + "\n"
                     + "echo $prop->getDateTime()->format('c');";
            Assert.That(RunPhp(body), Is.EqualTo("2014-04-02T18:37:00-04:00"));
        }

        [Test]
        public void testDateAndOrTimeGetDate()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$datetime = new \\DateTime('2014-04-02');" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$prop = $vcard->createProperty('BDAY', $datetime, null, 'DATE');" + "\n"
                     + "echo $prop->getValueType() . \"\\n\" . rtrim($prop->serialize());";
            Assert.That(RunPhp(body), Is.EqualTo(@"DATE
BDAY:20140402"));
        }

        [Test]
        public void testDateAndOrTimeGetDateIncomplete()
        {
            // --0407 解析后用当前年份
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$prop = $vcard->add('BDAY', '--0407');" + "\n"
                     + "$dt = $prop->getDateTime();" + "\n"
                     + "$year = (new \\DateTime('now'))->format('Y');" + "\n"
                     + "echo $dt->format('Ymd') === $year.'0407' ? 'EQUAL' : 'NOT_EQUAL';";
            Assert.That(RunPhp(body), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testDateAndOrTimeGetDateIncompleteFromVCard()
        {
            var vcf = @"BEGIN:VCARD
VERSION:4.0
BDAY:--0407
END:VCARD";
            var body = "use Sabre\\VObject\\Reader;" + "\n"
                     + "$vcard = Reader::read(<<<VCF\n" + vcf + "\nVCF\n);" + "\n"
                     + "$prop = $vcard->BDAY;" + "\n"
                     + "$dt = $prop->getDateTime();" + "\n"
                     + "$year = (new \\DateTime('now'))->format('Y');" + "\n"
                     + "echo $dt->format('Ymd') === $year.'0407' ? 'EQUAL' : 'NOT_EQUAL';";
            Assert.That(RunPhp(body), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testDateAndOrTimeValidate()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$prop = $vcard->add('BDAY', '--0407');" + "\n"
                     + "echo count($prop->validate()) === 0 ? 'EMPTY' : 'NOT_EMPTY';";
            Assert.That(RunPhp(body), Is.EqualTo("EMPTY"));
        }

        [Test]
        public void testDateAndOrTimeValidateBroken()
        {
            var body = "use Sabre\\VObject\\Component\\VCard;" + "\n"
                     + "$vcard = new VCard();" + "\n"
                     + "$prop = $vcard->add('BDAY', '123');" + "\n"
                     + "$result = $prop->validate();" + "\n"
                     + "echo count($result) . \"\\n\" . $result[0]['level'] . \"\\n\" . $result[0]['message'];";
            Assert.That(RunPhp(body), Is.EqualTo(@"1
3
The supplied value (123) is not a correct DATE-AND-OR-TIME property"));
        }
    }
}
