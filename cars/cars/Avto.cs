using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars
{

    public class Avto
    {
        public string Name { get; set; }
        public int TankCapacity { get; set; }
        public double FuelLevel { get; set; }
        public double FuelConsumption { get; set; }
        public double Mileage { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int Speed { get; set; }
        public int MaxSpeed { get; set; }

        public Avto(string name, int tankCapacity, double fuelLevel, double fuelConsumption, double mileage, double x, double y, int maxSpeed)
        {
            Name = name;
            TankCapacity = tankCapacity;
            FuelLevel = fuelLevel;
            FuelConsumption = fuelConsumption;
            Mileage = mileage;
            X = x;
            Y = y;
            MaxSpeed = maxSpeed;
            Speed = 0;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Номер машины: {Name}");
            Console.WriteLine($"Кординаты: x:{X} y:{Y}");
            Console.WriteLine($"Скорость: {Speed}");
            Console.WriteLine($"Расход топлива: {FuelConsumption}");
            Console.WriteLine($"Топливо: {FuelLevel}/{TankCapacity}");
            Console.WriteLine($"Пробег: {Mileage}");
        }

        public void MoveTo(double newX, double newY)
        {
            if (Speed == 0)
            {
                Console.WriteLine("Машина не движется. Нельзя переместиться.");
                return;
            }

            double distance = Math.Sqrt(Math.Pow(newX - X, 2) + Math.Pow(newY - Y, 2));
            double fuelConsumed = (distance / 100) * FuelConsumption;

            if (FuelLevel >= fuelConsumed)
            {
                Console.WriteLine($"Перемещение на расстояние {distance} км потребует {fuelConsumed} литров топлива.");
                Console.Write("Продолжить? (да/нет): ");
                string answer = Console.ReadLine();

                if (answer.ToLower() == "да")
                {
                    FuelLevel -= fuelConsumed;
                    X = newX;
                    Y = newY;
                    Mileage += distance;
                    Console.WriteLine($"Машина переместилась в координаты x:{X} y:{Y}");
                }
                else
                {
                    Console.WriteLine("Перемещение отменено.");
                }
            }
            else
            {
                Console.WriteLine($"Недостаточно топлива. (Требуется {fuelConsumed}/ Осталось {FuelLevel})");
            }
        }

        public void Refuel()
        {
            Console.WriteLine($"Текущий уровень топлива: {FuelLevel}/{TankCapacity}");
            Console.Write("На сколько дозаправить: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out double amount))
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Некорректный ввод. (Недопустимое количество топлива)");
                }
                else if (FuelLevel + amount > TankCapacity)
                {
                    Console.WriteLine("Некорректный ввод. (Бак переполнится)");
                }
                else
                {
                    FuelLevel += amount;
                    Console.WriteLine($"Машина заправлена. Текущий уровень топлива: {FuelLevel}/{TankCapacity}");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }

        public void Accelerate()
        {
            if (Speed < MaxSpeed)
            {
                Speed += 10;
                Console.WriteLine($"Скорость увеличена до {Speed} км/ч");
            }
            else
            {
                Console.WriteLine("Максимальная скорость достигнута.");
            }
        }

        public void Brake()
        {
            if (Speed > 0)
            {
                Speed -= 10;
                if (Speed < 0) Speed = 0;
                Console.WriteLine($"Скорость уменьшена до {Speed} км/ч");
            }
            else
            {
                Console.WriteLine("Машина уже стоит на месте.");
            }
        }

        public static void CheckCrash(Avto avto, List<Avto> avtos)
        {
            foreach (var otherAvto in avtos)
            {
                if (otherAvto != avto && otherAvto.X == avto.X && otherAvto.Y == avto.Y)
                {
                    Console.WriteLine($"Авария! Машина {avto.Name} столкнулась с машиной {otherAvto.Name}.");
                    Console.WriteLine("Обе машины были перемещены в координаты x: 0 y: 0");
                    avto.X = 0;
                    avto.Y = 0;
                    otherAvto.X = 0;
                    otherAvto.Y = 0;
                }
            }
        }
    }
}
