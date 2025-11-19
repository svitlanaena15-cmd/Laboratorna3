using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DAL.Entities;

namespace DAL
{
    public class JsonProvider : IDataProvider
    {
        public IEnumerable<Student> Load(string path)
        {
            if (!File.Exists(path)) return new Student[0];
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Student[]>(json) ?? new Student[0];
        }

        public void Save(string path, IEnumerable<Student> students)
        {
            var json = JsonSerializer.Serialize(students);
            File.WriteAllText(path, json);
        }
    }
}
