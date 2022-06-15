using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ZdravoCorp.View.Secretary.ViewModel
{
    public class DoctorViewModel
    {
        public DoctorViewModel() {
            loadDoctors();
        }
        
        public ObservableCollection<Modell.Doctor> Doctors { get; set; }
        public void loadDoctors()
        {
            ObservableCollection<Modell.Doctor> doctors = new ObservableCollection<Modell.Doctor>();
            doctors.Add(new Modell.Doctor { Name = "Duško", Surname = "Dušković", Email = "duca@gmail.com", Id = "1234566543", LicenseNumber = "12345", DateOfBirth = "10/7/1980", PhoneNumber = "061564123" });
            doctors.Add(new Modell.Doctor { Name = "Mina", Surname = "Milić", Email = "mina@gmail.com", Id = "1231231233", LicenseNumber = "54321", DateOfBirth = "10/8/1980", PhoneNumber = "061357159" });
            doctors.Add(new Modell.Doctor { Name = "Miroljub", Surname = "Petrović", Email = "mire@gmail.com", Id = "1111111111", LicenseNumber = "11111", DateOfBirth = "10/7/1960", PhoneNumber = "064555333" });
            doctors.Add(new Modell.Doctor { Name = "Lazar", Surname = "Petković", Email = "laki@gmail.com", Id = "1472583699", LicenseNumber = "12121", DateOfBirth = "18/3/1969", PhoneNumber = "061568789" });
            doctors.Add(new Modell.Doctor { Name = "Darko", Surname = "Marić", Email = "dare@gmail.com", Id = "1593577899", LicenseNumber = "13133", DateOfBirth = "9/5/1974", PhoneNumber = "061123123" });
            Doctors = doctors;
        }
    }
    

    
}
