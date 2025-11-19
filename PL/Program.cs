using System;
using System.IO;
using DAL;
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

            string extension = provider switch
            {
                XmlProvider => "xml",
                BinaryProvider => "dat",
                _ => "json"
            };

            var path = $"/Users/svetlanaena/Documents/Laboratorna3/students.{extension}";

            if (provider is XmlProvider)
            {
                if (!File.Exists(path) || new FileInfo(path).Length == 0)
                {
                    File.WriteAllText(path,
                        "<ArrayOfStudent xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                        "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"></ArrayOfStudent>");
                }
            }
            else if (provider is JsonProvider)
            {
                if (!File.Exists(path) || new FileInfo(path).Length == 0)
                {
                    File.WriteAllText(path, "[]");
                }
            }
            else
            {
                if (!File.Exists(path))
                {
                    File.WriteAllBytes(path, Array.Empty<byte>());
                }
            }

            Console.WriteLine($"Використовується файл: {path}");

            var ctx = new EntityContext(provider, path);
            var service = new EntityService(ctx);
            var menu = new Menu(service);

            menu.MainMenu();
        }
    }
}
