Console.WriteLine("Введите имя");
string name = Console.ReadLine();
Console.WriteLine("Введите фамилию");
string surname = Console.ReadLine();

Console.WriteLine("Введите число месяца (от 1 до 31)");
int day = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите номер месяца (от 1 до 12)");
int monthNumber = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Ваше имя: {name}");
Console.WriteLine($"Ваша фамилия: {surname}");

/* Прежде чем критиковать следуйщий код прошу понять:
 * я не представляю как нормально сделать в свитчах 2 условия одновременно и документация вообще не помогает
 * я сделал то что выглядит прикольно и еще потому что было удобно нажимать ctrl+c ctrl+v
 * кодинг это исскуство
 * я художник я так вижу
 * я люблю писать комментарии, потому что чем больше строчек кода будет занимать мой проект
 * тем больше места он будет тратить.
 * а так как гитхаб бесплатно предоставляет облако для хранения моих проектов
 * это отличная возможность ударить по кошельку капиталистов
 * удар!
*/
if (day <= 0)
{
    Console.WriteLine("Неверно указана дата.");
}
else
{
    int totalDays = 0;
    switch (monthNumber)
    {
        case 1:
            totalDays = day;
            break;
        case 2:
            totalDays = 31 + day; //январь 31
            break;
        case 3:
            totalDays = 59 + day; //январь 31 + февраль 28
            break;
        case 4:
            totalDays = 90 + day; //31 + 28 + 31
            break;
        case 5:
            totalDays = 120 + day; // + ... + ... + ...
            break;
        case 6:
            totalDays = 151 + day; //великий калькулятор в помощь
            break;
        case 7:
            totalDays = 181 + day;
            break;
        case 8:
            totalDays = 212 + day;
            break;
        case 9:
            totalDays = 243 + day;
            break;
        case 10:
            totalDays = 273 + day;
            break;
        case 11:
            totalDays = 304 + day;
            break;
        case 12:
            totalDays = 334 + day;
            break;
        default:
            Console.WriteLine("Неверно указан месяц.");
            return;
    }

    if (totalDays > 365) //самая простая проверка
    {
        Console.WriteLine("Неверно указана дата. Количество дней превысило 365");
    }
    else if ((monthNumber == 1 | 
              monthNumber == 3 | 
              monthNumber == 5 | 
              monthNumber == 7 |
              monthNumber == 8 | 
              monthNumber == 10 | 
              monthNumber == 12) && day > 31){
        Console.WriteLine("Неверно указана дата: Слишком большой день для этого месяца."); 
    }
    else if ((monthNumber == 4 |
              monthNumber == 6 |
              monthNumber == 9 |
              monthNumber == 11) && day > 30)
    {
        Console.WriteLine("Неверно указана дата: Слишком большой день для этого месяца.");
    }
    else if (monthNumber == 2 && day == 29)
    {
        Console.WriteLine("Поздравляю, у вас самый редкий день рождений! Ну и ваш знак зодиака: Рыба");
        return; //прикольно что оно так работает
    }
    else if (monthNumber == 2 && day > 29)
    {
        Console.WriteLine("Неверно указана дата: Слишком большой день для этого месяца.");
        return;
    }
    //возможно эта проверка не самая умная и ее можно было сделать по другому, но я не хочу переделывать все то что я сделал со свитчами
    //ну и впринципе это выглядит забавно
    else
    {
        switch (totalDays)
        {
            case int n when n >= 1 && n <= 19:
                Console.WriteLine("Ваш знак зодиака: Козерог"); // te te te 
                break;
            case int n when n >= 20 && n <= 49:
                Console.WriteLine("Ваш знак зодиака: Водолей"); // te te teto 
                break;
            case int n when n >= 50 && n <= 79:
                Console.WriteLine("Ваш знак зодиака: Рыбы"); // te te te
                break;
            case int n when n >= 80 && n <= 110:
                Console.WriteLine("Ваш знак зодиака: Овен"); // te te teto 
                break;
            case int n when n >= 111 && n <= 140:
                Console.WriteLine("Ваш знак зодиака: Телец"); // te to kasane teto
                break;
            case int n when n >= 141 && n <= 170:
                Console.WriteLine("Ваш знак зодиака: Близнецы"); // te to kasane teto
                break;
            case int n when n >= 171 && n <= 203:
                Console.WriteLine("Ваш знак зодиака: Рак"); // mi mi mi
                break;
            case int n when n >= 204 && n <= 234:
                Console.WriteLine("Ваш знак зодиака: Лев"); // mi mi miku
                break;
            case int n when n >= 235 && n <= 265:
                Console.WriteLine("Ваш знак зодиака: Дева"); // mi mi mi
                break;
            case int n when n >= 266 && n <= 295:
                Console.WriteLine("Ваш знак зодиака: Весы"); // mi mi miku
                break;
            case int n when n >= 296 && n <= 325:
                Console.WriteLine("Ваш знак зодиака: Скорпион"); // miku hatsune miku
                break;
            case int n when n >= 326 && n <= 355:
                Console.WriteLine("Ваш знак зодиака: Стрелец"); // miku hatsune miku
                break;
            case int n when n >= 356 && n <= 365:
                Console.WriteLine("Ваш знак зодиака: Козерог"); // у меня нет проблем с головой
                break;
            default:
                Console.WriteLine("Ошибка 12345567890"); //много проверок не бывает. я вообще впринципе не знаю как ее получить, но почему бы и нет ¯\_(ツ)_/¯
                break;
        }
    }
}
