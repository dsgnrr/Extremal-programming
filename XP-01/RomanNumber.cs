using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class RomanNumber
    {
        public RomanNumber(int value = 0)
        {
            this.Value = value;
        }
        public int Value { get; set; } = 0;
        public static RomanNumber Parse(string input)
        {
            input = input?.Trim()!;
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("NULL or empty input");
            }

            if (input == "N")
            {
                return new();  // Value = 0 --default
            }
            int lastDigitIndex = input[0] == '-' ? 1 : 0;

            int maxDigit = 0;
            int lessDigitsCount = 0;

            
            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                int digitValue = DigitValue(input[i]);
                if (digitValue < maxDigit)
                {
                    lessDigitsCount += 1;
                    if (lessDigitsCount > 1)
                    {
                        throw new ArgumentException($"Invalid Roman digit: '{input[i]}'");
                    }
                }
                else
                {
                    maxDigit = digitValue;
                    lessDigitsCount = 0;
                }
            }


            int result = 0;
            int prev = 0, current = 0;

            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                current = input[i] switch
                {
                    'N' => 0,
                    'I' => 1,
                    'V' => 5,
                    'X' => 10,
                    'L' => 50,
                    'C' => 100,
                    'D' => 500,
                    'M' => 1000,
                    _ => throw new ArgumentException($"Invalid Roman digit: '{input[i]}'")
                };
                result += prev > current ? -current : current;
                prev = current;
            }
            return new() { Value = lastDigitIndex == 1 ? result * -1 : result };

            /*  Правило "читання римських чисел:
    *  Якщо цифра передує
    *  більшій цифрі, то вона віднімається (IV, IX) — "І" передує більшій цифрі
    *  меньшій або рівній — додається(VІ,ІІ,ХІ)
    *  Решту правил ігноруємо — робимо максимально "дружній" інтерфейс
    *  
    *  Алгоритм — "заходимо" з правої цифрі, її завжди додаємо, запам'ятовуємо, і далі порівнюжмо з наступною цифрою
    */

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

        public override string ToString()
        {
            //  відобразити значення Value у формі римського 
            // головна ідея - послідовне зменшення початкового числа i
            // формування результату
            Dictionary<int, string> parts = new()
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" }
            };
            if (Value == 0) return "N";
            bool isNegative = Value < 0;

            var number = isNegative ? -Value : Value;
            StringBuilder sb = new();
            if (isNegative) sb.Append("-");
            foreach (var part in parts)
            {
                while (number >= part.Key)
                {
                    sb.Append(part.Value);
                    number -= part.Key;
                }
            }
            return sb.ToString();
        }
        //return "I";
        private static int DigitValue(char digit)
        {
            return digit switch
            {
                'N' => 0,
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new ArgumentException($"Invalid Roman digit: '{digit}'")
            };

        }

    }
}
