using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ZdravoCorp.View.Core;

namespace ZdravoCorp.View.Manager.ViewModel.Rooms
{
    public class Framework : ObservableObject, ViewModelInterface
    {

        public UserControl CurrentView
        {
            get => ContentViewModel.Instance.CurrentView;
            set
            {
                if (value != ContentViewModel.Instance.CurrentView)
                {
                    ContentViewModel.Instance.WindowBrowser.AddWindow(value);
                    ContentViewModel.Instance.CurrentView = value;
                    OnPropertyChanged();
                }
            }
        }

        public string GetTitle()
        {
            return "";
        }

        public void Update()
        {
            
        }
    }
}
