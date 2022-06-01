using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.Repository
{
    internal class ReportRepository
    {

        private String dbPath = "..\\..\\Data\\commentsDB.csv";
        private Serializer<Report> serializerComments = new Serializer<Model.Report>();

        private static ReportRepository instance = null;
        public Boolean CreateComment(Model.Report newComment)
        {
            List<Report> comments = GetAllComments();
            int id = comments.Count + 1;
            newComment.Id = id;
            comments.Add(newComment);
            serializerComments.ToCSV(dbPath, comments);
            return true;

        }

        public Boolean UpdateComment(Model.Report newComment)
        {
            Boolean success = false;
            List<Report> comments = GetAllComments();
            foreach (Report c in comments)
            {
                if (newComment.Id.Equals(c.Id))
                {
                    success = true;
                    comments.Remove(c);
                    break;
                }
            }
            if (success)
            {
                comments.Add(newComment);
                serializerComments.ToCSV(dbPath, comments);

            }
            return success;
        }

        public Boolean DeleteComment(int identificator)
        {
            Boolean success = false;
            List<Report> comments = GetAllComments();
            foreach (Report c in comments)
            {
                if (identificator == c.Id)
                {
                    success = true;
                    comments.Remove(c);
                    serializerComments.ToCSV(dbPath, comments);
                    break;
                }
            }
            return success;
        }

        public Model.Report ReadComment(int indentificator)
        {
            List<Report> comments = GetAllComments();
            foreach (Report c in comments)
            {
                if (indentificator == c.Id)
                {
                    return c;
                }
            }
            return null;
        }

        public List<Model.Report> GetAllComments()
        {
            return serializerComments.FromCSV(dbPath);
        }

        public ReportRepository()
        { }

        public static ReportRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReportRepository();
                }
                return instance;
            }
        }
    }
}
