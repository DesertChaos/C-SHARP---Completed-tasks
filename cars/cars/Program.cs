using System.Xml.Linq;

namespace cars
{
    class Program
    {
        static List<Avto> avtos = new List<Avto>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Создать новую машину");
                Console.WriteLine("2. Выбрать машину");
                Console.WriteLine("3. Выйти");

                Console.Write("Введите номер действия: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateAvto();
                        break;
                    case "2":
                        ChooseAvto();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }
            }
        }

        static void CreateAvto()
        {
            Console.Write("Введите имя машины: ");
            string name = Console.ReadLine();

            Console.Write("Введите емкость бака: ");
            int tankCapacity = int.Parse(Console.ReadLine());

            Console.Write("Введите расход топлива: ");
            double fuelConsumption = double.Parse(Console.ReadLine());

            Console.Write("Введите максимальную скорость: ");
            int maxSpeed = int.Parse(Console.ReadLine());

            Avto avto = new Avto(name, tankCapacity, 0, fuelConsumption, 0, 0, 0, maxSpeed);
            avtos.Add(avto);

            Console.WriteLine("Машина создана.");
        }

        static void ChooseAvto()
        {
            if (avtos.Count == 0)
            {
                Console.WriteLine("Нет машин.");
                return;
            }

            Console.WriteLine("Список машин:");
            for (int i = 0; i < avtos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {avtos[i].Name}");
            }

            Console.Write("Введите номер машины: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int index) && index > 0 && index <= avtos.Count)
            {
                Avto avto = avtos[index - 1];

                Console.Clear();
                
                Console.WriteLine($"Вы в машине {avto.Name}");
                Console.WriteLine($"Кординаты: x:{avto.X} y:{avto.Y}");
                Console.WriteLine($"Скорость: {avto.Speed}");
                Console.WriteLine($"Топливо: {avto.FuelLevel}/{avto.TankCapacity}");

                while (true)
                {
                    Console.WriteLine("Меню машины:");
                    Console.WriteLine("1. Вывести информацию");
                    Console.WriteLine("2. Переместить");
                    Console.WriteLine("3. Дозаправить");
                    Console.WriteLine("4. Разогнать");
                    Console.WriteLine("5. Тормозить");
                    Console.WriteLine("6. Назад");

                    Console.Write("Введите номер действия: ");
                    string action = Console.ReadLine();

                    switch (action)
                    {
                        case "1":
                            Console.Clear();
                            avto.PrintInfo();
                            break;
                        case "2":
                            Console.Clear();
                            Console.Write("Введите координату X, в которую вы хотите переместить машину: ");
                            string xInput = Console.ReadLine();
                            if (double.TryParse(xInput, out double newX))
                            {
                                Console.Write("Введите координату Y, в которую вы хотите переместить машину: ");
                                string yInput = Console.ReadLine();
                                if (double.TryParse(yInput, out double newY))
                                {
                                    avto.MoveTo(newX, newY);
                                    Avto.CheckCrash(avto, avtos);
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод координаты Y.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ввод координаты X.");
                            }
                            break;
                        case "3":
                            Console.Clear();
                            avto.Refuel();
                            break;
                        case "4":
                            Console.Clear();
                            avto.Accelerate();
                            break;
                        case "5":
                            Console.Clear();
                            avto.Brake();
                            break;
                        case "6":
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Некорректный ввод.");
                            break;
                    }
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }
    }
}
