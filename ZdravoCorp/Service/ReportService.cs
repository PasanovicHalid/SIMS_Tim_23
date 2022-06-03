using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Service
{
    internal class ReportService : ICrud<Report>
    {
        private static ReportService instance = null;
        public void Create(Report newReport)
        {
            ReportRepository.Instance.Create(newReport);
        }

        public void Update(Model.Report newReport)
        {
            ReportRepository.Instance.Update(newReport);

        }

        public void Delete(int id)
        {
            ReportRepository.Instance.Delete(id);

        }

        public Report Read(int id)
        {
            return ReportRepository.Instance.Read(id);

        }

        public List<Report> GetAll()
        {
            return ReportRepository.Instance.GetAll();

        }

        ReportService() 
        { }

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
