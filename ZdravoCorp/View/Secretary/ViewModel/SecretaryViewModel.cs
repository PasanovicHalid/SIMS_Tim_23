using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ZdravoCorp.View.Secretary.ViewModel
{
    public class SecretaryViewModel
    {
        public SecretaryViewModel()
        {
            loadSecretaries();
        }
        public ObservableCollection<Modell.Secretary> Secretaries { get; set; }
        public void loadSecretaries()
        {
            ObservableCollection<Modell.Secretary> secretaries = new ObservableCollection<Modell.Secretary>();
            secretaries.Add(new Modell.Secretary { Name = "Stevan", Surname = "Petrović", Email = "steve@gmail.com", Id = "1647894895",  DateOfBirth = "25/11/1979", PhoneNumber = "061963258" });
            secretaries.Add(new Modell.Secretary { Name = "David", Surname = "Milić", Email = "davy@gmail.com", Id = "3213213211",  DateOfBirth = "6/2/1985", PhoneNumber = "061486624" });
            secretaries.Add(new Modell.Secretary { Name = "Stefan", Surname = "Lekić", Email = "stefi@gmail.com", Id = "4566544566", DateOfBirth = "3/9/1987", PhoneNumber = "064159951" });
            secretaries.Add(new Modell.Secretary { Name = "Lazar", Surname = "Lukić", Email = "laki@gmail.com", Id = "7896541234", DateOfBirth = "21/12/1975", PhoneNumber = "066654456" });
            
            Secretaries = secretaries;
        }
    }
}
