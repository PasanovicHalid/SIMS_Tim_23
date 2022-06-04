using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Service
{
    public class NewMedicationRequestService : ICrud<NewMedicationRequest>
    {
        private static NewMedicationRequestService instance = null;

        public void Create(NewMedicationRequest newMedicationRequest)
        {
            NewMedicationRequestRepository.Instance.Create(newMedicationRequest);
        }

        public NewMedicationRequest Read(int id)
        {
            return NewMedicationRequestRepository.Instance.Read(id);
        }

        public void Update(NewMedicationRequest newMedicationRequest)
        {
            NewMedicationRequestRepository.Instance.Update(newMedicationRequest);
        }

        public void Delete(int id)
        {
            NewMedicationRequestRepository.Instance.Delete(id);
        }

        public List<NewMedicationRequest> GetAll()
        {
            return NewMedicationRequestRepository.Instance.GetAll();
        }

        private bool ExecuteUpdate(NewMedicationRequest newMedicationRequest)
        {
            MedicationRepository.Instance.Update(new Medication(0, newMedicationRequest.MedicationType));
            NewMedicationRequestRepository.Instance.Delete(newMedicationRequest.Id);
            return true;
        }

        private bool ExecuteCreation(NewMedicationRequest newMedicationRequest)
        {
            MedicationRepository.Instance.Create(new Medication(0, newMedicationRequest.MedicationType));
            NewMedicationRequestRepository.Instance.Delete(newMedicationRequest.Id);
            return true;
        }

        public Boolean AcceptNewMedicationRequest(NewMedicationRequest newMedicationRequest)
        {
            if (newMedicationRequest.Change)
            {
                return ExecuteUpdate(newMedicationRequest);
            }
            else
            {
                return ExecuteCreation(newMedicationRequest);
            }
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
