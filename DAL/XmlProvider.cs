using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using DAL.Entities;

namespace DAL
{
    public class XmlProvider : IDataProvider
    {
        public IEnumerable<Student> Load(string path)
        {
            if (!File.Exists(path)) return new Student[0];
            var xs = new XmlSerializer(typeof(Student[]));
            using var fs = new FileStream(path, FileMode.Open);
            return (xs.Deserialize(fs) as Student[]) ?? Array.Empty<Student>();
        }

        public void Save(string path, IEnumerable<Student> students)
        {
            var xs = new XmlSerializer(typeof(Student[]));
            using var fs = new FileStream(path, FileMode.Create);
            var arr = students is Student[] sArr ? sArr : students.ToArray();
            xs.Serialize(fs, arr);
        }
    }
}
