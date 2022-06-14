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
using Model;
using Controller;
using System.Collections.ObjectModel;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Tables;
using Syncfusion.Pdf.Graphics;
using System.Drawing;

namespace ZdravoCorp.View.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryAppointments.xaml
    /// </summary>
    public partial class SecretaryAppointments : Page
    {
        private SecretaryMainWindow secretaryMainWindow;
        private SecretaryMainPage secretaryMainPage;

        public ObservableCollection<Model.Patient> PatientCollection { get; set; }
        public ObservableCollection<Model.Appointment> AppointmentsCollection { get; set; }
        public PatientController patientController;
        public AppointmentController appointmentController;
        Model.Patient patient;

        private Model.Secretary secretary;

        public ObservableCollection<Model.Guest> GuestCollection { get; set; }
        public GuestController guestController;
        public SecretaryAppointments(SecretaryMainPage smp, SecretaryMainWindow secretaryMainWindow)
        {
            InitializeComponent();
            this.secretaryMainPage = smp;
            this.secretaryMainWindow = secretaryMainWindow;

            UpdateAppointmentTable();
        }

        private void UpdateAppointmentTable()
        {
            DoctorController doctorController = new DoctorController();
            AppointmentController appointmentController = new AppointmentController();
            RoomController roomController = new RoomController();
            patientController = new PatientController();

            List<Appointment> appointments = appointmentController.GetAll();

            AppointmentsCollection = new ObservableCollection<Appointment>(appointments);
            foreach (Appointment a in appointments)
            {
                a.doctor = doctorController.Read(a.doctor.Id);
                a.room = roomController.Read(a.room.Identifier);
                a.Patient = patientController.Read(a.Patient.Id);
            }
            AppointmentTable.DataContext = AppointmentsCollection;
        }
        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            AddAppointment window = new AddAppointment();
            window.ShowDialog();
            UpdateAppointmentTable();
        }
        private void EditAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (AppointmentTable.SelectedIndex == -1)
            {
                return;
            }
            ChangeAppointment window = new ChangeAppointment(AppointmentsCollection.ElementAt(AppointmentTable.SelectedIndex));
            window.ShowDialog();
            UpdateAppointmentTable();
        }
        private void DeleteAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (AppointmentTable.SelectedIndex == -1)
            {
                return;
            }
            Appointment appointment = (Appointment)AppointmentTable.SelectedItem;
            appointmentController = new AppointmentController();
            appointmentController.Delete(appointment.Id);

            DoctorController doctorController = new DoctorController();
            Model.Doctor doctor = doctorController.Read(appointment.Doctor.Id);
            doctor.RemoveAppointment(appointment);
            doctorController.Update(doctor);
            RoomController roomController = new RoomController();
            Model.Room room = roomController.Read(appointment.Room.Identifier);
            room.RemoveAppointment(appointment);
            roomController.Update(room);
            Model.Patient patient = patientController.Read(appointment.Patient.Id);
            patient.RemoveAppointment(appointment);
            patientController.Update(patient);

            UpdateAppointmentTable();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            
            secretaryMainWindow.Content = secretaryMainPage;

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
            graphics.DrawString("Nedeljni izvestaj o zakazanim operacijama\ni pregledima", font, PdfBrushes.Black, new PointF(0, 70));
            // graphics.DrawString("Od " + start.Day.ToString() + "." + start.Month.ToString() + "." + start.Year.ToString() + " do " + end.Day.ToString() + "." + end.Month.ToString() + "." + end.Year.ToString(), font, PdfBrushes.Black, new PointF(0, 100));



            PdfLightTable pdfLightTable = new PdfLightTable();
            pdfLightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;
            pdfLightTable.Columns.Add(new PdfColumn(" Doktor"));
            pdfLightTable.Columns.Add(new PdfColumn(" Pacijent"));
            pdfLightTable.Columns.Add(new PdfColumn(" Pocetak termina"));
            pdfLightTable.Columns.Add(new PdfColumn(" Kraj termina"));
            pdfLightTable.Columns.Add(new PdfColumn(" Soba"));



            //foreach (Room r in rooms)
            //{
            //    List<ScheduledAppointment> sa = (List<ScheduledAppointment>)app.ScheduledAppointmentController.GetFromToDatesForRoom(start, end, r.Id);
            //    pdfLightTable.Rows.Add(new object[] { " " + r.Name, " " + sa.Count });



            //}
            AppointmentController appointmentController = new AppointmentController();
            //PrescriptionController prescriptionController = new PrescriptionController();
            PatientController pc = new PatientController();
            DoctorController dc = new DoctorController();
            RoomController rc = new RoomController();
            int i = 0;
            foreach (Model.Appointment a in appointmentController.GetAll())
            {
                if ((a.startDate.Date > new DateTime(2022, 5, 29)) && (a.startDate.Date < new DateTime(2022, 6, 6))) {
                    pdfLightTable.Rows.Add(new object[] { " " + dc.Read(a.Doctor.Id).nameSurname, " " + pc.Read(a.Patient.Id).PatNameSurname, " " + a.StartDate.ToString(), " " +a.EndDate.ToString(), " " +rc.Read(a.Room.Identifier).DesignationCode });
                }
                //if (i < 2)
                //{
                //    pdfLightTable.Rows.Add(new object[] { " " + p.Namee, " " + "13/6/2022", " " + p.TimesADay, " " + p.DurationDays });
                //}
                //else if (i >= 2 && i < 5)
                //{
                //    pdfLightTable.Rows.Add(new object[] { " " + p.Namee, " " + "15/6/2022", " " + p.TimesADay, " " + p.DurationDays });
                //}
                //else
                //{
                //    break;
                //}
                //i++;

            }

            PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
            PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 12);



            //Declare and define the alternate style.



            PdfCellStyle altStyle = new PdfCellStyle(font2, PdfBrushes.Black, PdfPens.Black);




            PdfCellStyle headerStyle = new PdfCellStyle(font1, PdfBrushes.Black, PdfPens.Black);
            headerStyle.BackgroundBrush = PdfBrushes.LightGray;
            headerStyle.TextBrush = PdfBrushes.Black;


            pdfLightTable.Style.DefaultStyle = altStyle;



            pdfLightTable.Style.HeaderStyle = headerStyle;



            pdfLightTable.Style.ShowHeader = true;



            pdfLightTable.Draw(page, new PointF(10, 150));
            doc.Save("SecretaryReport.pdf");
            doc.Close(true);
        }
    }
}
