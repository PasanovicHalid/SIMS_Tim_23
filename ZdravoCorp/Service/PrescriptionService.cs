using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

namespace Service
{
    internal class PrescriptionService : ICrud<Prescription>
    {
        private static PrescriptionService instance = null;

        public void Create(Prescription newPrescription)
        {
            PrescriptionRepository.Instance.Create(newPrescription);
        }

        public void Update(Prescription prescription)
        {
            PrescriptionRepository.Instance.Update(prescription);
        }

        public void Delete(int id)
        {
            PrescriptionRepository.Instance.Delete(id);
        }

        public Prescription Read(int id)
        {
            return PrescriptionRepository.Instance.Read(id);
        }

        public List<Prescription> GetAll()
        {
            return PrescriptionRepository.Instance.GetAll();
        }

        public int CreateAndReturnID(Prescription newPrescription)
        {
            return PrescriptionRepository.Instance.CreateAndReturnID(newPrescription);
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
