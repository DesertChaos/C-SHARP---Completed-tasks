using System.Numerics;

namespace NumberConverter
{
    internal class Program
    {
        public static int RestartCount = 0, InputErrorCount = 0;
        static void Main()
        {
            string? input;
            int InputNum, InputNumSystem, OutputNumSystem;

            Console.Title = "Конвертатор числе из разных систем счисления";
            goto Start;

        Exit:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Намжите любую кнопку для завершения");
            Console.ForegroundColor = ConsoleColor.Black;
            Environment.Exit(0);

        Restart:
            Console.Clear();
            RestartCount++;

            Console.ForegroundColor = ConsoleColor.Red;
            if (InputErrorCount != 0)
            {
                Console.WriteLine($" Данные введены неверно {InputErrorCount} раз(а)");
            }
            Console.WriteLine($" Программа перезапущена {RestartCount} раз(а)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('-', 10));
            

        Start:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Программа переводит число N из X системы счисления в Y систему счисления.");
            Console.WriteLine("Вы вводите все три числа.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ограничения:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Система счисления: от 2 до 9.");
            Console.WriteLine("Число: входит в ограничения int32.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Введите ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("restart ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("в любой момент, чтобы перезапустить программу.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Введите ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("exit ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("в любой момент, чтобы остановить программу.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('-', 10));

        InputOne:

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Введите систему счисления вводимого числа: ");
            Console.ForegroundColor = ConsoleColor.White;
            input = Console.ReadLine();
            if (input.Equals("restart", StringComparison.OrdinalIgnoreCase)) { goto Restart; }
            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase)) {  goto Exit; }
            if (!BigInteger.TryParse(input, out BigInteger temp))
            {
                InputErrorCount++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Данные введены неверно. Повторите ввод.");
                Console.ForegroundColor = ConsoleColor.White;
                goto InputOne;
            }
            if (temp < int.MinValue || temp > int.MaxValue)
            {
                InputErrorCount++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Число находится вне диапазона int32. Повторите ввод.");
                Console.ForegroundColor = ConsoleColor.White;
                goto InputOne;
            }
            InputNumSystem = (int)temp;
            if (InputNumSystem < 2 | InputNumSystem > 9)
            {
                InputErrorCount++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Система счисления должна быть в диапазоне от 2 до 9.");
                Console.ForegroundColor = ConsoleColor.White;
                goto InputOne;
            }

        InputTwo:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Введите число: ");
            Console.ForegroundColor = ConsoleColor.White;
            input = Console.ReadLine();
            if (input.Equals("restart", StringComparison.OrdinalIgnoreCase)) { goto Restart; }
            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase)) {  goto Exit; }
            if (!BigInteger.TryParse(input, out temp))
            {
                InputErrorCount++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Данные введены неверно. Повторите ввод.");
                Console.ForegroundColor = ConsoleColor.White;
                goto InputTwo;
            }
            if (temp < int.MinValue || temp > int.MaxValue)
            {
                InputErrorCount++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Число находится вне диапазона int32. Повторите ввод.");
                Console.ForegroundColor = ConsoleColor.White;
                goto InputTwo;
            }
            InputNum = (int)temp;
            if (!IsValidNumber(InputNum, InputNumSystem))
            {
                InputErrorCount++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Число не может существовать в указанной системе счисления. Повторите ввод.");
                Console.ForegroundColor = ConsoleColor.White;
                goto InputTwo;
            }

        InputThree:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Введите систему счисления в которую необходимо перевести: ");
            Console.ForegroundColor = ConsoleColor.White;
            input = Console.ReadLine();
            if (input.Equals("restart", StringComparison.OrdinalIgnoreCase)) { goto Restart; }
            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase)) {  goto Exit; }
            if (!BigInteger.TryParse(input, out temp))
            {
                InputErrorCount++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Данные введены неверно. Повторите ввод.");
                Console.ForegroundColor = ConsoleColor.White;
                goto InputThree;
            }
            if (temp < int.MinValue || temp > int.MaxValue)
            {
                InputErrorCount++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Число находится вне диапазона int32. Повторите ввод.");
                Console.ForegroundColor = ConsoleColor.White;
                goto InputThree;
            }
            OutputNumSystem = (int)temp;
            if (InputNumSystem < 2 | InputNumSystem > 9)
            {
                InputErrorCount++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Система счисления должна быть в диапазоне от 2 до 9.");
                Console.ForegroundColor = ConsoleColor.White;
                goto InputThree;
            }

            ConvertNumber(InputNum, InputNumSystem, OutputNumSystem);
        }

        static bool IsValidNumber(int InputNum, int InputNumSystem)
        {
            string NumString = InputNum.ToString();
            int length = NumString.Length;
            int j = 0;
            if (InputNum < 0)
            {
                j++;
                length -= 1;
            }

            for (int i = j; i < length; i++)
            {
                int digit = int.Parse(NumString[i].ToString());
                if (digit >= InputNumSystem)
                {
                    return false;
                }
            }

            return true;
        }

        static void ConvertNumber(int InputNum, int InputNumSystem, int OutputNumSystem)
        {
            long OutputNum;
            string sign;
            if (InputNum < 0) { sign = "-"; } else { sign = ""; }
            
            string NumString = Math.Abs(InputNum).ToString();
            int DecimalNum = 0;
            for (int i = 0; i < NumString.Length; i++)
            {
                DecimalNum += int.Parse(NumString[NumString.Length - i - 1].ToString()) * (int)Math.Pow(InputNumSystem, i);
            }

            string OutputString = "";
            OutputNum = DecimalNum;
            while (OutputNum != 0)
            {
                OutputString = Convert.ToString(Math.Abs(OutputNum) % OutputNumSystem) + OutputString;
                OutputNum /= OutputNumSystem;
            }

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" Данные введены неверно {InputErrorCount} раз(а)");
            Console.WriteLine($" Программа перезапущена {RestartCount} раз(а)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('-', 10));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Программа завершила работу.");

            Console.Write($"Число ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{InputNum} ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"в ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{InputNumSystem} ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"системе счисления = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{sign}{OutputString} ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"в ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{OutputNumSystem} ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"системе счисления.");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('-', 10));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Нажмите любую клавишу, чтобы перезапустить программу.");

            Console.ReadKey();
            Console.Clear();
            RestartCount++;
            Main();
        }
    }
}
