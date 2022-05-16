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
using System.Windows.Shapes;
using Controller;
using System.Collections.ObjectModel;
using Model;
using System.ComponentModel;

namespace ZdravoCorp.View.Secretary
{
    /// <summary>
    /// Interaction logic for AppointmentSuggest.xaml
    /// </summary>
    public partial class AppointmentSuggest : Window
    {
        public ObservableCollection<Model.Appointment> AppointmentsCollection
        {
            get;
            set;
        }
        public AppointmentSuggest(List<Model.Appointment> appointments)
        {
            InitializeComponent();
            AppointmentsCollection = new ObservableCollection<Appointment>(appointments);
            SuggestionTable.DataContext = AppointmentsCollection;
        }
    }
}
