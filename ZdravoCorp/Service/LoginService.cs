using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ZdravoCorp.Service
{
    public class LoginService
    {
        private static readonly object key = new object();
        private static LoginService instance = null;

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
        }

        private void MergeDictionaries(Dictionary<string, string> mergedInto, Dictionary<string, string> dictionary)
        {
            foreach(var item in dictionary)
            {
                mergedInto.Add(item.Key, item.Value);
            }
        }

        public LoginUserEnumeration Login(string username, string password)
        {
            if(IsPatient(username, password))
            {
                return LoginUserEnumeration.Patient;
            }
            else if(IsDoctor(username, password))
            {
                return LoginUserEnumeration.Doctor;
            }
            else if (IsManager(username, password))
            {
                return LoginUserEnumeration.Manager;
            }
            else if (IsSecretary(username, password))
            {
                return LoginUserEnumeration.Secretary;
            }
            else
            {
                return LoginUserEnumeration.None;
            }
        }

        public bool IsPatient(string username, string password)
        {
            if (patientMap.ContainsKey(username))
            {
                if(patientMap[username] == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsManager(string username, string password)
        {
            if (managerMap.ContainsKey(username))
            {
                if (managerMap[username] == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsDoctor(string username, string password)
        {
            if (doctorMap.ContainsKey(username))
            {
                if (doctorMap[username] == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsSecretary(string username, string password)
        {
            if (secretaryMap.ContainsKey(username))
            {
                if (secretaryMap[username] == password)
                {
                    return true;
                }
            }
            return false;
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
