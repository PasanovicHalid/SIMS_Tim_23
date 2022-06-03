using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class CSVDataBase<T> where T : Serializable, new()
    {
        protected string dbPath;
        protected Serializer<T> serializer = new Serializer<T>();
        public List<T> GetAll()
        {
            return serializer.FromCSV(dbPath);
        }

        protected void AppendToDB(T element)
        {
            serializer.ToCSVAppend(dbPath, new List<T>() { element });
        }

        protected void SaveChanges(List<T> elements)
        {
            serializer.ToCSV(dbPath, elements);
        }
    }
}
