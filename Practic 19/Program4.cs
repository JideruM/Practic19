using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_19_4
{
    class HeroIsDeadException : Exception
    {
        public HeroIsDeadException(int health)
            : base($"Герой погиб! Здоровье стало {health}")
        {
        }
    }
    class Game
    {
        private int health = 100;

        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
                throw new HeroIsDeadException(health);

            Console.WriteLine($"Здоровье: {health}");
        }

        public void ShowHealth()
        {
            Console.WriteLine($"Здоровье: {health}");
        }
    }

    class Program
    {
        static void Main()
        {
            Game game = new Game();

            Console.WriteLine("Игра\n");
            game.ShowHealth();
            Console.Write("\nВведите урон: ");
            int damage = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nПолучаем урон: {damage}");

            try
            {
                game.TakeDamage(damage);
            }
            catch (HeroIsDeadException e)
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
