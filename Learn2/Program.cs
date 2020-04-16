using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn2
{
    class Program
    {
        static void Main(string[] args)
        {
            int attemtCounter = 0;

            int min = GetNumberFromConsole("Введите минимальное число диапазона");
            int max = GetNumberFromConsole("Введите максимальное число диапазона", minValue: min);

            int compNumber = GetMagicNumber(min, max); //написать эту функцию
            
            int maxAttempt = CalculateAttempt(max + 1 - min);

            int userNumber;

            do
            {
                userNumber = GetNumberFromConsole(
                    $"Введите искомое число  от {min} до {max} \r\n Попытка {attemtCounter + 1} из {maxAttempt}",
                    "not a number",
                    min,
                    max);


                if (compNumber > userNumber)
                {
                    Console.WriteLine("больше");
                    min = userNumber + 1;
                }
                else if (compNumber < userNumber)
                {
                    Console.WriteLine("меньше");
                    max = userNumber - 1;

                }
                attemtCounter++;
            } while (userNumber != compNumber && attemtCounter < maxAttempt);


            if (userNumber == compNumber)
            {
                Console.WriteLine($"Ты угадал. Это число {compNumber} . Попыток {attemtCounter} из {maxAttempt} ");
            }
            else

            {
                Console.WriteLine($"Ты использовал все {maxAttempt} попыток.Искомое число {compNumber}. ");
            }


            Console.ReadLine();
        }

        static int GetNumberFromConsole(
            string tipForUser,
            string errorMessge = "Error try agein",
            int? minValue = null,
            int? maxValue = null)
        {
            string str = "";
            int number;
            bool isValidValue;
            
            do
            {
                Console.WriteLine(tipForUser);
                str = Console.ReadLine();
                
                bool isNumber = int.TryParse(str, out number);
                
                bool minHaValue = minValue.HasValue;
                bool less = number < minValue;

                bool maxHaValue = maxValue.HasValue;
                bool more = number > maxValue;

                isValidValue = 
                    isNumber 
                    && (!minHaValue || less) 
                    && (!maxHaValue || more);

                
                if (!isValidValue)
                {
                    Console.WriteLine(errorMessge);
                }
            } while (!isValidValue);

            return number;
        }


        static int GetMagicNumber (int minValue, int maxValue)
        {
            int Number;
            bool isNumber;
            string strNum;
            string str;
            bool validCondition;

            do
            {

                Console.WriteLine("Кто будет загадывать число? Если игрок, то нажмите 1, если компьютер - нажмите 2");
                str = Console.ReadLine();

            } while (str != "1" || str != "2");

            
            if (str == "1")
            {
                do
                {
                    Console.WriteLine($"Загадайте число от {minValue} до {maxValue}");
                    strNum = Console.ReadLine();
                    isNumber = int.TryParse(strNum, out Number);

                    validCondition = (Number >= minValue) && (Number <= maxValue);

                } while (!validCondition); 

                Console.Clear();
                return Number;
            }
            else 
            {

                Random rnd = new Random();
                Number = rnd.Next(minValue, maxValue + 1);
                return Number;
            }


        }
        static int CalculateAttempt(int lenght)
        {
            int number = 2;
            int i = 1;

            while (number < lenght)
            {
                number *= 2;
                i++;
            }

            return i;
        }
    }
}
