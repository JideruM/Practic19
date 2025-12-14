using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_19_3
{
    class LoginAlreadyExistsException : Exception
    {
        public LoginAlreadyExistsException(string login)
            : base($"Логин '{login}' уже занят!")
        {
        }
    }

    class WeakPasswordException : Exception
    {
        public WeakPasswordException()
            : base("Слабый пароль! Минимум 6 символов")
        {
        }
    }
    class UserService
    {
        private List<string> registeredLogins = new List<string>() { "user1", "admin" };

        public void Register(string login, string password)
        {

            if (password.Length < 6)
                throw new WeakPasswordException();

            if (registeredLogins.Contains(login))
                throw new LoginAlreadyExistsException(login);

            registeredLogins.Add(login);
            Console.WriteLine($"Успешно! Пользователь '{login}' зарегистрирован.");
        }
    }
    class Program
    {
        static void Main()
        {
            UserService userService = new UserService();

            Console.WriteLine("Регистрация: ");


            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            Console.WriteLine($"\nРегистрация: {login}, {password}");

            try
            {
                userService.Register(login, password);
            }
            catch (WeakPasswordException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
            catch (LoginAlreadyExistsException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
    }
}
