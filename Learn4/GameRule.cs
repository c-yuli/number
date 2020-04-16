using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn4
{
    public class GameRule
    {
        public int MinValue;
        public int MaxValue;
        public int MagicNumber;
        public int MaxAttempt;

        public GameRule(string str)
        {
            MinValue = Program.GetNumberFromConsole("Введите минимальное число диапазона");
            MaxValue = Program.GetNumberFromConsole("Введите максимальное число диапазона", minValue: MinValue);
            CalculateMagicNumber(str); 
            CalculateAttempt();
        }

        /// <summary>
        /// Возвращает загаданное игроком или копьютером число из заданного диапозона (min - max)
        /// </summary>
        private void CalculateAttempt()
        {
            int length = MaxValue + 1 - MinValue;
            int number = 2;
            int i = 1;

            while (number < length)
            {
                number *= 2;
                i++;
            }

            MaxAttempt = i;
        }

        /// <summary>
        /// Вычисляет и заполняет проеперти MagicNumber
        /// </summary>
        private void CalculateMagicNumber(string str)
        {
            //string str;

            /*do
            {
                Console.WriteLine("Кто будет загадывать число? Если игрок, то нажмите 1, если компьютер - нажмите 2");
                str = Console.ReadLine();
            } while (str != "1" && str != "2");
            */

            if (str == "2")
            {
                GamerSetMagicNumber();
            }
            if (str == "3")
            {
                CompSetMagicNumber();
            }
        }
        
        private void CompSetMagicNumber()
        {
            Random rnd = new Random();
            MagicNumber = rnd.Next(MinValue, MaxValue + 1);
        }

        private void GamerSetMagicNumber()
        {
            int number;
            bool validCondition;

            do
            {
                Console.WriteLine($"Загадайте число от {MinValue} до {MaxValue}");
                var strNum = Console.ReadLine();
                bool isNumber = int.TryParse(strNum, out number);

                validCondition =
                    isNumber
                    && number >= MinValue
                    && number <= MaxValue; //уточнить
            } while (!validCondition); //уточнить

            Console.Clear();
            MagicNumber = number;
        }
    }
}
