using System;

namespace DAL.Entities
{
    public class Student
    {
        public string Surname { get; set; } = "";
        public string Name { get; set; } = "";
        public int Height { get; set; }
        public int Weight { get; set; }
        public string StudentTicket { get; set; } = "";
        public string Passport { get; set; } = "";
    }
}
