using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service;

namespace Controller
{
    public class VacationController
    {
        private static VacationController instance = null;

        public List<Vacation> GetAllVacations()
        {
            return VacationService.Instance.GetAllVacations();
        }

        public Boolean CreateVacation(Vacation newVacation)
        {
            return VacationService.Instance.CreateVacation(newVacation);
        }

        public Vacation ReadVacation(int id)
        {
            return VacationService.Instance.ReadVacation(id);
        }

        public Boolean UpdateVacation(Vacation vacation)
        {
            return VacationService.Instance.UpdateVacation(vacation);
        }

        public Boolean DeleteVacation(int id)
        {
            return VacationService.Instance.DeleteVacation(id);
        }

        public VacationController()
        { }

        public static VacationController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VacationController();
                }
                return instance;
            }
        }
    }
}
