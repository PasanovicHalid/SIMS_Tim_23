using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Service
{
    public class VacationService
    {
        private static VacationService instance = null;

        public List<Vacation> GetAllVacations()
        {
            return VacationRepository.Instance.GetAllVacations();
        }

        public Boolean CreateVacation(Vacation newVacation)
        {
            return VacationRepository.Instance.CreateVacation(newVacation);
        }

        public Vacation ReadVacation(int id)
        {
            return VacationRepository.Instance.ReadVacation(id);
        }

        public Boolean UpdateVacation(Vacation vacation)
        {
           return VacationRepository.Instance.UpdateVacation(vacation);
        }

        public Boolean DeleteVacation(int id)
        {
            return VacationRepository.Instance.DeleteVacation(id);
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
