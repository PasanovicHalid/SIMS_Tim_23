using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Tables;
using Syncfusion.Pdf.Graphics;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Controller;
using Model;
using LiveCharts;
using LiveCharts.Wpf;
using ZdravoCorp.View.Patient.Appointments;

namespace ZdravoCorp.View.Patient
{
    public partial class Patient : Window, INotifyPropertyChanged
    {
        private Appointment app;
        private Model.Patient patient;
        public  Model.Doctor doctor { get; set; }
        private DoctorController dc;
        public String NameSurname { get => NameSurname; set => NameSurname = value; }
        private String password;
        private String username;
        private String name;
        private String surname;
        private String jmbg;
        private String email;
        private String address;
        private String phoneNumber;
        private Gender gender;
        private DateTime dateOfBirth;

        public String Username
        {
            get { return username; }
            set
            {
                if (value != username)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public String Password
        {
            get { return password; }
            set
            {
                if (value != password)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public String Namee
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Namee");
                }
            }
        }

        public String Surname
        {
            get { return surname; }
            set
            {
                if (value != surname)
                {
                    surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }

        public String Jmbg
        {
            get { return jmbg; }
            set
            {
                if (value != jmbg)
                {
                    jmbg = value;
                    OnPropertyChanged("Jmbg");
                }
            }
        }

        public String Email
        {
            get { return email; }
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public String Address
        {
            get { return address; }
            set
            {
                if (value != address)
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        public String PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value != phoneNumber)
                {
                    phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        public Gender Gender
        {
            get { return gender; }
            set
            {
                if (value != gender)
                {
                    if (MaleButton.IsChecked == true)
                    {
                        gender = Gender.Male;
                    }
                    else
                    {
                        gender = Gender.Female;
                    }
                    OnPropertyChanged("Gender");
                }

            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value != dateOfBirth)
                {
                    dateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }
        public Patient(Model.Patient logedPatient)
        {
            InitializeComponent();
            patient = logedPatient;
            appointmentController = new AppointmentController();
            dc = new DoctorController();
            FutureAppointmentsCollection = new ObservableCollection<Appointment>();
            PastAppointmentsCollection = new ObservableCollection<Appointment>();
            DoctorCollection = new ObservableCollection<Model.Doctor>();
            RoomCollection = new ObservableCollection<Room>();
            SetPatientInfo(patient);
            SetPieChartHospital();
            UpdateTable();
            PastAppointments();
            Therapy();

        }
        public void Therapy()
        {
            Prescription prescription;
            PrescriptionController prescriptionController = new PrescriptionController();
            List<Prescription> prescriptions = prescriptionController.GetAll();
            ObservableCollection<Prescription> prescriptionCollection = new ObservableCollection<Prescription>(prescriptions);
            CurrentTherapies.DataContext = prescriptionCollection;
        }
        public void SetPatientInfo(Model.Patient patient)
        {
            NameTextBox.Text = patient.Name;
            SurnameTextBox.Text = patient.Surname;
            BirthTextBox.Text = patient.DateOfBirth.ToLongDateString();
            PhoneTextBox.Text = patient.PhoneNumber;
            EmailTextBox.Text = patient.Email;
            JMBGTextBox.Text = patient.Jmbg;
            if (patient.Gender == Gender.Male)
            {
                MaleButton.IsChecked = true;
            }
            else
            {
                FemaleButton.IsChecked = true;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        
        public String Doctorr
        {
            get { return app.doctor.nameSurname; }
            set
            {
                if (value != app.doctor.nameSurname)
                {
                    app.doctor.nameSurname = value;
                    OnPropertyChanged("Doctorr");
                }
            }
        }
        public String Room
        {
            get { return app.Room.DesignationCode; }
            set
            {
                if (value != app.Room.DesignationCode)
                {
                    app.Room.DesignationCode = value;
                    OnPropertyChanged("Room");
                }
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PatientAppointmentTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public AppointmentController appointmentController;

        public ObservableCollection<Appointment> FutureAppointmentsCollection
        {
            get;
            set;
        }
        public ObservableCollection<Appointment> PastAppointmentsCollection
        {
            get;
            set;
        }

        public ObservableCollection<Room> RoomCollection
        {
            get;
            set;
        }
        public ObservableCollection<Model.Doctor> DoctorCollection
        {
            get;
            set;
        }

        private void UpdateTable()
        {
            
            List<Appointment> appointments = appointmentController.GetFutureAppointmentsForPatient(patient);
            RoomController roomController = new RoomController();
            FutureAppointmentsCollection = new ObservableCollection<Appointment>(appointments);
            foreach(Appointment a in appointments)
            {
                a.doctor = dc.Read(a.doctor.Id);
                a.room = roomController.Read(a.room.Identifier);
            }
            PatientAppointmentTable.DataContext = FutureAppointmentsCollection;
        }
        private void Add_Appointment(object sender, RoutedEventArgs e)
        {
            AddAppointment window = new AddAppointment(patient);
            window.Owner = this;
            window.ShowDialog();
            UpdateTable();
        }

        private void Change_Appointment(object sender, RoutedEventArgs e)
        {
            if (PatientAppointmentTable.SelectedIndex == -1)
            {
                return;
            }
            Appointment appointment = (Appointment)PatientAppointmentTable.SelectedItem;
            PatientController patientController = new PatientController();
            //Model.Patient patient = patientController.ReadPatient(appointment.Patient.Id);
            patientController.RemoveFromChangedOrCanceledList(patient);
            if (appointmentController.IsTroll(appointment))
            {
                MessageBox.Show("Sad cete biti blokirani jer ste trol", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                MainWindow window = new MainWindow();
                this.Close();
                window.ShowDialog();
            }
            ChangeAppointment change = new ChangeAppointment(appointment);
            change.ShowDialog();
            UpdateTable();

        }

        private void Delete_Appointment(object sender, RoutedEventArgs e)
        {
            if (PatientAppointmentTable.SelectedIndex == -1)
            {
                return;
            }
            Appointment appointment = (Appointment)PatientAppointmentTable.SelectedItem;
            PatientController patientController = new PatientController();
            //Model.Patient patient = patientController.ReadPatient(appointment.Patient.Id);
            patientController.RemoveFromChangedOrCanceledList(patient);
            if (appointmentController.IsTroll(appointment))
            {
                MessageBox.Show("Sad cete biti blokirani jer ste trol", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                MainWindow window = new MainWindow();
                this.Close();
                window.ShowDialog();
                
            }
            appointmentController.Delete(appointment.Id);
            if (patient.ChangedOrCanceledAppointmentsDates == null)
            {
                patient.ChangedOrCanceledAppointmentsDates = new List<DateTime>();
            }
            DoctorController doctorController = new DoctorController();
            Model.Doctor doctor = doctorController.Read(appointment.Doctor.Id);
            doctor.RemoveAppointment(appointment);
            doctorController.Update(doctor);
            RoomController roomController = new RoomController();
            Model.Room room = roomController.Read(appointment.Room.Identifier);
            room.RemoveAppointment(appointment);
            roomController.Update(room);
            patient.RemoveAppointment(appointment);
            patient.ChangedOrCanceledAppointmentsDates.Add(DateTime.Now);
            patientController.Update(patient);
            UpdateTable();
        }

        

        public void PastAppointments()
        {
            List<Appointment> appointments = appointmentController.GetPastAppointmentsForPatient(patient);
            RoomController roomController = new RoomController();
            PastAppointmentsCollection = new ObservableCollection<Appointment>(appointments);
            List<Model.Doctor> doctors = new List<Model.Doctor>();
            foreach (Appointment a in appointments)
            {
                a.doctor = dc.Read(a.doctor.Id);
                a.room = roomController.Read(a.room.Identifier);
            }
            DoctorCollection = new ObservableCollection<Model.Doctor>();
            DoneAppointments.DataContext = PastAppointmentsCollection;
        }

        private void HospitalSurvey_Click(object sender, RoutedEventArgs e)
        {
            ZdravoCorp.View.Patient.View.Survey.HospitalSurveyView window = new ZdravoCorp.View.Patient.View.Survey.HospitalSurveyView(patient);
            window.ShowDialog();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.ShowDialog();
           
        }

        private void Anamnesis_Click(object sender, RoutedEventArgs e)
        {
            ZdravoCorp.View.Patient.MedicalRecord.Anamnesis window = new ZdravoCorp.View.Patient.MedicalRecord.Anamnesis(PastAppointmentsCollection.ElementAt(DoneAppointments.SelectedIndex));
            window.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ZdravoCorp.View.Patient.View.Notification.NotificationView window = new ZdravoCorp.View.Patient.View.Notification.NotificationView();
            window.ShowDialog();
        }

        private void Allergies_Click(object sender, RoutedEventArgs e)
        {
            ZdravoCorp.View.Patient.View.Allergies.AllergiesView w = new View.Allergies.AllergiesView();
            w.ShowDialog();
        }

        private void MedHistory_Click(object sender, RoutedEventArgs e)
        {
            View.MedicalHistory.MedicalHistory w = new View.MedicalHistory.MedicalHistory();
            w.ShowDialog();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            //PdfDocument doc = new PdfDocument();
            //PdfPage page = doc.Pages.Add();
            //PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 8);
            //PdfGraphics graphics = page.Graphics;
            //PdfGrid pdfGrid = new PdfGrid();
            //pdfGrid.DataSource = CurrentTherapies.DataContext;
            //pdfGrid.Draw(page, new PointF(10, 10));
            //doc.Save("ReportPatient.pdf");
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 24);
            PdfFont maliFont = new PdfStandardFont(PdfFontFamily.Helvetica, 16);



            //PdfBitmap image = new PdfBitmap("SecretaryPages\acc-icon.png");



            graphics.DrawString("ZdravoCorp", maliFont, PdfBrushes.Black, new PointF(400, 20));
            //PdfPen pen = page.;
            graphics.DrawLine(PdfPens.Black, new PointF(0, 50), new PointF(520, 50));
            //graphics.DrawString("Zauzetost prostorija u periodu od" + start.Day.ToString() + "." start.Month.ToString() + " do " + end.Date.ToString(), font, PdfBrushes.Black, new PointF(0, 70));
            graphics.DrawString("Izvestaj o rasporeu terapije na sedmicnom nivou", font, PdfBrushes.Black, new PointF(0, 70));
           // graphics.DrawString("Od " + start.Day.ToString() + "." + start.Month.ToString() + "." + start.Year.ToString() + " do " + end.Day.ToString() + "." + end.Month.ToString() + "." + end.Year.ToString(), font, PdfBrushes.Black, new PointF(0, 100));



            PdfLightTable pdfLightTable = new PdfLightTable();
            pdfLightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;
            pdfLightTable.Columns.Add(new PdfColumn(" Lek"));
            pdfLightTable.Columns.Add(new PdfColumn(" Pocetak terapije"));
            pdfLightTable.Columns.Add(new PdfColumn(" Dnevni broj doza"));
            pdfLightTable.Columns.Add(new PdfColumn(" Trajanje terapije"));



            //foreach (Room r in rooms)
            //{
            //    List<ScheduledAppointment> sa = (List<ScheduledAppointment>)app.ScheduledAppointmentController.GetFromToDatesForRoom(start, end, r.Id);
            //    pdfLightTable.Rows.Add(new object[] { " " + r.Name, " " + sa.Count });



            //}
            PrescriptionController prescriptionController = new PrescriptionController();
            int i = 0;
            foreach (Model.Prescription p in prescriptionController.GetAll())
            {
                if(i < 2)
                {
                    pdfLightTable.Rows.Add(new object[] { " " + p.Namee, " " + "13/6/2022", " " + p.TimesADay, " " + p.DurationDays});
                }
                else if(i >= 2 && i < 5)
                {
                    pdfLightTable.Rows.Add(new object[] { " " + p.Namee, " " + "15/6/2022", " " + p.TimesADay, " " + p.DurationDays });
                }
                else
                {
                    break;
                }
                i++;
                
            }

            PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
            PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 12);



            //Declare and define the alternate style.



            PdfCellStyle altStyle = new PdfCellStyle(font2, PdfBrushes.Black, PdfPens.Black);




            PdfCellStyle headerStyle = new PdfCellStyle(font1, PdfBrushes.Black, PdfPens.Black);
            headerStyle.BackgroundBrush = PdfBrushes.Navy;
            headerStyle.TextBrush = PdfBrushes.White;


            pdfLightTable.Style.DefaultStyle = altStyle;



            pdfLightTable.Style.HeaderStyle = headerStyle;



            pdfLightTable.Style.ShowHeader = true;



            pdfLightTable.Draw(page, new PointF(10, 150));
            doc.Save("ReportPatient.pdf");
            doc.Close(true);
        }

        public void SetPieChartHospital()
        {
            /**
             *https://ourcodeworld.com/articles/read/583/how-to-create-a-pie-chart-using-the-livecharts-library-in-winforms-c-sharp
             **/
            HospitalSurveyController hospitalSurveyController = new HospitalSurveyController();
            List<int> ocena1 = new List<int>();
            List<int> ocena2 = new List<int>();
            List<int> ocena3 = new List<int>();
            List<int> ocena4 = new List<int>();
            List<int> ocena5 = new List<int>();
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            SeriesCollection piechartData = new SeriesCollection
            {
                new PieSeries
                {
                    
                    Title = "Ocena 1",
                    Values = new ChartValues<double> {1},
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.LightGray
                },
                new PieSeries
                {
                    Title = "Ocena 2",
                    Values = new ChartValues<double> {3},
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.LightPink
                },
                new PieSeries
                {
                    Title = "Ocena 3",
                    Values = new ChartValues<double> {5},
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.LightBlue
                },
                new PieSeries
                {
                    Title = "Ocena 4",
                    Values = new ChartValues<double> {5},
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.LightCoral
                },
                new PieSeries
                {
                    Title = "Ocena 5",
                    Values = new ChartValues<double> {10},
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.LightGreen
                }
            };
            PieChartHospital.Series = piechartData;
            PieChartHospital.LegendLocation = LegendLocation.Right;
        }
        public void SetColSeries()
        {

        }
    }
}
