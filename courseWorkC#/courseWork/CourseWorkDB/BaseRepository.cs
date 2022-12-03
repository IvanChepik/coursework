using CourseWorkDB.Utilities;
using System.Collections.Generic;

namespace CourseWorkDB
{
    public abstract class BaseRepository<T>
    {
        protected string connectionString = "Server=localhost\\SQLEXPRESS;Database=agency;TrustServerCertificate=true;Trusted_Connection=True;";

        public abstract IEnumerable<T> GetList(SortModel sort); // получение всех объектов
        public abstract T Get(int id); // получение одного объекта по id
        public abstract void Create(T item); // создание объекта
        public abstract void Update(T item); // обновление объекта
        public abstract void Delete(int id); // удаление объекта по id
        public abstract void Save();  // сохранение изменений
    }
}
