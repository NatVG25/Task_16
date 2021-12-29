using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;

namespace Task_16
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty; //инициализация пустой строки
            using (StreamReader sr=new StreamReader("../../../Products.json")) //указываем путь к файлу
            {
                jsonString = sr.ReadToEnd(); //считываем все элементы в файле
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString); //десериализация строки json в массив products
           
            Product maxProduct = products[0]; //предположим, что самый дорогой это первый товар в массиве
            foreach (Product p in products) //перебор элементов массива и сравнение с максимальным значением
            {
                if (p.Price>maxProduct.Price)
                {
                    maxProduct = p; //если значение цены больше, чем максимальное, то запись значения в переменную p
                }
            }
            Console.WriteLine($"{maxProduct.Code} {maxProduct.Name} {maxProduct.Price}"); //вывод информации о самом дорогом товаре
            Console.ReadKey();
        }

    }

}