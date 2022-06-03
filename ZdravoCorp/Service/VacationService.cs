using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Service
{
    public class VacationService : ICrud<Vacation>
    {
        private static VacationService instance = null;

        public List<Vacation> GetAll()
        {
            return VacationRepository.Instance.GetAll();
        }

        public void Create(Vacation newVacation)
        {
            VacationRepository.Instance.Create(newVacation);
        }

        public Vacation Read(int id)
        {
            return VacationRepository.Instance.Read(id);
        }

        public void Update(Vacation vacation)
        {
            VacationRepository.Instance.Update(vacation);
        }

        public void Delete(int id)
        {
            VacationRepository.Instance.Delete(id);
        }

        public Boolean AcceptVacation(Doctor doctor, Vacation vacation)
        {
            return VacationRepository.Instance.AcceptVacation(doctor, vacation);
        }

        public Boolean RejectVacation(Doctor doctor, Vacation vacation,String comment)
        {
            return VacationRepository.Instance.RejectVacation(doctor, vacation,comment);
        }

        public VacationService()
        { }

        public static VacationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VacationService();
                }
                return instance;
            }
        }
    }
}
