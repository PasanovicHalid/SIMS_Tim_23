using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    internal class PrescriptionRepository
    {
        private String dbPath = "..\\..\\Data\\prescriptionDB.csv";
        private Serializer<Prescription> serializerPrescription = new Serializer<Prescription>();

        private static PrescriptionRepository instance = null;

        public PrescriptionRepository()
        {
        }
        public List<int> GetAllPrescriptionIds()
        {
            List<Prescription> prescriptions = GetAllPrescriptions();
            List<int> ids = new List<int>();
            foreach (Prescription prescription in prescriptions)
            {
                ids.Add(prescription.Id);
            }
            return ids;
        }
        public void GenerateId(Prescription newPrescription)
        {
            List<int> allPrescriptionsIds = GetAllPrescriptionIds();
            Random random = new Random();
            do
            {
                newPrescription.Id = random.Next();
            }
            while (allPrescriptionsIds.Contains(newPrescription.Id));
        }

        public void Create(Prescription newPrescription)
        {
            List<Prescription> medicines = GetAllPrescriptions();
            GenerateId(newPrescription);
            medicines.Add(newPrescription);
            serializerPrescription.ToCSV(dbPath, medicines);
        }

        public int CreateAndReturnID(Prescription newMedicine)
        {
            List<Prescription> medicines = GetAllPrescriptions();
            GenerateId(newMedicine);
            medicines.Add(newMedicine);
            serializerPrescription.ToCSV(dbPath, medicines);
            return newMedicine.Id;
        }

        public Boolean UpdatePrescription(Model.Prescription medicine)
        {
            Boolean success = false;
            List<Prescription> medicines = GetAllPrescriptions();
            foreach (Prescription m in medicines)
            {
                if (medicine.Id == m.Id)
                {
                    success = true;
                    medicines.Remove(m);
                    break;
                }
            }
            if (success)
            {
                medicines.Add(medicine);
                serializerPrescription.ToCSV(dbPath, medicines);
            }
            return success;

        }

        public Boolean DeletePrescription(int identificator)
        {
            Boolean success = false;
            List<Prescription> medicines = GetAllPrescriptions();
            foreach (Prescription m in medicines)
            {
                if (identificator == m.Id)
                {
                    success = true;
                    medicines.Remove(m);
                    serializerPrescription.ToCSV(dbPath, medicines);
                    break;
                }
            }
            return success;
        }

        public Model.Prescription ReadPrescription(int identificator)
        {
            List<Prescription> medicines = GetAllPrescriptions();
            foreach (Prescription m in medicines)
            {
                if (identificator == m.Id)
                {
                    return m;
                }
            }
            return null;
        }
        public List<Prescription> GetAllPrescriptions()
        {
            return serializerPrescription.FromCSV(dbPath);
        }

        public static PrescriptionRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PrescriptionRepository();
                }
                return instance;
            }
        }

    }
}
