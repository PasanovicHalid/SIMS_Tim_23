using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.Service
{
    public class LoginService
    {
        private static readonly object key = new object();
        private static LoginService instance = null;

        private Dictionary<string, string> userMap = new Dictionary<string, string>();
        private Dictionary<string, string> managerMap = new Dictionary<string, string>();
        private Dictionary<string, string> doctorMap = new Dictionary<string, string>();
        private Dictionary<string, string> patientMap = new Dictionary<string, string>();
        private Dictionary<string, string> secretaryMap = new Dictionary<string, string>();

        private void InstantiateHashSet()
        {
            managerMap = ManagerRepository.Instance.GetUsernameHashSet();
            doctorMap = DoctorRepository.Instance.GetUsernameHashSet();
            patientMap = PatientRepository.Instance.GetUsernameHashSet();
            secretaryMap = SecretaryRepository.Instance.GetUsernameHashSet();
            MergeIntoUserAllDictionaries();
        }

        private void MergeIntoUserAllDictionaries()
        {
            userMap = managerMap;
            MergeDictionaries(userMap, doctorMap);
            MergeDictionaries(userMap, patientMap);
            MergeDictionaries(userMap, secretaryMap);
        }

        private void MergeDictionaries(Dictionary<string, string> mergedInto, Dictionary<string, string> dictionary)
        {
            foreach(var item in dictionary)
            {
                mergedInto.Add(item.Key, item.Value);
            }
        }

        public bool Login(string username, string password)
        {
            if (userMap.ContainsKey(username))
            {
                return userMap[username] == password;
            }
            else
            {
                return false;
            }
        }

        public bool IsPatient(string username)
        {
            return patientMap.ContainsKey(username);
        }

        public bool IsManager(string username)
        {
            return managerMap.ContainsKey(username);
        }

        public bool IsDoctor(string username)
        {
            return doctorMap.ContainsKey(username);
        }

        public bool IsSecretary(string username)
        {
            return secretaryMap.ContainsKey(username);
        }

        public LoginService()
        {
            InstantiateHashSet();
        }

        public static LoginService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)
                    {
                        if (instance == null)
                        {
                            instance = new LoginService();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
