using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;

namespace Controller
{
    public class NewMedicationRequestController
    {
        public Boolean CreateNewMedicationRequest(NewMedicationRequest newMedicationRequest)
        {
            return NewMedicationRequestService.Instance.CreateNewMedicationRequest(newMedicationRequest);
        }

        public NewMedicationRequest ReadNewMedicationRequest(int id)
        {
            return NewMedicationRequestService.Instance.ReadNewMedicationRequest(id);
        }

        public Boolean UpdateNewMedicationRequest(NewMedicationRequest newMedicationRequest)
        {
            return NewMedicationRequestService.Instance.UpdateNewMedicationRequest(newMedicationRequest);
        }

        public Boolean DeleteNewMedicationRequest(int id)
        {
            return NewMedicationRequestService.Instance.DeleteNewMedicationRequest(id);
        }

        public List<NewMedicationRequest> GetAllNewMedicationRequests()
        {
            return NewMedicationRequestService.Instance.GetAllNewMedicationRequests();
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
