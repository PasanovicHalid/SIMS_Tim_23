using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.View.Core;

namespace ZdravoCorp.View.Manager.ViewModel
{
    public class MainViewModel: ObservableObject, WindowInterface
    {
        public MainViewModel()
        {

        }

        public string getTitle()
        {
            return "Home";
        }
    }
}
