using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;
using Controller;
using ZdravoCorp.Service.Interfaces;

namespace Service
{
    public class PrescriptionService : ICrud<Prescription> , IPrescriptionService
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

        public int CreateAndReturnID(Prescription newPrescription, Patient currentPatient)
        {
            int newId = PrescriptionRepository.Instance.CreateAndReturnID(newPrescription);
            PatientController patientController = new PatientController();
            MedicationController medicationController = new MedicationController();
            PrescriptionController prescriptionController = new PrescriptionController();   
            patientController.AddPrescription(currentPatient,prescriptionController.Read(newId));
            newPrescription.Medication.Count = newPrescription.Medication.Count - (newPrescription.TimesADay * newPrescription.Quantity);
            medicationController.Update(newPrescription.Medication);
            return newId;
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
