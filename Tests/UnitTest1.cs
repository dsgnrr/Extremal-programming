// ������ ��������� (Dependencies - Project Reference) �� ������ App
using App;
using System.Globalization;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
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


            {"VIVIVIVIV", 19},
            {"CXCXCXCXCX", 100},
            {"MCMCMCMCM", 1900},
            {"DXXXXX", 550},
            {"CCCCCV", 405},
            {"VVVVVV", 10},
            {"XCX", 90},
            {"XLXLXL", 60},
            {"DCCC", 800},
            {"CDCD", 400},
            {"MMMM", 4000},
            {"CCCL", 350},
            {"VVV", 15},
            {"IIIIV", 4},
            {"VIX", 9},
            {"IXI", 10},
            {"IIXX", 12},
            {"IXX", 19},
            {"DXDXDXDXDX", 450},
            {"DXDXDX", 390},
            {"IIXXIX", 21},
            {"XVIV", 18},
            {"XXVX", 25},
            {"XXXIV", 34},
            {"CCCVII", 307},
            {"CCCVIII", 308},
            {"CMXC", 990},
            {"XXII", 22},
            {"XXIV", 24},
            {"CCCXX", 320},
            {"CCCXL", 340},
            {"LXXX", 80},
            {"LXXXX", 90},
            {"VIIIIIIII", 9},
            {"IXVIII", 17},
            {"VXXXX", 45},
            {"VXXXXV", 50},
            {"XXXXI", 41},
            {"XXXXII", 42},
            {"XXXXIII", 43},
            {"XXXXIV", 44},
            {"XXXXVII", 47},
            {"XXXXVIII", 48},
            {"XCIX", 99},
            {"CICICICI", 297},
            {"MCM", 1900},
            {"DCLX", 660},
            {"MCMXC", 1990},
            {"MMMCM", 3900},
            {"XVIIIIX", 28},
            {"XVIIII", 19},
            {"XVXVXVXVX", 50},
            {"XVXVXVX", 40},
            {"IVIVIVI", 6},
            {"IIIIIIII", 8},
            {"IXV", 14},
            {"IXIX", 18},
            {"IIXX", 22},
            {"XIXX", 29},
            {"XDXDXDXDXD", 540},
            {"XDXDXDX", 440},
            {"VIIIV", 8},
            {"VIIIIX", 18},
            {"VVX", 10},
            {"VVIX", 19},
            {"XIIV", 6},
            {"XIVII", 12},
            {"XVVX", 15},
            {"XIVVX", 16},
            {"XVXII", 17},
            {"XVXIV", 19},
            {"XVXVXVXII", 27},
            {"XVXVXVXIV", 29},
            {"XVXVXVXVX", 30},
            {"XVVVVVV", 25},
            {"XVVVVV", 20},
            {"XIIII", 14},
            {"XVXVXV", 15},
            {"XVXVXVV", 21},
            {"XVXVXVVV", 24},
            {"XVXVXVVVV", 28},
            {"XVXVXVVVVV", 31},
            {"XVXVXVVVVVV", 35},
            {"XVXVXVVVVVVV", 38},
            {"XVXVXVVVVVVVV", 42},
            {"XVXVXVVVVVVVVV", 45},
            {"XVXVXVVVVVVVVVV", 49},
            {"XVXVXVVVVVVVVVVV", 52},
            {"XVXVXVVVVVVVVVVVV", 56},
            {"XVXVXVVVVVVVVVVVVV", 59},
            {"XVXVXVVVVVVVVVVVVVV", 63},
            {"XVXVXVVVVVVVVVVVVVVV", 66},
            {"XVXVXVVVVVVVVVVVVVVVV", 70},
            {"XVXVXVVVVVVVVVVVVVVVVV", 73},
            {"XVXVXVVVVVVVVVVVVVVVVVV", 77},
            {"XVXVXVVVVVVVVVVVVVVVVVVV", 80},
            {"XVXVXVVVVVVVVVVVVVVVVVVVV", 84},
            {"XVXVXVVVVVVVVVVVVVVVVVVVVV", 88},
            {"XVXVXVVVVVVVVVVVVVVVVVVVVVV", 92},
            {"XVXVXVVVVVVVVVVVVVVVVVVVVVVV", 96},
            {"XVXVXVVVVVVVVVVVVVVVVVVVVVVVV", 100}

        };
        [TestMethod]
        public void TestRomanNumberParse()
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
    }
}
/*  ������ ��������� ����� ��������� ���������� (Asserts).
 *  � ���������� ��������� ��� ��������: ��, �� ���������, ��
 *  ��, �� ����������.
 *  ��������� ����� ���������� ������ (��'����� AreSame �� ��������� AreEqual),
 *  ��� � ��������� ���� (IsTrue, IsNotNul, ....)
 */