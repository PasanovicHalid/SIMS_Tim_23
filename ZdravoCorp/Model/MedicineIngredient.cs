using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.View.Core;

namespace Model
{
    public class MedicineIngredient : ObservableObject, Serializable
    {
        private int id;
        private string name;

        public MedicineIngredient()
        {
        }

        public MedicineIngredient(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id
        {
            get => id;
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }
        public String Name
        {
            get => name;
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Name = values[1];
        }

        public List<string> ToCSV()
        {
            List<string> result = new List<string>();
            result.Add(Id.ToString());
            result.Add(Name);
            return result;
        }
    }
}
