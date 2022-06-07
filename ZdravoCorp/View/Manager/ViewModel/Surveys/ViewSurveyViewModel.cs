using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.View.Core;

namespace ZdravoCorp.View.Manager.ViewModel.Surveys
{
    public class ViewSurveyViewModel : ObservableObject, ViewModelInterface
    {
        private string label;
        private string description;

        public ViewSurveyViewModel(string description, string label)
        {
            Label = label;
            Description = description;
        }

        public string Label
        {
            get => label;
            set
            {
                if (value != label)
                {
                    label = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged();
                }
            }
        }

        public string GetTitle()
        {
            return "ViewSurvey";
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }
    }
}
