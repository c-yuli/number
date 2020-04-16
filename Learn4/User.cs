using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn4
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
        



        public void SetLogin()
        {
            do
            {
                Console.WriteLine("Введите логин");
                Login = Console.ReadLine();
            } while (!ValidateStringLen(Login, 2));
        }

        public void SetPass()
        {
            do
            {
                Console.WriteLine("Введите пароль");
                Password = Console.ReadLine();
            } while (!ValidateStringLen(Password, 6));

        }


        protected bool ValidateStringLen (string str, int minLen)
        {
            return !string.IsNullOrEmpty(str) && str.Length >= minLen;
        }

        public override string ToString()
        {
            return $"Логин {Login} пароль {Password}" ;
        }

    }
}
