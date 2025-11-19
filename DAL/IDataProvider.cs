using System.Collections.Generic;
using DAL.Entities;

namespace DAL
{
    public interface IDataProvider
    {
        void Save(string path, IEnumerable<Student> students);
        IEnumerable<Student> Load(string path);
    }
}
