using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.View.Core;

namespace ZdravoCorp.View.Manager.ViewModel
{
    public class MainViewModel: ObservableObject, ViewModelInterface
    {
        public MainViewModel()
        {

        }

        public string GetTitle()
        {
            return "Home";
        }

        public void Update()
        {
            
        }
    }
}
