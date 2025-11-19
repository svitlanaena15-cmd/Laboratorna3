using System;
using DAL;
using DAL.Entities;
using BLL;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Виберіть тип збереження: 1-JSON, 2-XML, 3-Бінарний");
            var t = Console.ReadLine();
            IDataProvider provider = t switch
            {
                "2" => new XmlProvider(),
                "3" => new BinaryProvider(),
                _ => new JsonProvider()
            };
            Console.Write("Введіть шлях до файлу (наприклад students.json): ");
            var path = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(path)) path = "students.json";
            var ctx = new EntityContext(provider, path);
            var service = new EntityService(ctx);
            var menu = new Menu(service);
            menu.MainMenu();
        }
    }
}
