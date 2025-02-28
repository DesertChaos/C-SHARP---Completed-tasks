using System;

namespace ya_ne_pomnu_kakaya_po_chetu_zadacha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Number;
            int NumSystem;

            while (true)
            {
                Console.WriteLine("Введите сначала число, потом систему счисления числа");
                if (int.TryParse(Console.ReadLine(), out Number) && int.TryParse(Console.ReadLine(), out NumSystem))
                {
                    if (NumSystem >= 2 && NumSystem <= 9)
                    {
                        if (IsValidNumberInSystem(Number, NumSystem))
                        {
                            ConvertToDecimal(Number, NumSystem);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("В числе есть цифры, не соответствующие выбранной системе счисления");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Система счисления должна быть от 2 до 9");
                    }
                }
                else
                {
                    Console.WriteLine("Были неверно введены данные");
                }
            }
        }

        static bool IsValidNumberInSystem(int Number, int NumSystem)
        {
            string numStr = Number.ToString();
            int length = numStr.Length;

            for (int i = 0; i < length; i++)
            {
                int digit = int.Parse(numStr[i].ToString());
                if (digit >= NumSystem)
                {
                    return false;
                }
            }

            return true;
        }

        static void ConvertToDecimal(int Number, int NumSystem)
        {
            string numStr = Number.ToString();
            int Result = 0;
            int length = numStr.Length;

            for (int i = 0; i < length; i++)
            {
                int digit = int.Parse(numStr[length - i - 1].ToString());
                Result += digit * (int)Math.Pow(NumSystem, i);
            }

            Console.WriteLine($"Число {Number} в {NumSystem} системе счисления = {Result} в 10 системе счисления");
        }
    }
}
