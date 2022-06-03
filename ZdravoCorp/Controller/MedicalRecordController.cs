using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;
using Service;

namespace Controller
{
    public class MedicalRecordController : ICrud<MedicalRecord>
    {
        public void Create(MedicalRecord newRecord)
        {
            MedicalRecordService.Instance.Create(newRecord);
        }

        public void Update(MedicalRecord record)
        {
            MedicalRecordService.Instance.Update(record);
        }

        public void Delete(int record)
        {
            MedicalRecordService.Instance.Delete(record);
        }

        public MedicalRecord Read(int record)
        {
            return MedicalRecordService.Instance.Read(record);
        }

        public List<MedicalRecord> GetAll()
        {
            return MedicalRecordService.Instance.GetAll();
        }
    }
}
