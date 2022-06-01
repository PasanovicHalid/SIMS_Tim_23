using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.Controller
{
    public class ReportController
    {
        public Boolean CreateComment(Model.Report newComment)
        {
            return Service.ReportService.Instance.CreateComment(newComment);
        }

        public Boolean UpdateComment(Model.Report newComment)
        {
            return Service.ReportService.Instance.UpdateComment(newComment);
        }

        public Boolean DeleteComment(int identificator)
        {
            return Service.ReportService.Instance.DeleteComment(identificator);

        }

        public Model.Report ReadComment(int identificator)
        {
            return Service.ReportService.Instance.ReadComment(identificator);

        }

        public List<Model.Report> GetAllComments()
        {
            return Service.ReportService.Instance.GetAllComments();

        }

    }
}
