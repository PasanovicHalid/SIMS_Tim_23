using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Service
{
    public class MedicalRecordService
    {
        private static MedicalRecordService instance = null;

        public Boolean CreateMedicalRecord(MedicalRecord newRecord)
        {
            return MedicalRecordRepository.Instance.CreateMedicalRecord(newRecord);
        }

        public Boolean UpdateMedicalRecord(MedicalRecord record)
        {
            return MedicalRecordRepository.Instance.UpdateMedicalRecord(record);
        }

        public Boolean DeleteMedicalRecord(int record)
        {
            return MedicalRecordRepository.Instance.DeleteMedicalRecord(record);
        }

        public MedicalRecord ReadMedicalRecord(int record)
        {
            return MedicalRecordRepository.Instance.ReadMedicalRecord(record);
        }

        public List<MedicalRecord> GetAllRecords()
        {
            return MedicalRecordRepository.Instance.GetAllRecords();
        }

        public MedicalRecordService()
        {

        }

        public static MedicalRecordService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MedicalRecordService();
                }
                return instance;
            }
        }
    }
}
