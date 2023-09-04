// додпти залежність (Dependencies - Project Reference) від проєкту App
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
            {"IIII"  , 4  }, // Особливі твердження - з них ми визначаєио про
            {"IV"   , 4  },  // підтримку неоптимальних записів чи
            {"V"    , 5  },
            {"VI"   , 6  },
            {"VII"  , 7  },
            {"VIII" , 8  },
            {"IX"   , 9  },
            {"X"  , 10  },
            {"VV", 10 }, // ще одне наголошення неоптимальності
            {"IIIIIIIIII", 10 }, // ще одне наголошення неоптимальності
            {"VX", 5 }, // ще одне наголошення неоптимальності
            {"N",0 }, // Доповнюємо множину чисел нулем
            {"-L",-50 }, // вказуємо, що можливі від'ємні числа
            {"-XL",-40 },
            {"-IL",-49 }, // неоптимальність

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
                1,                         // Значення, що очікується( що має бути, правильний варіант)
                RomanNumber      // Актуальне значення (те, що вирахуване)
                            .Parse("I") //
                            .Value,      //
                "1 == I"                // Повідомлення, що з'явиться при провалі тесту
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
/*  Основу модельних тестів складають твердження (Asserts).
 *  У твердженны фыгурують два значення: те, що очікується, та
 *  те, що одержується.
 *  Більшість тестів перевіряють рівність (об'єктну AreSame чи контентну AreEqual),
 *  або у скороченій формі (IsTrue, IsNotNul, ....)
 */