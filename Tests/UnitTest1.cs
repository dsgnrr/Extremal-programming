// ������ ��������� (Dependencies - Project Reference) �� ������ App
using App;
using System.Globalization;

namespace Tests
{
    [TestClass]
    public class UnitTestRomanNumber
    {

        /* �.�. ���������� ����-�����:
    `   * �������� ��������� ����� (-3000 ... 3000),
    `   * ������ ���� ������������� � ������� ����
    `   * ������� �� ������������� - ���� �������� ��������� �����
    `   * ��������� ������� 256 ����
    `   */

        [TestMethod]
        public void TestAdd()
        {
            RomanNumber r1 = new(10);
            RomanNumber r2 = new(20);
            Assert.IsInstanceOfType(r1.Add(r2), typeof(RomanNumber));
            Assert.AreEqual("XXX", r1.Add(r2).ToString());
            Assert.AreEqual(30, r1.Add(r2).Value);
            Assert.AreEqual("XXX", r2.Add(r1).ToString());
            Assert.AreEqual(30, r2.Add(r1).Value);
            
            var ex =Assert.ThrowsException<ArgumentNullException>(
                ()=> r1.Add(null!),
                "r1.Add(null!) --> ArgumentNullException");
            // "ex.Message contains 'Cannot Add null object'"

            Assert.IsTrue(ex.Message.Contains(
                "Cannot Add null object",
                StringComparison.OrdinalIgnoreCase // ��������������� ���������
                ),
                $"ex.Message({ex.Message}) contains 'Cannot Add null object'");

            // ������������ � ����, �� r2.Add(r1) �� ����� ��'���, � �� �������� r2
            Assert.AreNotSame(r2, r2.Add(r1), " Add() should return new item");
        }


        [TestMethod]
        public void TestToStringXParse()
        {
            Random r = new();
            for (int i = 0; i < 256; i++)
            {
                RomanNumber romanNumber = new(r.Next(-3000, 3000));
                Assert.AreEqual(romanNumber.ToString(),
                    RomanNumber.Parse(romanNumber.ToString()).ToString(),
                    "romanNumber.ToString() != RomanNumber.Parse(romanNumber.ToString)");
            }
        }
        [TestMethod]
        public void TestToString()
        {
            /* �������� ������ ����� ��� ���������� ����� �������� �����
             * ������� 10 ����� � ����� �������� ��������
             * 0-10, 10-100, 100-1000, 1000-3000
             * �� � ����� ������� ���� � ����
             */
            Dictionary<int, String> testCases = new()
            {
                {1,"I" },
                {29, "XXIX"},
                {39, "XXXIX"},
                {246, "CCXLVI"},
                {378, "CCCLXXVIII"},
                {1199, "MCXCIX"},
                {1350, "MCCCL"},
                {2247, "MMCCXLVII"},
                {2499, "MMCDXCIX"},
                {2700, "MMDCC"},
                {2999, "MMCMXCIX"},
                { -2947, "-MMCMXLVII" },
                { -2970, "-MMCMLXX" },
                { -2730, "-MMDCCXXX" },
                { -2756, "-MMDCCLVI" },
                { -2767, "-MMDCCLXVII" },
                { -2777, "-MMDCCLXXVII" },
                { -2799, "-MMDCCXCIX" },
                { -1603, "-MDCIII" },
                { -1674, "-MDCLXXIV" },
                { -1718, "-MDCCXVIII" },
                { -1742, "-MDCCXLII" },
                { -1747, "-MDCCXLVII" },
                { -1784, "-MDCCLXXXIV" },
                { -1796, "-MDCCXCVI" },
                { -1884, "-MDCCCLXXXIV" },
                { -1945, "-MCMXLV" },
                { -1951, "-MCMLI" },
                { -1972, "-MCMLXXII" },
                { -1980, "-MCMLXXX" },
            };
            foreach (var pair in testCases)
            {
                Assert.AreEqual(pair.Value, new RomanNumber(pair.Key).ToString(), $"{pair.Key}.ToString()=={pair.Value}");
            }
            // ���� ������������ ��� ���������
            Assert.AreEqual(
                "N",
                new RomanNumber().ToString(),
                $"new RomanNumber()=='N'"
            );
        }

        private static Dictionary<String, int> parseTests = new()
        {
            {"I"     , 1  },
            {"II"    , 2  },
            {"III"   , 3  },
            {"IIII"  , 4  }, // ������� ���������� - � ��� �� ��������� ���
            {"IV"   , 4  },  // �������� ������������� ������ ��
            {"V"    , 5  },
            {"VI"   , 6  },
            {"VII"  , 7  },
            {"VIII" , 8  },
            {"IX"   , 9  },
            {"X"  , 10  },
            {"VV", 10 }, // �� ���� ����������� ��������������
            {"IIIIIIIIII", 10 }, // �� ���� ����������� ��������������
            {"VX", 5 }, // �� ���� ����������� ��������������
            {"N",0 }, // ���������� ������� ����� �����
            {"-L",-50 }, // �������, �� ������ ��'��� �����
            {"-XL",-40 },
            {"-IL",-49 }, // ��������������

            //{"-MDV",1505 },//fall
            {"DD",1000 },
            {"CCCCC",500 },
            {"IVIVIVIVIV",20 },
            {"MMDDCCCCCCCCCC",4000 },
            {"MMXXIII",2023},
            { "CMD", 1400 },
            { "CLI", 151},
            { "DIL", 549},
            { "DID", 999},
            { "DMC", 600},


            //DZ
  
            {"XIV", 14},
            {"XXIV", 24},
            {"XXIX", 29},
            {"XXXIV", 34},
            {"XXXIX", 39},
            {"XLIV", 44},
            {"XLIX", 49},
            {"LIV", 54},
            {"LIX", 59},
            {"LXIV", 64},
            {"LXIX", 69},
            {"LXXIV", 74},
            {"LXXIX", 79},
            {"LXXXIV", 84},
            {"LXXXIX", 89},
            {"XCIV", 94},
            {"XCIX", 99},
            {"CIV", 104},
            {"CIX", 109},
            {"CXIV", 114},
            {"CXIX", 119},
            {"CXXIV", 124},
            {"CXXIX", 129},
            {"CXXXIV", 134},
            {"CXXXIX", 139},
            {"CXLIV", 144},
            {"CXLIX", 149},
            {"CLIV", 154},
            {"CLIX", 159},
            {"CLXIV", 164},
            {"CLXIX", 169},
            {"CLXXIV", 174},
            {"CLXXIX", 179},
            {"CLXXXIV", 184},
            {"CLXXXIX", 189},
            {"CXCIV", 194},
            {"CXCIX", 199},
            {"CCIV", 204},
            {"CCIX", 209},
            {"CCXIV", 214},
            {"CCXIX", 219},
            {"CCXXIV", 224},
            {"CCXXIX", 229},
            {"CCXXXIV", 234},
            {"CCXXXIX", 239},
            {"CCXLIV", 244},
            {"CCXLIX", 249},
            {"CCLIV", 254},
            {"CCLIX", 259},
            {"CCLXIV", 264},
            {"CCLXIX", 269},
            {"CCLXXIV", 274},
            {"CCLXXIX", 279},
            {"CCLXXXIV", 284},
            {"CCLXXXIX", 289},
            {"CCXCIV", 294},
            {"CCXCIX", 299},
            {"CDIV", 404},
            {"CDIX", 409},
            {"CDXIV", 414},
            {"CDXIX", 419},
            {"CDXXIV", 424},
            {"CDXXIX", 429},
            {"CDXXXIV", 434},
            {"CDXXXIX", 439},
            {"CDXLIV", 444},
            {"CDXLIX", 449},
            {"CDLIV", 454},
            {"CDLIX", 459},
            {"CDLXIV", 464},
            {"CDLXIX", 469},
            {"CDLXXIV", 474},
            {"CDLXXIX", 479},
            {"CDLXXXIV", 484},
            {"CDLXXXIX", 489},
            {"CDXCIV", 494},
            {"CDXCIX", 499},
            {"DIV", 504},
            {"DIX", 509},
            {"DXIV", 514},
            {"DXIX", 519},
            {"DXXIV", 524},
            {"DXXIX", 529},
            {"DXXXIV", 534},
            {"DXXXIX", 539},
            {"DXLIV", 544},
            {"DXLIX", 549},
            {"DLIV", 554},
            {"DLIX", 559},
            {"DLXIV", 564},
            {"DLXIX", 569},
            {"DLXXIV", 574},
            {"DLXXIX", 579},
            {"DLXXXIV", 584},
            {"DLXXXIX", 589},
            {"DXCIV ", 594},
            {" DXCIX ", 599},
            {"\nCM\t", 900}



        };


        [TestMethod]
        public void TestParseValid()
        {
            /*Assert.AreEqual(        ///RomanNumber.Parse("I").Value == 1
                1,                         // ��������, �� ���������( �� �� ����, ���������� ������)
                RomanNumber      // ��������� �������� (��, �� ����������)
                            .Parse("I") //
                            .Value,      //
                "1 == I"                // �����������, �� �'������� ��� ������ �����
            );*/
            foreach (var pair in parseTests)
            {
                Assert.AreEqual(
                    pair.Value,
                    RomanNumber.Parse(pair.Key).Value,
                    $"{pair.Value}=={pair.Key}");
            }
        }

        [TestMethod]
        public void TestParseNonValid()
        {
            // ���������� � ������������� ������� �����
            Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse(""),
                " ' ' -> Exception");
            Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse(null!),
                " ' ' -> Exception");
            Assert.ThrowsException<ArgumentException>(
               () => RomanNumber.Parse(" "),
               " ' ' -> Exception");
            //���� ����������, �� ������� � �����, ������������ �� ���������
            var ex = Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse("XBC"),
                " ' ' -> Exception");
            // ��������, ��� ������� ��� ����������� ����� ('B') ����
            // �������� � ����������� ����������
            Assert.IsTrue(ex.Message.Contains('B'), "ex.Message should Contain 'B' ");

            Dictionary<String, char> testCases = new()
            {
                { "Xx",'x' },
                { "Xy",'y' },
                { "AX",'A' },
                { "X C",' ' },
                { "X\tC",'\t' },
                { "X\nC",'\n' },
            };
            foreach (var pair in testCases)
            {
                // ����������� ����� ex  - ������ ������� ������
                Assert.IsTrue(
                    Assert.ThrowsException<ArgumentException>(
                        () => RomanNumber.Parse(pair.Key),
                        $" '{pair.Key}' -> ArgumentException").Message.Contains($"'{pair.Value}'"),
                    $"'{pair.Key}' ex.Message should Contain '{pair.Value}' ");
            }

            // ���� ������������ ���� �������, �� �� ������� ����-��� � ���
            // "ABC" - ��� 'A', ��� 'B'

            ex = Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse("ABC"),
                " ' ' -> Exception");

            Assert.IsTrue(
                    ex.Message.Contains('A') && ex.Message.Contains('B'), $"'ABC' ex.Message({ex.Message}) should Contain 'A' and 'B'");

            // ��������� ������� - ��� ������������ ����� �������� ������
            // ��� ���� (�������), �� �� � ������������


            // + ���������, �� ����������� (����������) �� ������� �������
            // ���� �� ���� ����� �� ������������, ��� ��� �� ���� ����� �
            // ��������� ����� �� ������� ����������� (15 ����)
            Assert.IsFalse(ex.Message.Length < 15, "ex.Message.Length min 15");
        }

        [TestMethod]
        public void TestParseIllegal()
        {
            String[] illegals = { "IIV", "IIX", "VVX", "IVX", "IIIX", "VIX"};
            foreach (var illegal in illegals)
            {
                Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(illegal), $"'{illegal}' -> Exception)");
            }

        }
    }
}
/*  ���������� ��������� (exceptions)
 *  � ������ ���������� ���������� - ������� �����.
 *  ���� ������, �� ����� ������������� ������������, �������
 *  ��������������� �������� (��������). �� �������� ��������� ����� ���������� � �������� ��������� ������, �� ���� ����
 *  ��������� �������� �����.
 *  ����������:
 *  �   ������������ ������� ��� ���� ���������, ���� ��������� ��� �� ������������ �� ����������� �����
 *  �   ���� ������� �������� ����������, �� �������� �������� ����� �� �����������, �������, ����
 *  
 *  
 *  
 *  ��������:
 *  �� � ��������� ������� �����������, �� �
 *  'X C', ' XC', 'XC ', 'XC\t', '\nXC', 'XC\n', 'X\nC'
 *    x      v      v      v        v       v       x
 */


/*  ������ ��������� ����� ��������� ���������� (Asserts).
 *  � ���������� ��������� ��� ��������: ��, �� ���������, ��
 *  ��, �� ����������.
 *  ��������� ����� ���������� ������ (��'����� AreSame �� ��������� AreEqual),
 *  ��� � ��������� ���� (IsTrue, IsNotNul, ....)
 */
/* r1 + r2 + ... r10
 * r1 + r2 -> r_tmp1
 * r1 + r2 + r3 -> r_tmp1 + r3 -> r_tmp2 (r_tmp1 - garbage)
 * ... + r4 -> r_tmp2 + r4 -> r_tmp3 (r_tmp2 - garbage)
 * ------
 * ... + r10 -> result (garbage: r_tmp1 - r_tmp8)
 * ��������� 10 ����� ������� 8 ��'���� �� ��� �� ������
 * 
 * for() r += n[i] -- �� � ���� (���������� ���������� ��'���� -- �����)
 * �������� - StringBuilder (��� String)
 * 
 * 
 */
