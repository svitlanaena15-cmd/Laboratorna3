using System.Collections.Generic;
using DAL.Entities;

namespace DAL
{
    public class EntityContext
    {
        private readonly IDataProvider _provider;
        private readonly string _path;

        public EntityContext(IDataProvider provider, string path)
        {
            _provider = provider;
            _path = path;
        }

        public IEnumerable<Student> ReadAll()
        {
            return _provider.Load(_path);
        }

        public void SaveAll(IEnumerable<Student> students)
        {
            _provider.Save(_path, students);
        }
    }
}
