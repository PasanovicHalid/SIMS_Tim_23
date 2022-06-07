using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Repository;

namespace Controller
{
    public class NewMedicationRequestController : ICrud<NewMedicationRequest>
    {
        public void Create(NewMedicationRequest newMedicationRequest)
        {
            if(newMedicationRequest == null || newMedicationRequest.Name == null)
            {
                throw new Exception("Incorect request");
            }
            NewMedicationRequestService.Instance.Create(newMedicationRequest);
        }

        public NewMedicationRequest Read(int id)
        {
            return NewMedicationRequestService.Instance.Read(id);
        }

        public void Update(NewMedicationRequest newMedicationRequest)
        {
            NewMedicationRequestService.Instance.Update(newMedicationRequest);
        }

        public void Delete(int id)
        {
            NewMedicationRequestService.Instance.Delete(id);
        }

        public List<NewMedicationRequest> GetAll()
        {
            return NewMedicationRequestService.Instance.GetAll();
        }

        public Boolean AcceptNewMedicationRequest(NewMedicationRequest newMedicationRequest)
        {
            return NewMedicationRequestService.Instance.AcceptNewMedicationRequest(newMedicationRequest);
        }

        public Boolean RejectNewMedicationRequest(NewMedicationRequest newMedicationRequest, String comment)
        {
            return NewMedicationRequestService.Instance.RejectNewMedicationRequest(newMedicationRequest, comment);
        }
    }
}
