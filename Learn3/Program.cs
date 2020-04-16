using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn3
{
    class Program
    {
        static void Main(string[] args)
        {
            int min;
            int max;
            int userNumber;
            //bool isNumber = int.TryParse(str, out num);
            int i = 0;
            bool isNumber;
            bool flag = false;
            string strmin;
            string strmax;

            do
            {
                Console.WriteLine("Введите минимальное число диапазона.");
                strmin = Console.ReadLine();
                flag = int.TryParse(strmin, out min);
                //Как выйти из программы, если попытка преобразовать строку в число не удалась?
            } while (flag == false);


            do
            {
                Console.WriteLine("Введите максимальное число диапазона.");
                strmax = Console.ReadLine();
                flag = int.TryParse(strmax, out max);
                //Как выйти из программы, если попытка преобразовать строку в число не удалась?
            } while (flag == false);


            Console.WriteLine("Кто будет загадывать число из диапазона. Если игрок, то введите 1, если копьютер -2");
            string strNumber = Console.ReadLine();

            if (strNumber == "2")
            {
                Random rnd = new Random();
                int compNumber = rnd.Next(min, max + 1);
            }

            

            int Attempt = CalculateAttempt(max + 1 - min);
            Console.WriteLine($"угадайте целое число от {min} до {max} включительно. У вас {Attempt} попыток.");


            do
            {
                Console.WriteLine("Введите искомое число.");
                Console.WriteLine($"Попытка {i + 1} из {Attempt} .");
                var str = Console.ReadLine();
                //userNumber = int.Parse(str);

                if (int.TryParse(str, out userNumber))
                {


                    if (compNumber > userNumber)
                    {
                        Console.WriteLine("больше");
                    }
                    else if (compNumber < userNumber)
                    {
                        Console.WriteLine("меньше");
                    }
                    i++;
                }
                else
                {
                    Console.WriteLine("not a number");
                }
            } while (userNumber != compNumber && i < Attempt);


            if (userNumber == compNumber)
            {
                Console.WriteLine($"Ты угадал. Это число {compNumber} . Попыток {i} из {Attempt} ");
            }
            else

            {
                Console.WriteLine($"Ты использовал все {Attempt} попыток.Искомое число {compNumber}. ");
            }


            Console.ReadLine();
        }

        static int CalculateAttempt(int lenght)
        {
            int number = 2;
            int i = 0;

            while (number < lenght)
            {
                number *= 2;
                i++;
            }

            return i;
        }
    }
}
