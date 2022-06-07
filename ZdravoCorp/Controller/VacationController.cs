using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;
using Service;

namespace Controller
{
    public class VacationController : ICrud<Vacation>
    {
        private static VacationController instance = null;

        public List<Vacation> GetAll()
        {
            return VacationService.Instance.GetAll();
        }

        public void Create(Vacation newVacation)
        {
            VacationService.Instance.Create(newVacation);
        }

        public Vacation Read(int id)
        {
            return VacationService.Instance.Read(id);
        }

        public void Update(Vacation vacation)
        {
            VacationService.Instance.Update(vacation);
        }

        public void Delete(int id)
        {
            VacationService.Instance.Delete(id);
        }

        public Boolean AcceptVacation(Doctor doctor,Vacation vacation)
        {
            return VacationService.Instance.AcceptVacation(doctor, vacation);
        }

        public Boolean RejectVacation(Doctor doctor, Vacation vacation,String comment)
        {
            return VacationService.Instance.RejectVacation(doctor, vacation,comment);
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

        public Boolean CheckSpecialistInVacation(Doctor doctor,DateTime startDate, DateTime endDate)
        {
            DoctorController doctorController = new DoctorController();
            List<Vacation> vacations = GetAll();
            foreach (Vacation vacation in vacations)
            {
                if (!doctor.DoctorType.Type.Equals(doctorController.Read(vacation.DoctorID).DoctorType.Type))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
