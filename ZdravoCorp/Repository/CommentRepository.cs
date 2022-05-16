using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.Repository
{
    internal class CommentRepository
    {

        private String dbPath = "..\\..\\Data\\commentsDB.csv";
        private Serializer<Comments> serializerComments = new Serializer<Model.Comments>();

        private static CommentRepository instance = null;
        public Boolean CreateComment(Model.Comments newComment)
        {
            List<Comments> comments = GetAllComments();
            int id = comments.Count + 1;
            newComment.Id = id;
            comments.Add(newComment);
            serializerComments.ToCSV(dbPath, comments);
            return true;

        }

        public Boolean UpdateComment(Model.Comments newComment)
        {
            Boolean success = false;
            List<Comments> comments = GetAllComments();
            foreach (Comments c in comments)
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
            List<Comments> comments = GetAllComments();
            foreach (Comments c in comments)
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

        public Model.Comments ReadComment(int indentificator)
        {
            List<Comments> comments = GetAllComments();
            foreach (Comments c in comments)
            {
                if (indentificator == c.Id)
                {
                    return c;
                }
            }
            return null;
        }

        public List<Model.Comments> GetAllComments()
        {
            return serializerComments.FromCSV(dbPath);
        }

        public CommentRepository()
        { }

        public static CommentRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommentRepository();
                }
                return instance;
            }
        }
    }
}
