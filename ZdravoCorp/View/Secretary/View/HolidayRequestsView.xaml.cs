using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZdravoCorp.View.Secretary.View
{
    /// <summary>
    /// Interaction logic for HolidayRequests.xaml
    /// </summary>
    public partial class HolidayRequestsView : Page
    {
        public HolidayRequestsView()
        {
            InitializeComponent();
            HolidaysTable.DataContext = new ViewModel.HolidayRequestViewModel();
        }
    }
}
