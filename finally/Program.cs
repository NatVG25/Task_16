using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Task_16
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5; //константа - размер массива
            Product[] products = new Product[n]; //создание массива продуктс

            for (int i = 0; i < n; i++) //цикл создания массива значений
            {
                Console.WriteLine("Введите код товара:");
                int code = Convert.ToInt32(Console.ReadLine()); //ввод значения
                Console.WriteLine("Введите название товара:");
                string name = Convert.ToString(Console.ReadLine()); //ввод значения
                Console.WriteLine("Введите цену товара:");
                int price = Convert.ToInt32(Console.ReadLine()); //ввод значения
                products[i] = new Product() { Code = code, Name = name, Price = price }; //инициализация экземпляра класса продукт
            }

            JsonSerializerOptions options = new JsonSerializerOptions() //создание экземпляра класса options (для правильного написания строки на кирилице)
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options); //сериализация строки json

            using (StreamWriter sw = new StreamWriter("../../../Products.json")) //запись строки json в текстовый файл с указанием подкаталога
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}
