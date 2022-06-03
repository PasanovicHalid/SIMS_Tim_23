using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class Repository<T> : CSVDataBase<T>, ICrud<T> where T : Serializable, new()
    {
        protected HashSet<int> idMap = new HashSet<int>();
        protected static readonly object key = new object();
        public abstract T Read(int id);
        public abstract void Create(T element);
        public abstract void Update(T element);
        public abstract void Delete(int id);
        public new List<T> GetAll()
        {
            lock (key)
            {
                return base.GetAll();
            }
        }
        protected abstract void InstantiateIDSet(List<T> elements);
        protected int GenerateID()
        {
            int id;
            Random random = new Random();
            do
            {
                id = random.Next();
            }
            while (idMap.Contains(id));
            return id;
        }
    }
}
