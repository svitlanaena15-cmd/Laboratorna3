using System;
using System.Linq;
using BLL;
using BLL.Entities;

namespace PL
{
    public class Menu
    {
        private readonly EntityService _service;

        public Menu(EntityService service)
        {
            _service = service;
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Показати всіх студентів");
                Console.WriteLine("2. Додати студента");
                Console.WriteLine("3. Порахувати студентів з ідеальною вагою (Ріст - 110 == Вага)");
                Console.WriteLine("4. Показати студентів з ідеальною вагою");
                Console.WriteLine("0. Вихід");
                Console.Write("Вибір: ");
                var key = Console.ReadLine();
                if (key == "0") break;
                Console.WriteLine();
                switch (key)
                {
                    case "1":
                        var all = _service.GetAll().ToList();
                        if (!all.Any()) Console.WriteLine("Файл порожній.");
                        foreach (var s in all) Console.WriteLine($"{s.Surname} {s.Name} Ріст:{s.Height} Вага:{s.Weight} Квиток:{s.StudentTicket} Паспорт:{s.Passport}");
                        break;
                    case "2":
                        Console.Write("Прізвище: ");
                        var surname = Console.ReadLine();
                        Console.Write("Ім'я: ");
                        var name = Console.ReadLine();
                        Console.Write("Ріст: ");
                        var height = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Вага: ");
                        var weight = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Студентський квиток: ");
                        var ticket = Console.ReadLine();
                        Console.Write("Паспорт (серія і номер): ");
                        var passport = Console.ReadLine();
                        var dto = new StudentDto 
                        { 
                            Surname = surname ?? "", 
                            Name = name ?? "", 
                            Height = height, 
                            Weight = weight, 
                            StudentTicket = ticket ?? "", 
                            Passport = passport ?? "" 
                        };

                        _service.Add(dto);

                        Console.WriteLine("Додано.");
                        break;
                    case "3":
                        var cnt = _service.CountIdealWeight();
                        Console.WriteLine($"Кількість студентів з ідеальною вагою: {cnt}");
                        break;
                    case "4":
                        var ideal = _service.GetStudentsWithIdealWeight().ToList();
                        if (!ideal.Any()) Console.WriteLine("Немає таких студентів.");
                        foreach (var s in ideal) Console.WriteLine($"{s.Surname} {s.Name} Ріст:{s.Height} Вага:{s.Weight} Квиток:{s.StudentTicket} Паспорт:{s.Passport}");
                        break;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }
    }
}
