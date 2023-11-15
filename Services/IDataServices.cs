using System.Collections.Generic;

namespace Wave.Services
{
        public interface IDataServices<T>
        {
            T Add(T item);
            void Update(T item);
            void Delete(int id);
            T GetValue(int id);
            List<T> GetAll();
        }
}
