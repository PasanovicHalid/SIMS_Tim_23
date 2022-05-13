using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class MedicalRecordRepository
    {
        private String dbPath = "..\\..\\Data\\medicalRecordDB.csv";
        private Serializer<MedicalRecord> serializerRecord = new Serializer<MedicalRecord>();

        private static MedicalRecordRepository instance = null;

        public List<int> GetAllMedicalRecordIds()
        {
            List<MedicalRecord> medicalRecords = GetAllRecords();
            List<int> ids = new List<int>();
            foreach (MedicalRecord medicalRecord in medicalRecords)
            {
                ids.Add(medicalRecord.Id);
            }
            return ids;
        }
        public void GenerateId(MedicalRecord newMedicalRecord)
        {
            List<int> allMedicalRecordsIds = GetAllMedicalRecordIds();
            Random random = new Random();
            do
            {
                newMedicalRecord.Id = random.Next();
            }
            while (allMedicalRecordsIds.Contains(newMedicalRecord.Id));
        }

        public Boolean CreateMedicalRecord(MedicalRecord newRecord)
        {
            List<MedicalRecord> records = GetAllRecords();
            bool exists = false;


            if (!exists)
            {
                GenerateId(newRecord);
                records.Add(newRecord);
                serializerRecord.ToCSV(dbPath, records);
                return true;
            }
            return false;

        }

        public Boolean UpdateMedicalRecord(MedicalRecord record)
        { 

            Boolean success = false;
            List<MedicalRecord> records = GetAllRecords();
            for (int i = 0; i < records.Count; i++)
            {
                if (record.Id == records[i].Id)
                {
                    success = true;
                    records[i] = record;
                    break;
                }
            }
            if (success)
            {
                //patients.Add(patient);
                serializerRecord.ToCSV(dbPath, records);

            }
            return success;
        }

        public Boolean DeleteMedicalRecord(int id)
        {
            Boolean success = false;
            List<MedicalRecord> records = GetAllRecords();
            foreach (MedicalRecord mr in records)
            {
                if (id == mr.Id)
                {
                    success = true;
                    records.Remove(mr);
                    serializerRecord.ToCSV(dbPath, records);
                    break;
                }
            }
            return success;
        }

        public MedicalRecord ReadMedicalRecord(int id)
        {
            List<MedicalRecord> records = GetAllRecords();
            foreach (MedicalRecord mr in records)
            {
                if (id == mr.Id)
                {
                    return mr;
                }
            }
            return null;
        }

        public List<MedicalRecord> GetAllRecords()
        {
            List<MedicalRecord> records =  serializerRecord.FromCSV(dbPath);
            
            return records;
        }

        public MedicalRecordRepository()
        {

        }

        public static MedicalRecordRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MedicalRecordRepository();
                }
                return instance;
            }
        }
    }
}
