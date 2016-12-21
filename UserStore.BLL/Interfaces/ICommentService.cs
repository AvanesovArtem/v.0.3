using System.Collections.Generic;
using UserStore.BLL.DTO;

namespace UserStore.BLL.Interfaces
{
   public interface ICommentService
   {
        IList<CommentDTO> GetAllComment();
        void CreateComment(CommentDTO comment);
        void DeleteComment(int id);
        void Dispose();
    }
}
