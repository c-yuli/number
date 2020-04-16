using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn4
{
    public class GameRoom
    {
        public GameRule gameRule; //почему объявление и нет создания объекта при помощи new?
        int attemtCounter = 0;
        int userNumber;

        public int Play(string str)
        {
            Start(str);
            
            PlayRounds();
                                       
            return EndGame();

        }

        private void Start(string str)
        {
            gameRule = new GameRule(str);

        }

        private void PlayRounds()
        {
            do {

                userNumber = Program.GetNumberFromConsole(
                        $"Введите искомое число  от {gameRule.MinValue} до {gameRule.MaxValue} \r\n " +
                        $"Попытка {attemtCounter + 1} из {gameRule.MaxAttempt}",
                        "Вы ввели недопустимое число или символ", gameRule.MinValue, gameRule.MaxValue);


                if (gameRule.MagicNumber > userNumber)
                {
                    Console.WriteLine("больше");
                    gameRule.MinValue = userNumber + 1;
                }
                else if (gameRule.MagicNumber < userNumber)
                {
                    Console.WriteLine("меньше");
                    gameRule.MaxValue = userNumber - 1;

                }
                attemtCounter++;

            } while (userNumber != gameRule.MagicNumber && attemtCounter < gameRule.MaxAttempt);
        }

        private int EndGame()
        {
            if (userNumber == gameRule.MagicNumber)
            {
                Console.WriteLine($"Вы угадали. Это число {gameRule.MagicNumber} . Попыток {attemtCounter} из {gameRule.MaxAttempt} ");
                return gameRule.MaxAttempt - attemtCounter;
            }
            else
            {
                Console.WriteLine($"Вы использовали все {gameRule.MaxAttempt} попыток.Искомое число {gameRule.MagicNumber}. ");
                return 0;
            }

        }

    }
}
