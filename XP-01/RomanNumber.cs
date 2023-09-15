using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public record RomanNumber
    {
        private const char ZERO_DIGIT = 'N';
        private const char MINUS_SIGN = '-';
        private const char DIGIT_QOUTE = '\'';
        private const String INVALID_DIGIT_MESSAGE = "Invalid Roman digit(s):";
        private const String EMPTY_INPUT_MESSAGE= "NULL or empty input";
        private const String DIGITS_SEPARATOR = ", ";
        private const String ADD_NULL_MESSAGE = "Cannot Add null object";
        private const String NULL_MESSAGE_PATTERN = "{0}: '{1}'";
        public RomanNumber(int value = 0)
        {
            this.Value = value;
        }
        public int Value { get; set; } = 0;
        public static RomanNumber Parse(string input)
        {
            input = input?.Trim()!;

            CheckValidityOrThrow(input);
            CheckLegalityOrThrow(input);

            if (input == ZERO_DIGIT.ToString())
            {
                return new();  // Value = 0 --default
            }
            int lastDigitIndex = input[0] == MINUS_SIGN ? 1 : 0;
            int result = 0;
            int prev = 0, current = 0;

            
            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                current = DigitValue(input[i]);
                result += prev > current ? -current : current;
                prev = current;

            }
            
/*for (int i = input.Length - 1; i >= lastDigitIndex; i--)
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
            }*/
          /*for (int i = input.Length - 1; i >= lastDigitIndex; i--)
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
                                //_ => throw new ArgumentException($"Invalid Roman digit: '{input[i]}'")
                                // із зміною вимог - залишити у повідомленні усі неправильні символи
                               // try{


                            };
                            result += prev > current ? -current : current;
                            prev = current;
                        }*/
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
            if (Value == 0) 
            {
                return ZERO_DIGIT.ToString();
            }
            bool isNegative = Value < 0;

            var number = isNegative ? -Value : Value;
            StringBuilder sb = new();
            if (isNegative) 
            { 
                sb.Append(MINUS_SIGN); 
            }

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
                ZERO_DIGIT => 0,
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new ArgumentException($"{INVALID_DIGIT_MESSAGE} '{digit}'")
            };

        }

        private static void CheckValidityOrThrow(String input)
        {
            // із зміною вимог - залишити у повідомленні усі неправильні символи
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(EMPTY_INPUT_MESSAGE);
            }
            if (input.StartsWith('-'))
            {
                input = input[1..];
            }
            List<char> invalidChars = new();
            foreach (char c in input)
            {
                try { DigitValue(c); }
                catch{ invalidChars.Add(c); }
            }
            if (invalidChars.Count > 0)
            {
                String chars = String.Join(DIGITS_SEPARATOR, invalidChars.Select(c => $"{DIGIT_QOUTE}{c}{DIGIT_QOUTE}"));
                throw new ArgumentException($"{INVALID_DIGIT_MESSAGE} {chars}");
            }
        }

        private static void CheckLegalityOrThrow(String input)
        {

            // тест на легальність - лівіше цифри може бути лише одна
            // цифоа, що є меншою за дану (див. TestRomanNumberParseIllegal()
            // if (input == "IIX" || input == "IIV")
            if (string.IsNullOrEmpty(input)) { throw new ArgumentException(input); }
            int maxDigit = 0;
            int lessDigitsCount = 0;
            int lastDigitIndex = input[0] == '-' ? 1 : 0;
            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                int digitValue = DigitValue(input[i]);
                if (digitValue < maxDigit)
                {
                    lessDigitsCount += 1;
                    if (lessDigitsCount > 1)
                    {
                        throw new ArgumentException(input);
                    }
                }
                else
                {
                    maxDigit = digitValue;
                    lessDigitsCount = 0;
                }
            }
        }

        public RomanNumber Add(RomanNumber other)
        {
            if(other is null)
            {
                throw new ArgumentNullException(
                    String.Format(
                        NULL_MESSAGE_PATTERN,   // "{0}: {1}"
                        ADD_NULL_MESSAGE,       // ->0
                        nameof(other)           //      ->1
                        )
                    );
            }
            return this with { Value=this.Value + other.Value }; // new(this.Value+other.Value);
            // клонування зі змінами this with { } - повне клонування
            // this with { x = 10 } - х змінюється, а все інше - копіюється
        }
        public static RomanNumber Sum(params RomanNumber[] romNumbers)
        {
            int result = 0;
            foreach(var romanNumber in romNumbers)
            {
                result += romanNumber.Value;
            }
            return new(result);
        }
    }
}
