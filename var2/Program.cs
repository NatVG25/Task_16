using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;

namespace var2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите код товара №1:");
                int code1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара №1:");
                string name1 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Введите цену товара №1:");
                double price1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите код товара №2:");
                int code2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара №2:");
                string name2 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Введите цену товара №2:");
                double price2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите код товара №3:");
                int code3 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара №3:");
                string name3 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Введите цену товара №3:");
                double price3 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите код товара №4:");
                int code4 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара №4:");
                string name4 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Введите цену товара №4:");
                double price4 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите код товара №5:");
                int code5 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара №5:");
                string name5 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Введите цену товара №5:");
                double price5 = Convert.ToDouble(Console.ReadLine());

                object[,] array = new object[,] { { code1, code2, code3, code4, code5 }, { name1, name2, name3, name4, name5 }, { price1, price2, price3, price4, price5 } };
            

                Product product1 = new Product() //создадим экземпляр класса Product для сериализации (который объект превратит в строку)
                { //инициализатор
                    Code = code1,
                    Name = name1,
                    Price = price1,
                };
                Product product2 = new Product() //создадим экземпляр класса Product для сериализации (который объект превратит в строку)
                { //инициализатор
                    Code = code2,
                    Name = name2,
                    Price = price2,
                };
                Product product3 = new Product() //создадим экземпляр класса Product для сериализации (который объект превратит в строку)
                { //инициализатор
                    Code = code3,
                    Name = name3,
                    Price = price3,
                };
                Product product4 = new Product() //создадим экземпляр класса Product для сериализации (который объект превратит в строку)
                { //инициализатор
                    Code = code4,
                    Name = name4,
                    Price = price4,
                };
                Product product5 = new Product() //создадим экземпляр класса Product для сериализации (который объект превратит в строку)
                { //инициализатор
                    Code = code5,
                    Name = name5,
                    Price = price5,
                };

                JsonSerializerOptions options = new JsonSerializerOptions() //создадим экземпляр класса JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                string jsonString1 = JsonSerializer.Serialize<object>(array); //результатом этого метода всегда будет строка, не нужно указывать <тип>
                Console.WriteLine(jsonString1);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
    class Product
    {
        [JsonPropertyName("Код товара")]
        public int Code { get; set; }
        [JsonPropertyName("Название товара")]
        public string Name { get; set; }
        [JsonPropertyName("Цена товара")]
        public double Price { get; set; }

    }
}

