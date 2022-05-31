using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System;
using System.Collections.Generic;   

namespace Repository
{
    public class VacationRepository
    {
        private String dbPath = "..\\..\\Data\\vacationsDB.csv";
        private Serializer<Vacation> serializerVacation = new Serializer<Vacation>();
        private static VacationRepository instance = null;

        public List<int> GetAllVacationsID()
        {
            List<Vacation> vacations = GetAllVacations();
            List<int> ids = new List<int>();
            foreach (Vacation vacation in vacations)
            {
                ids.Add(vacation.Id);
            }
            return ids;
        }

        public void GenerateId(Vacation newVacation)
        {
            List<int> allVacationIDs = GetAllVacationsID();
            Random random = new Random();
            do
            {
                newVacation.Id = random.Next();
            }
            while (allVacationIDs.Contains(newVacation.Id));
        }

        public List<Vacation> GetAllVacations()
        {
            List<Vacation> vacations = serializerVacation.FromCSV(dbPath);
            return vacations;
        }

        public Boolean CreateVacation(Vacation newVacation)
        {
            List<Vacation> vacations = GetAllVacations();
            GenerateId(newVacation);
            vacations.Add(newVacation);
            serializerVacation.ToCSV(dbPath, vacations);
            return true;
        }

        public Vacation ReadVacation(int id)
        {
            List<Vacation> vacations = GetAllVacations();
            Vacation vacation = null;
            foreach (Vacation temp in vacations)
            {
                if(id == temp.Id)
                {
                    vacation = temp;
                }
            }
            return vacation;
        }

        public Boolean UpdateVacation(Vacation vacation)
        {
            List<Vacation> vacations = GetAllVacations();
            for (int i = 0; i < vacations.Count; i++)
            {
                if (vacation.Id == vacations[i].Id)
                {
                    vacations[i] = vacation;
                    serializerVacation.ToCSV(dbPath, vacations);
                    return true;
                }
            }
            return false;
        }

        public Boolean DeleteVacation(int id)
        {
            List<Vacation> vacations = GetAllVacations();
            foreach(Vacation vacation in vacations)
            {
                if(vacation.Id == id)
                {
                    vacations.Remove(vacation);
                    serializerVacation.ToCSV(dbPath, vacations);
                    return true;
                }
            }
            return false;
        }

        public Boolean AcceptVacation(Doctor doctor,Vacation vacation)
        {
            vacation.Status = Status.ACCEPTED;
            vacation.Comment = "/";
            return UpdateVacation(vacation);
        }

        public Boolean RejectVacation(Doctor doctor,Vacation vacation, String comment)
        {
            vacation.Status = Status.REJECTED;
            vacation.Comment = comment;
            return UpdateVacation(vacation);
        }

        public VacationRepository()
        { }

        public static VacationRepository Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new VacationRepository();
                }
                return instance;
            }
        }
    }
}
