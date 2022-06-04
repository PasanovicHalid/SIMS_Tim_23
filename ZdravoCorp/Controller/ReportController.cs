using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;
using Service;

namespace Controller
{
    public class ReportController : ICrud<Report>
    {
        public void Create(Model.Report newComment)
        {
            ReportService.Instance.Create(newComment);
        }

        public void Update(Model.Report newComment)
        {
            ReportService.Instance.Update(newComment);
        }

        public void Delete(int identificator)
        {
            ReportService.Instance.Delete(identificator);

        }

        public Report Read(int identificator)
        {
            return ReportService.Instance.Read(identificator);

        }

        public List<Report> GetAll()
        {
            return ReportService.Instance.GetAll();

        }

    }
}
