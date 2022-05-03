using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service;

namespace Controller
{
    public class MedicalRecordController
    {
        public Boolean CreateMedicalRecord(MedicalRecord newRecord)
        {
            return MedicalRecordService.Instance.CreateMedicalRecord(newRecord);
        }

        public Boolean UpdateMedicalRecord(MedicalRecord record)
        {
            return MedicalRecordService.Instance.UpdateMedicalRecord(record);
        }

        public Boolean DeleteMedicalRecord(int record)
        {
            return MedicalRecordService.Instance.DeleteMedicalRecord(record);
        }

        public MedicalRecord ReadMedicalRecord(int record)
        {
            return MedicalRecordService.Instance.ReadMedicalRecord(record);
        }

        public List<MedicalRecord> GetAllRecords()
        {
            return MedicalRecordService.Instance.GetAllRecords();
        }
    }
}
