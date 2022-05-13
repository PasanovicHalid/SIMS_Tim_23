using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.Repository;

namespace ZdravoCorp.Service
{
    internal class PrescriptionService
    {
        private static PrescriptionService instance = null;

        public int CreatePrescription(Model.Prescription newPrescription)
        {
            return PrescriptionRepository.Instance.CreatePrescription(newPrescription);
        }

        public Boolean UpdatePrescription(Model.Prescription medicine)
        {
            return PrescriptionRepository.Instance.UpdatePrescription(medicine);
        }

        public Boolean DeletePrescription(int identificator)
        {
            return PrescriptionRepository.Instance.DeletePrescription(identificator);
        }

        public Model.Prescription ReadPrescription(int identificator)
        {
            return PrescriptionRepository.Instance.ReadPrescription(identificator);
        }

        public List<Model.Prescription> GetAllPrescriptions()
        {
            return PrescriptionRepository.Instance.GetAllPrescriptions();
        }

        public static PrescriptionService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PrescriptionService();
                }
                return instance;
            }
        }
    }
}
