using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class UserRepository<T> : Repository<T> where T : User, new()
    {
        protected Dictionary<string, T> _users = new Dictionary<string, T>();
        public Dictionary<string, T> GetUsers()
        {
            return _users;
        }
        
        protected void InstantiateUserSet(List<T> users)
        {
            foreach (T user in users)
            {
                _users.Add(user.Username, user);
            }
        }
    }
}
