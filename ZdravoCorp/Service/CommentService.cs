using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.Service
{
    internal class CommentService
    {
        private static CommentService instance = null;
        public Boolean CreateComment(Model.Comments newComment)
        {
            return Repository.CommentRepository.Instance.CreateComment(newComment);
        }

        public Boolean UpdateComment(Model.Comments newComment)
        {
            return Repository.CommentRepository.Instance.UpdateComment(newComment);

        }

        public Boolean DeleteComment(int identificator)
        {
            return Repository.CommentRepository.Instance.DeleteComment(identificator);

        }

        public Model.Comments ReadComment(int identificator)
        {
            return Repository.CommentRepository.Instance.ReadComment(identificator);

        }

        public List<Model.Comments> GetAllComments()
        {
            return Repository.CommentRepository.Instance.GetAllComments();

        }

        public static CommentService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommentService();
                }

                return instance;
            }
        }

    }
}
