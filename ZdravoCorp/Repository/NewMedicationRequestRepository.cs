using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class NewMedicationRequestRepository
    {
        private static NewMedicationRequestRepository instance = null;

        private String dbPath = "..\\..\\Data\\newMedicationRequest.csv";
        private Serializer<NewMedicationRequest> serializerNewMedicationRequest = new Serializer<NewMedicationRequest>();

        public Boolean CreateNewMedicationRequest(NewMedicationRequest newMedicationRequest)
        {
            List<NewMedicationRequest> requests = GetAllNewMedicationRequests();
            newMedicationRequest.Id = requests.Count() + 1;
            requests.Add(newMedicationRequest);
            serializerNewMedicationRequest.ToCSV(dbPath, requests);
            return true;
        }

        public NewMedicationRequest ReadNewMedicationRequest(int id)
        {
            List<NewMedicationRequest> requests= GetAllNewMedicationRequests();
            NewMedicationRequest newMedicationRequest = null;
            foreach (NewMedicationRequest temp in requests)
            {
                if (id == temp.Id)
                {
                    newMedicationRequest = temp;
                }
            }
            return newMedicationRequest;
        }

        public Boolean UpdateNewMedicationRequest(NewMedicationRequest newMedicationRequest)
        {
            Boolean success = false;
            List<NewMedicationRequest> requests = GetAllNewMedicationRequests();
            for (int i = 0; i < requests.Count; i++)
            {
                if (newMedicationRequest.Id == requests[i].Id)
                {
                    success = true;
                    DeleteNewMedicationRequest(newMedicationRequest.Id);
                    break;
                }
            }
            if (success)
            {
                requests = GetAllNewMedicationRequests();
                requests.Add(newMedicationRequest);
                serializerNewMedicationRequest.ToCSV(dbPath, requests);
            }
            return success;

        }

        public Boolean DeleteNewMedicationRequest(int id)
        {
            Boolean success = false;
            List<NewMedicationRequest> requests = GetAllNewMedicationRequests();
            foreach (NewMedicationRequest newMedicationRequest in requests)
            {
                if (id == newMedicationRequest.Id)
                {
                    success = true;
                    requests.Remove(newMedicationRequest);
                    serializerNewMedicationRequest.ToCSV(dbPath, requests);
                    break;
                }
            }
            return success;
        }

        public List<NewMedicationRequest> GetAllNewMedicationRequests()
        {
            List<NewMedicationRequest> requests = new List<NewMedicationRequest>();
            return requests;
        }

        public static NewMedicationRequestRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NewMedicationRequestRepository();
                }
                return instance;
            }
        }
    }
}
