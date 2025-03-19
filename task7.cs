using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x0, y0, v0;
            double a;
            Console.WriteLine("коорды пушки (x)");
            while (!int.TryParse(Console.ReadLine(), out x0)){
                Console.WriteLine("неправильно введены данные");
            }

            Console.WriteLine("коорды пушки (y) (y>=0)");
            while (!int.TryParse(Console.ReadLine(), out y0) | y0 < 0){
                Console.WriteLine("неправильно введены данные");
            }

            Console.WriteLine("Начальная скорость v0 (v0>=0)");
            while (!int.TryParse(Console.ReadLine(), out v0) | v0 < 0)
            {
                Console.WriteLine("неправильно введены данные");
            }

            Console.WriteLine("угол а (градусы)");
            while (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("неправильно введены данные");
            }
            a = (a * Math.PI) / 180;

            double vx0 = v0 * Math.Cos(a);
            double vy0 = v0 * Math.Sin(a);

            const double g = 9.81; // гравитацыыыыя 
            const double dt = 0.1; // шаг времени

            double x = x0, y = y0;
            double t = 0;
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"{"x", 10} | {"y", 10} | {"t", 10}");

            double yPrev = y; //запоманиаем еще и предыдущую итерацмю
            double tPrev = t; //очень важно на будущее

            double yMax = y; // это на будущее,
            double xMax = x; // чтобы запоминать
            double tMax = t; // макс. высоту

            while (true)
            {
                //вычисляем позицию
                x = x0 + vx0 * t;
                y = y0 + vy0 * t - ((g * Math.Pow(t, 2)) / 2);

                //проверяем поставили ли мы новый рекорд
                if (y > yMax)
                {
                    yMax = y;
                    xMax = x;
                    tMax = t;
                }

                //проверяем упал ли шар

                /* В предыдущей версии програмы
                 * шар либо недолетал часть t
                 * либо перелетал и оказывался под землей
                 * 
                 * неправильно
                 * теперь используя волшебнуя формулу из интернета можно расчитать точно время падения шара
                 * и его точную позицию
                 * 
                 * делаем мы это тольок если шар падает до 0 или ниже в текущей (или следуйщей итерации
                 * для чего полезно запоминать данные из предыдущей итерации)
                 */
                if (y < 0 && yPrev >= 0)
                {
                    
                    double tFall = tPrev + (t - tPrev) * (0 - yPrev) / (y - yPrev);
                    double xFall = x0 + vx0 * tFall;
                    Console.WriteLine($"{Math.Round(xFall, 2),10} | {0,10} | {Math.Round(tFall, 4),10}");

                    break; //ливаем
                }
                else if (y >= 0)
                {
                    Console.WriteLine($"{Math.Round(x, 2),10} | {Math.Round(y, 2),10} | {Math.Round(t, 1),10}");
                }

                yPrev = y;
                tPrev = t;
                t += dt; //dt = 0.1
            }

           
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Максимальная точка:");
            Console.WriteLine($"{"x",10} | {"y",10} | {"t",10}");
            Console.WriteLine($"{ Math.Round(xMax, 2),10} | { Math.Round(yMax, 2),10} | { Math.Round(tMax, 4),10}");
        }
    }
}
