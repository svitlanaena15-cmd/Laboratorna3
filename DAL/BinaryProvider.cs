using System.Collections.Generic;
using System.IO;
using System.Linq;
using DAL.Entities;

namespace DAL
{
    public class BinaryProvider : IDataProvider
    {
        public IEnumerable<Student> Load(string path)
        {
            if (!File.Exists(path)) return new Student[0];
            var list = new List<Student>();
            using var fs = new FileStream(path, FileMode.Open);
            using var br = new BinaryReader(fs);
            while (fs.Position < fs.Length)
            {
                var s = new Student
                {
                    Surname = br.ReadString(),
                    Name = br.ReadString(),
                    Height = br.ReadInt32(),
                    Weight = br.ReadInt32(),
                    StudentTicket = br.ReadString(),
                    Passport = br.ReadString()
                };
                list.Add(s);
            }
            return list;
        }

        public void Save(string path, IEnumerable<Student> students)
        {
            using var fs = new FileStream(path, FileMode.Create);
            using var bw = new BinaryWriter(fs);
            foreach (var s in students)
            {
                bw.Write(s.Surname ?? string.Empty);
                bw.Write(s.Name ?? string.Empty);
                bw.Write(s.Height);
                bw.Write(s.Weight);
                bw.Write(s.StudentTicket ?? string.Empty);
                bw.Write(s.Passport ?? string.Empty);
            }
        }
    }
}
