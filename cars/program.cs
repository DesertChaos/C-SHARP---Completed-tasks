using System;

class Program
{
    static void Main()
    {
        Avto[] cars = new Avto[3];
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i] = new Avto();
            cars[i].Info($"A{i + 1}23BC", 30 + i * 5, 7.5 + i);
        }

        Avto.SaveAllToFile(cars, "all_cars_data.txt");

        Avto[] loadedCars = Avto.LoadAllFromFile("all_cars_data.txt");

        Console.WriteLine("Загруженные машины:");
        foreach (var car in loadedCars)
        {
            car.Out();
            Console.WriteLine();
        }

        Console.WriteLine("Запуск машины");
        loadedCars[0].Zapravka(10);
        loadedCars[0].Razgon();
        loadedCars[0].Move(50);
        loadedCars[0].Tormozhenie();
        Avariya(loadedCars);
    }

    static void Avariya(Avto[] cars)
    {
        if (cars.Length < 2)
        {
            Console.WriteLine("Недостаточно машин для аварии");
            return;
        }

        Random rand = new Random();
        int index1 = rand.Next(cars.Length);
        int index2;
        do
        {
            index2 = rand.Next(cars.Length);
        } while (index2 == index1);

        Console.WriteLine($"\nАвария между машинами {cars[index1].Nomer} и {cars[index2].Nomer}!");
    }
}