using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Service
{
    public class MedicalRecordService : ICrud<MedicalRecord>
    {
        private static MedicalRecordService instance = null;

        public void Create(MedicalRecord newRecord)
        {
            MedicalRecordRepository.Instance.Create(newRecord);
        }

        public void Update(MedicalRecord record)
        {
            MedicalRecordRepository.Instance.Update(record);
        }

        public void Delete(int record)
        {
            MedicalRecordRepository.Instance.Delete(record);
        }

        public MedicalRecord Read(int record)
        {
            return MedicalRecordRepository.Instance.Read(record);
        }

        public List<MedicalRecord> GetAll()
        {
            return MedicalRecordRepository.Instance.GetAll();
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
