using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.Controller
{
    public class CommentController
    {
        public Boolean CreateComment(Model.Comments newComment)
        {
            return Service.CommentService.Instance.CreateComment(newComment);
        }

        public Boolean UpdateComment(Model.Comments newComment)
        {
            return Service.CommentService.Instance.UpdateComment(newComment);
        }

        public Boolean DeleteComment(int identificator)
        {
            return Service.CommentService.Instance.DeleteComment(identificator);

        }

        public Model.Comments ReadComment(int identificator)
        {
            return Service.CommentService.Instance.ReadComment(identificator);

        }

        public List<Model.Comments> GetAllComments()
        {
            return Service.CommentService.Instance.GetAllComments();

        }

    }
}
