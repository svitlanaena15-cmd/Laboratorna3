using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using BLL.Entities;

namespace BLL
{
    public class EntityService
    {
        private readonly DAL.EntityContext _context;

        public EntityService(DAL.EntityContext context)
        {
            _context = context;
        }

        public IEnumerable<StudentDto> GetAll()
        {
            return _context.ReadAll().Select(Map);
        }

        public void Add(StudentDto dto)
        {
            var list = _context.ReadAll().ToList();
            list.Add(new Student
            {
                Surname = dto.Surname,
                Name = dto.Name,
                Height = dto.Height,
                Weight = dto.Weight,
                StudentTicket = dto.StudentTicket,
                Passport = dto.Passport
            });
            _context.SaveAll(list);
        }

        public int CountIdealWeight()
        {
            return _context.ReadAll().Count(s => s.Height - 110 == s.Weight);
        }

        public IEnumerable<StudentDto> GetStudentsWithIdealWeight()
        {
            return _context.ReadAll().Where(s => s.Height - 110 == s.Weight).Select(Map);
        }

        private static StudentDto Map(Student s)
        {
            return new StudentDto
            {
                Surname = s.Surname,
                Name = s.Name,
                Height = s.Height,
                Weight = s.Weight,
                StudentTicket = s.StudentTicket,
                Passport = s.Passport
            };
        }
    }
}
