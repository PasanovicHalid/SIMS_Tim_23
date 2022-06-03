using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.Service;
using Repository;
using Model;
using Service;

namespace ZdravoCorp.Controller
{
    internal class PrescriptionController : ICrud<Prescription>
    {
        public void Create(Model.Prescription newPrescription)
        {
            PrescriptionService.Instance.Create(newPrescription);
        }

        public void Update(Model.Prescription prescription)
        {
            PrescriptionService.Instance.Update(prescription);
        }

        public void Delete(int identificator)
        {
            PrescriptionService.Instance.Delete(identificator);
        }

        public Prescription Read(int identificator)
        {
            return PrescriptionService.Instance.Read(identificator);
        }

        public List<Prescription> GetAll()
        {
            return PrescriptionService.Instance.GetAll();
        }
    }
}
