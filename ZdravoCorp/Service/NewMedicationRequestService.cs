using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Service
{
    public class NewMedicationRequestService
    {
        private static NewMedicationRequestService instance = null;

        public Boolean CreateNewMedicationRequest(NewMedicationRequest newMedicationRequest)
        {
            return NewMedicationRequestRepository.Instance.CreateNewMedicationRequest(newMedicationRequest);
        }

        public NewMedicationRequest ReadNewMedicationRequest(int id)
        {
            return NewMedicationRequestRepository.Instance.ReadNewMedicationRequest(id);
        }

        public Boolean UpdateNewMedicationRequest(NewMedicationRequest newMedicationRequest)
        {
            return NewMedicationRequestRepository.Instance.UpdateNewMedicationRequest(newMedicationRequest);
        }

        public Boolean DeleteNewMedicationRequest(int id)
        {
            return NewMedicationRequestRepository.Instance.DeleteNewMedicationRequest(id);
        }

        public List<NewMedicationRequest> GetAllNewMedicationRequests()
        {
            return NewMedicationRequestRepository.Instance.GetAllNewMedicationRequests();
        }

        public Boolean AcceptNewMedicationRequest(NewMedicationRequest newMedicationRequest)
        {
            return NewMedicationRequestRepository.Instance.AcceptNewMedicationRequest(newMedicationRequest);
        }

        public Boolean RejectNewMedicationRequest(NewMedicationRequest newMedicationRequest, String comment)
        {
            return NewMedicationRequestRepository.Instance.RejectNewMedicationRequest(newMedicationRequest, comment);
        }

        public static NewMedicationRequestService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NewMedicationRequestService();
                }
                return instance;
            }
        }
    }
}
