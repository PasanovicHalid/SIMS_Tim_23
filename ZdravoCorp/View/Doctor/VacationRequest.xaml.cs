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
using Model;
using Controller;

namespace ZdravoCorp.View.Doctor
{
    /// <summary>
    /// Interaction logic for VacationRequest.xaml
    /// </summary>
    public partial class VacationRequest : Window
    {
        Model.Doctor currentDoctor;
        VacationController vacationController = new VacationController();
        public VacationRequest(Model.Doctor temp)
        {
            InitializeComponent();
            currentDoctor = temp;
        }

        private void odustaniButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void posaljiButton_Click(object sender, RoutedEventArgs e)
        {
            bool regularDate = true;
            bool regularAppointments = true;
            bool regularDB = true;

            DateTime vacationStartDate = (DateTime)datePicker1.SelectedDate;
            DateTime vacationEndDate = (DateTime)datePicker2.SelectedDate;
            String vacationCause = textBox1.Text;
            regularDate = CheckDate(vacationStartDate,vacationEndDate);
            if(regularDate)
            {
                regularAppointments = CheckAppointments(vacationStartDate,vacationEndDate);
            }

            if (!(bool)checkBox.IsChecked && regularDate && regularAppointments)
            {
                regularDB = CheckVacationDB();
            }

            if(regularDB && regularDate && regularAppointments)
            {
                vacationController.CreateVacation(new Vacation(vacationStartDate, vacationEndDate, vacationCause, currentDoctor));
                MessageBox.Show("Uspesno poslat zahtev!");
                this.Close();
            }
           
        }

        private Boolean CheckDate(DateTime start, DateTime end)
        {
            if ((start.CompareTo(start.AddDays(30)) > 0) || (start.CompareTo(DateTime.Now.AddDays(2)) < 0) || (start.CompareTo(end) >=0))
            {
                MessageBox.Show("Datumi nisu dobro uneti");
                return false;
            }
            return true;
        }

        private Boolean CheckAppointments(DateTime vacationStartDate, DateTime vacationEndDate)
        {
            AppointmentController appointmentController = new AppointmentController();
            List<Appointment> appointments = appointmentController.GetAllAppointments();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.DoctorID == currentDoctor.Id)
                {
                    if (((vacationStartDate.CompareTo(appointment.startDate.Date) < 0)) && (vacationEndDate.CompareTo(appointment.EndDate.Date) > 0))
                    {
                        MessageBox.Show("Doktor ima zakazane appointmente u tom periodu");
                        return false;
                    }
                }
            }
            return true;
        }

        private Boolean CheckVacationDB()
        {
            VacationController vacationController = new VacationController();
            List<Vacation> vacations = vacationController.GetAllVacations();
            foreach (Vacation vacation in vacations)
            {
                if (vacation.Doctor.DoctorType.Type.Equals(currentDoctor.DoctorType.Type))
                {
                    MessageBox.Show("Postoji vec doktor sa istom specijalizacijom koji je na odmoru");
                    return false;
                }
            }
            return true;
        }
    }
}
