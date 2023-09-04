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
            {"DXCIV", 594},
            {"DXCIX", 599},
            {"CM", 900}



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