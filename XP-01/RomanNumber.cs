using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class RomanNumber
    {
        public int Value { get; set; } = 0;
        public static RomanNumber Parse(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("NULL or empty input");
            }
            int result = 0;
            input = input.ToUpper();
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input exception", new Exception());
            }
            if (input == "N") return new(); // Value = 0 --default
            int prev = 0;
            int current = 0;
            int lastDigitIndex = input[0] == '-' ? 1 : 0;
            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                current = input[i] switch
                {
                    'I' => 1,
                    'V' => 5,
                    'X' => 10,
                    'L' => 50,
                    'C'=>100,
                    'D'=>500,
                    'M'=>1000
                };
                result += prev > current ? -current : current;
                prev = current;
            }
            return new() { Value = lastDigitIndex == 1 ? result * -1 : result };

            #region Ideas
            //Value=input.Length для тестів "І", "ІІ", "ІІІ"
            /* input switch варіант для тестів "І", "ІІ", "ІІІ"
             * Value = input switch
            {
                "I" => 1,
                "II" => 2,
                _ => 3,
            }*/

            // input == "I" ? 1 : 2 для тестів "І", "ІІ"
            // =1 для тесту "І"
            #endregion
        }
        /*  Правило "читання римських чисел:
         *  Якщо цифра передує
         *  більшій цифрі, то вона віднімається (IV, IX) — "І" передує більшій цифрі
         *  меньшій або рівній — додається(VІ,ІІ,ХІ)
         *  Решту правил ігноруємо — робимо максимально "дружній" інтерфейс
         *  
         *  Алгоритм — "заходимо" з правої цифрі, її завжди додаємо, запам'ятовуємо, і далі порівнюжмо з наступною цифрою
         */
    }
}
