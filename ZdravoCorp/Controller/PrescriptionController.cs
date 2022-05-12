using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.Service;

namespace ZdravoCorp.Controller
{
    internal class PrescriptionController
    {
        public int CreatePrescription(Model.Prescription newPrescription)
        {
            return PrescriptionService.Instance.CreatePrescription(newPrescription);
        }

        public Boolean UpdatePrescription(Model.Prescription prescription)
        {
            return PrescriptionService.Instance.UpdatePrescription(prescription);
        }

        public Boolean DeletePrescription(int identificator)
        {
            return PrescriptionService.Instance.DeletePrescription(identificator);
        }

        public Model.Prescription ReadPrescription(int identificator)
        {
            return PrescriptionService.Instance.ReadPrescription(identificator);
        }

        public List<Model.Prescription> GetAllPrescriptions()
        {
            return PrescriptionService.Instance.GetAllPrescriptions();
        }
    }
}
