using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic19_1
{
    class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException(int balance, int amount)
            : base($"Недостаточно средств! Баланс: {balance}, нужно: {amount}")
        {
        }
    }

    class WrongPinException : Exception
    {
        public WrongPinException(int attemptsLeft)
            : base($"Неверный PIN! Осталось попыток: {attemptsLeft}")
        {
        }
    }
    class ATM
    {
        private int balance = 500;
        private const int correctPin = 1234;
        private int attemptsLeft = 3;

        public void Withdraw(int amount)
        {
            if (amount > balance)
                throw new NotEnoughMoneyException(balance, amount);

            balance -= amount;
            Console.WriteLine($"Успешно! Снято: {amount}, баланс {balance}.");
        }

        public void EnterPin(int pin)
        {
            if (pin == correctPin)
            {
                attemptsLeft = 3;
                Console.WriteLine("PIN верный!");
                return;
            }

            attemptsLeft--;
            if (attemptsLeft == 0)
                throw new Exception("Карта заблокирована!");
            else
                throw new WrongPinException(attemptsLeft);
        }
    }

    class Program
    {
        static void Main()
        {
            ATM atm = new ATM();

            Console.WriteLine("\nВвод PIN");

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Попытка {i + 1}: Введите PIN: ");
                int pin = int.Parse(Console.ReadLine());

                try
                {
                    atm.EnterPin(pin);
                    Console.WriteLine("Доступ разрешен!");
                    break;
                }
                catch (WrongPinException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }

            Console.WriteLine($"Баланс: {500}");

            Console.Write("\nВведите сумму для снятия: ");
            int amount = int.Parse(Console.ReadLine());

            try
            {
                atm.Withdraw(amount);
            }
            catch (NotEnoughMoneyException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}