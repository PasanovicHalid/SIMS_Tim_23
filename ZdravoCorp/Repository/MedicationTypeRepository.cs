using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.Exceptions;

namespace Repository
{
    public class MedicationTypeRepository : Repository<MedicationType>
    {
        private static MedicationTypeRepository instance = null;
        private HashSet<string> typeNameMap = new HashSet<string>();
        public MedicationTypeRepository()
        {
            dbPath = "..\\..\\Data\\medicationTypeDB.csv";
            InstantiateIDSet(GetAll());
        }
        public override void Create(MedicationType element)
        {
            lock (key)
            {
                CheckIfNameExists(element.Name);
                element.Id = GenerateID();
                AppendToDB(element);
                typeNameMap.Add(element.Name);
                idMap.Add(element.Id);
            }
        }

        public override void Delete(int id)
        {
            lock (key)
            {
                CheckIfTypeIDExists(id);
                List<MedicationType> types = GetAll();
                DeleteTypeByID(types, id);
                SaveChanges(types);
            }
        }

        public override MedicationType Read(int id)
        {
            lock (key)
            {
                CheckIfTypeIDExists(id);
                return FindTypeByID(GetAll(), id);
            }
        }

        public override void Update(MedicationType element)
        {
            lock (key)
            {
                CheckIfTypeIDExists(element.Id);
                List<MedicationType> types = GetAll();
                SwapTypesByID(types, element);
                SaveChanges(types);
            }
        }

        public new List<MedicationType> GetAll()
        {
            lock (key)
            {
                Dictionary<int, MedicationType> types = base.GetAll()
                    .ToDictionary(keySelector: m => m.Id, elementSelector: m => m);
                InstantiateReplacements(types);
                return types.Values.ToList();
            }
        }

        protected override void InstantiateIDSet(List<MedicationType> elements)
        {
            foreach (MedicationType element in elements)
            {
                idMap.Add(element.Id);
                typeNameMap.Add(element.Name);
            }
        }

        private void CheckIfNameExists(string name)
        {
            if (typeNameMap.Contains(name))
                throw new LocalisedException("MedicationTypeDoesExist");
        }

        private void CheckIfTypeIDExists(int id)
        {
            if (!idMap.Contains(id))
                throw new LocalisedException("MedicationTypeDoesntExist");
        }

        private void DeleteTypeByID(List<MedicationType> types, int id)
        {
            for (int i = 0; i < types.Count; i++)
            {
                if (types[i].Id == id)
                {
                    typeNameMap.Remove(types[i].Name);
                    idMap.Remove(id);
                    types.RemoveAt(i);
                    return;
                }
            }
            throw new LocalisedException("MedicationTypeDoesntExist");
        }

        private void SwapTypesByID(List<MedicationType> types, MedicationType type)
        {
            for (int i = 0; i < types.Count; i++)
            {
                if (types[i].Id == type.Id)
                {
                    types[i] = type;
                    return;
                }
            }
            throw new LocalisedException("MedicationTypeDoesntExist");
        }

        private void InstantiateReplacements(Dictionary<int, MedicationType> types)
        {
            foreach (MedicationType type in types.Values)
            {
                for (int i = 0; i < type.Replacement.Count; i++)
                {
                    if (types.ContainsKey(type.Replacement[i].Id))
                    {
                        type.Replacement[i] = types[type.Replacement[i].Id];
                    }
                }
            }
        }

        private MedicationType FindTypeByID(List<MedicationType> types, int id)
        {
            for (int i = 0; i < types.Count; i++)
            {
                if (types[i].Id == id)
                {
                    return types[i];
                }
            }
            throw new LocalisedException("MedicationTypeDoesntExist");
        }


        public static MedicationTypeRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)
                    {
                        if (instance == null)
                        {
                            instance = new MedicationTypeRepository();
                        }
                    }
                }
                return instance;
            }
        }

    }
}

