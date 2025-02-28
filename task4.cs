namespace vert_cool_code
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите параметры функции a, b, h");
            Console.WriteLine("где a,b - границы функции, h - шаг функции");

            int a, b, h, function_change = 0;
            double min_y = 10, max_y = -10, y_prev = 12345;

            while (true)
            {
                Console.Write("Введите значение a: ");
                if (int.TryParse(Console.ReadLine(), out a))
                    break;
                Console.WriteLine("Неправильный формат. Повторите ввод.");
            }
            while (true)
            {
                Console.Write("Введите значение b: ");
                if (int.TryParse(Console.ReadLine(), out b))
                    break;
                Console.WriteLine("Неправильный формат. Повторите ввод.");
            }
            while (true)
            {
                Console.Write("Введите значение h: ");
                if (int.TryParse(Console.ReadLine(), out h) && h != 0)
                    break;
                Console.WriteLine("Неправильный формат или нулевое значение. Повторите ввод.");
            }

            for (int x = a; x < (b + h); x += h)
            {
                double y = Math.Round((Math.Cos(Math.Pow(x, 2)) + Math.Pow(Math.Sin(x), 2)), 2);

                if (y > max_y) { max_y = y; }
                if (y < min_y) { min_y = y; }

                Console.WriteLine($"{x} | {y}");

                if (y_prev != 12345 && y_prev * y < 0) { function_change++; }
                y_prev = y;
            }

            Console.WriteLine($"Максимальное значение функции = {max_y} | Минимальное значение функции = {min_y}.");
            Console.WriteLine($"Функиця пересекала ось х {function_change} раз(а).");
        }
    }
}
