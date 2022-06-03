using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.Exceptions;

namespace Repository
{
    public class RoomTypeRepository : Repository<RoomType>
    {
        private static RoomTypeRepository instance = null;
        public RoomTypeRepository()
        {
            dbPath = "..\\..\\Data\\medicationTypeDB.csv";
        }

        public override void Create(RoomType type)
        {
            lock (key)
            {
                List<RoomType> types = GetAll();
                CheckIfRoomTypeExists(types, type);
                AppendToDB(type);
            }
        }

        /*
         * Method isn't needed but is requered for abstract class
         */
        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(RoomType type)
        {
            lock (key)
            {
                List<RoomType> types = GetAll();
                RemoveType(types, type);
                SaveChanges(types);
            }
        }

        /*
         * Method isn't needed but is requered for abstract class
         */
        public override RoomType Read(int id)
        {
            throw new NotImplementedException();
        }

        /*
         * Method isn't needed but is requered for abstract class
         */
        public override void Update(RoomType type)
        {
            throw new NotImplementedException();
        }

        /*
         * Method isn't needed but is requered for abstract class
         */
        protected override void InstantiateIDSet(List<RoomType> elements)
        {
            throw new NotImplementedException();
        }

        private void CheckIfRoomTypeExists(List<RoomType> types, RoomType type)
        {
            foreach (RoomType it in types)
            {
                if (it.Name.Equals(type.Name))
                {
                    throw new LocalisedException("RoomTypeAlreadyExists");
                }
            }
        }

        private void RemoveType(List<RoomType> types, RoomType roomType)
        {
            foreach (RoomType type in types)
            {
                if (roomType.Name.Equals(type.Name))
                {
                    types.Remove(type);
                    return;
                }
            }
            throw new LocalisedException("RoomTypeDoesntExists");
        }

        public static RoomTypeRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)
                    {
                        if (instance == null)
                        {
                            instance = new RoomTypeRepository();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
