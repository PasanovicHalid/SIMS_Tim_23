using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class SurveyController : ICrud<Survey>
    {
        public void Create(Survey element)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Survey> GetAll()
        {
            return SurveyService.Instance.GetAll();
        }

        public Survey Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Survey element)
        {
            throw new NotImplementedException();
        }
    }
}
