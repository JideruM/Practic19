using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_19_2
{
    class ProductOutOfStockException : Exception
    {
        public ProductOutOfStockException(string product, int stock)
            : base($"Товар '{product}' закончился. В наличии: {stock}")
        {
        }
    }

    class Program
    {
        static void Main()
        {

            var products = new System.Collections.Generic.Dictionary<string, int>
        {
            {"IPhone", 2},
            {"Samsung", 5},
        };


            Console.WriteLine("Товары :");
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key}: {item.Value} шт.");
            }


            Console.Write("Введите название товара: ");
            string product = Console.ReadLine();

            Console.Write("Введите количество: ");
            int quantity = int.Parse(Console.ReadLine());

            try
            {

                if (!products.ContainsKey(product))
                    throw new Exception($"Товар '{product}' не найден");


                if (products[product] < quantity)
                    throw new ProductOutOfStockException(product, products[product]);


                products[product] -= quantity;
                Console.WriteLine($"\nУспешно! Куплено: {product} {quantity}х.");
            }
            catch (ProductOutOfStockException e)
            {
                Console.WriteLine($"\nОшибка: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nОшибка: {e.Message}");
            }

        }
    }
}
