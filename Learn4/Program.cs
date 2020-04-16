using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Learn4
{
    class Program
    {
        const string Path = "test.txt";
        
        //test
        static void Main(string[] args)
        {
            User user = new User();
            int indexUser;
            string str;
            List<User> users;

            do
            {

                users = ReadAllUsers();
                user.SetLogin();
                indexUser = GetUserIndex(user, users); //если игрок с таким логином существует - возращает его индекс в массиве

                if (indexUser == -1) //если игрока c таким логином нет массиве
                {
                    Console.WriteLine($"Игрок с логином {user.Login} не существует.");
                    Console.WriteLine($"Для создания игрока с логином {user.Login} нажмите 1, для повторного ввода логина - ввод");
                    str = Console.ReadLine();

                    if (str == "1")
                    {
                        user.SetPass();
                        CreateUser(user);
                        users = ReadAllUsers();
                        indexUser = GetUserIndex(user, users);
                        Console.WriteLine($"{user.Login}, добро пожаловать в игру!");
                    }
                }

                else
                {
                    do
                    {
                        user.SetPass();
                        if (user.Password != users[indexUser].Password)
                        {
                            Console.WriteLine($"Неверный пароль для логина {user.Login}.");
                        }
                    } while (user.Password != users[indexUser].Password);

                    Console.WriteLine($"{user.Login}, добро пожаловать в игру!");
                }

            } while (indexUser == -1);


             while (true)
             {
                 Console.Clear();

                 Console.ForegroundColor = ConsoleColor.Green;
                 Console.WriteLine("Выберите варианты и введите соответсвующую цифру.");
                 Console.WriteLine("1 - Выход");
                 Console.WriteLine("2 - Играть со вторым игроком");
                 Console.WriteLine("3 - Играть с компьютером");
                 Console.WriteLine("4 - Показать счёт");
                 Console.WriteLine("5 - Сменить учётную запись (войти под другим логином)");
                 Console.ForegroundColor = ConsoleColor.White;
                 var option = Console.ReadLine();
                                  
                 switch (option)
                 {
                     case "1":
                         return;//Exit from Applicaation
                     case "2":
                         Console.ForegroundColor = ConsoleColor.DarkCyan;
                        user.Score = user.Score+PlayGame("2");
                         break;
                     case "3":
                         Console.ForegroundColor = ConsoleColor.DarkCyan;
                        user.Score = user.Score+PlayGame("3");
                        break;
                     case "4":
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine($"{user.Login} cчёт в игре: { user.Score}");
                         
                         break;
                     
                     
                 }
             }

           
        }

        public static int PlayGame(string str)
        {
            var room = new GameRoom();

            return room.Play(str);

            //Console.ReadLine();

        }

        public static int GetNumberFromConsole(
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
                bool more = number >= minValue;

                bool maxHaValue = maxValue.HasValue;
                bool less = number <= maxValue;

                //isValidValue =
                //     isNumber
                //     && (!minHaValue || more)
                //     && (!maxHaValue || less);

                //???Допустим уловие валидации такое: isValidValue = isNumber
                //??? isNumber = false, isValidValue = isNumber. Тогда isValidValue == false.
                //???Как сработает код if (!isValidValue). Нам ведь нужно, чтобы if (isValidValue == false)
                //??? Что означает if (isValidValue) в нашем случае и в принципе
                //???Какое занчение получает булеская переменная при её объявлении? например: bool sSSS;

                //if (!isValidValue)
                //{
                //    Console.WriteLine(errorMessge);
                //}

                if (isNumber == true
                    && (minHaValue == false || more == true)
                    && (maxHaValue == false || less == true))
                {
                    isValidValue = true;
                }
                else
                {
                    isValidValue = false;
                    Console.WriteLine(errorMessge);
                }

            } while (isValidValue == false);

            return number;
        }

        public static List<User> ReadAllUsers() //List<User> - массив User
        {
            var users = new List<User>(); //создаем массив User объектов
            var lines = File.ReadAllLines(Path); //создаем массив строк и записываем в каждую ячейку массива по одной строке из файла
            foreach (var line in lines)
            {
                var user = new JavaScriptSerializer().Deserialize<User>(line);
                users.Add(user);
            }

            return users;
        }

        public static void CreateUser(User us)
        {
            if (!string.IsNullOrEmpty(us.Login) && !string.IsNullOrEmpty(us.Password))
            {
                var json = new JavaScriptSerializer().Serialize(us);
                if (!File.Exists(Path))
                {
                    using (File.Create(Path)) { }
                }
                var listJson = new List<string>(); // массив строк. Зачем он?
                listJson.Add(json); //Зачем это? Ведь создаётся и добавляется в файл один user?
                File.AppendAllLines(Path, listJson); //добавление в текст файл все строки из массива listJson

            }
        }

        /// <summary>
        /// Если игрок с таким логином существует, - возращает его индекс в массиве users, если нет - то возарщает -1
        /// </summary>
        /// <param name="us"></игрок>
        /// <param name="users"></массив users>
        /// <returns></returns>
        public static int GetUserIndex (User us, List<User> users)
        {
            
            for (int i = 0; i < users.Count; i++)
            {
                if (us.Login == users[i].Login)
                {
                  return i;
                }

            }

            return -1;

        }

    }
}