using Controller;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ZdravoCorp.View.Core;

namespace ZdravoCorp.View.Manager.ViewModel.Surveys
{
    public class SurveysViewModel : ObservableObject, ViewModelInterface
    {
        private SurveyController controller;
        private HospitalSurveyController hospitalController;
        private AppointmentSurveyController appointmentController;
        private ObservableCollection<Survey> surveys;
        private Survey survey;

        public SurveysViewModel()
        {
            controller = new SurveyController();
            hospitalController = new HospitalSurveyController();
            appointmentController = new AppointmentSurveyController();
            surveys = new ObservableCollection<Survey>(controller.GetAll());

            ViewCommand = new RelayCommand(o =>
            {
                string description = "";
                string label = "";
                if (survey.SurveyType == SurveyEnum.Hospital)
                {
                    description = hospitalController.GetResults();
                    label = "Hospital Survey";
                }
                else
                {
                    description = appointmentController.GetResultsForDoctor(DoctorService.Instance.Read(survey.Id));
                    label = survey.Name + "Survey";
                }
                CurrentView = new View.Surveys.ViewSurvey(new ViewSurveyViewModel(description, label));
            }, CheckIfReady);
        }

        public bool CheckIfReady(object obj)
        {
            return survey != null;
        }

        public RelayCommand ViewCommand { get; set; }

        public ObservableCollection<Survey> Surveys
        {
            get { return surveys; }
            set
            {
                if (value != surveys)
                {
                    surveys = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public Survey Survey
        {
            get { return survey; }
            set
            {
                if (value != survey)
                {
                    survey = value;
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
            //throw new NotImplementedException();
        }
    }
}
