using Controller;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public RelayCommand CreateCommand { get; set; }

        public ViewSurveyViewModel(string description, string label)
        {
            Label = label;
            Description = description;

            CreateCommand = new RelayCommand(o =>
            {
                PdfDocument doc = new PdfDocument();
                PdfPage page = doc.Pages.Add();
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 8);
                PdfGraphics graphics = page.Graphics;
                graphics.DrawString(description, font, PdfBrushes.Black, new PointF(0, 0));
                doc.Save("Survey.pdf");
            });
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
