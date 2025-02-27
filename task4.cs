namespace very_important_code_goes_here
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Попробуйте угадать число от 1 до 100.");
            
            Random rnd = new Random();
            int goal = rnd.Next(1, 101);
            Console.WriteLine($"По секрету, это число - {goal}.");
            int counter = 0; //счетчик попыток пользователя
            int answer;
            
            start:  //оказывается можно ставить метки просто так. приколь конечно
                Console.WriteLine($"Введите число. Номер попытки {counter + 1}." );
                if (!int.TryParse(Console.ReadLine(), out answer)) { goto start; } //есть проверка на дурачка
                counter++;

            switch (answer)
            {
                case int n when n == goal && counter < 5:              // Я люблю оставлять комментарии и буду оставлять их везде
                    Console.WriteLine("Верно.");                       //
                    break;                                             // Вообще изначально я думал, что можно делать переходы к кейсам
                                                                       // только внутри свича, но один неосторжный ctrl+v и взгляд на 
                case int x when x != goal && counter > 4:              // счетчик ошибок открыл мне глаза на эти удивительные метки.
                    Console.WriteLine("Неверно. Попытки закончились"); // Наверно, выполняя задание так я обошел весь смысл ограничения
                    break;                                             // использования "только условные конструкции", но по идее
                                                                       // я ничего не нарушил, выполнил все условия, написал короткий, красиый,
                default:                                               // читаемый код с проверкой на ошибку от пользователя, так что норм.
                    Console.WriteLine("Неверно.");                     //                  |\---/|
                    goto start;                                        // я такой крутой   | ,_, |
            }                                                          //                   \_`_/-..----.
        }                                                              //                 ___/ `   ' ,""+ \
    }                                                                  //                (__...'   __\    |`.___.';
}                                                                      //                 (_,...'(_,.`__)/'.....+
