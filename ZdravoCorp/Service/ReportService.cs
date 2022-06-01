using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.Service
{
    internal class ReportService
    {
        private static ReportService instance = null;
        public Boolean CreateComment(Model.Report newComment)
        {
            return Repository.ReportRepository.Instance.CreateComment(newComment);
        }

        public Boolean UpdateComment(Model.Report newComment)
        {
            return Repository.ReportRepository.Instance.UpdateComment(newComment);

        }

        public Boolean DeleteComment(int identificator)
        {
            return Repository.ReportRepository.Instance.DeleteComment(identificator);

        }

        public Model.Report ReadComment(int identificator)
        {
            return Repository.ReportRepository.Instance.ReadComment(identificator);

        }

        public List<Model.Report> GetAllComments()
        {
            return Repository.ReportRepository.Instance.GetAllComments();

        }

        public static ReportService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReportService();
                }

                return instance;
            }
        }

    }
}
