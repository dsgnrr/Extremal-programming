// ������ ��������� (Dependencies - Project Reference) �� ������ App
using App;
using System.Globalization;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestToString()
        {
            Dictionary<int, String> testCases = new()
            {
                {1,"I" }
            };
            foreach (var pair in testCases)
            {
                Assert.AreEqual(pair.Value, new RomanNumber(pair.Key).ToString(), $"{pair.Key}.ToString()=={pair.Value}");
            }
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
            { "LID", 549},
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
        public void TestRomanNumberParseValid()
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
        public void TestRomanNumberParseNonValid()
        {
            // ���������� � ������������� ������� �����
            Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse(""),
                " ' ' -> Exception");
            Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse(null!),
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
                    ex.Message.Contains('A') || ex.Message.Contains('B'), $"'ABC' ex.Message should Contain 'A' or 'B'");
            // + ���������, �� ����������� (����������) �� ������� �������
            // ���� �� ���� ����� �� ������������, ��� ��� �� ���� ����� �
            // ��������� ����� �� ������� ����������� (15 ����)
            Assert.IsFalse(ex.Message.Length < 15,"ex.Message.Length min 15");
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