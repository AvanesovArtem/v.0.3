using System.Collections.Generic;
using AutoMapper;
using UserStore.BLL.DTO;
using UserStore.BLL.Interfaces;
using UserStore.DAL.Interfaces;
using UserStore.DAL.Entities;

namespace UserStore.BLL.Services
{
   public class CommentService:ICommentService
   {
        private IUnitOfWork Uow { get; set; }
        public CommentService(IUnitOfWork db)
        {
            Uow = db;
        }

        public IList<CommentDTO> GetAllComment()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentDTO>());
            var commentDto = Mapper.Map<IEnumerable<Comment>, IList<CommentDTO>>(Uow.Comments.GetAll());
            return commentDto;
        }

        public void CreateComment(CommentDTO commentDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CommentDTO, Comment>());  
            var comment = Mapper.Map<CommentDTO, Comment>(commentDto);
            Uow.Comments.Create(comment);
            Uow.Save();

        }

       public void DeleteComment(int id)
       {
           var comment = Uow.Comments.GetById(id);      
           Uow.Comments.Delete(comment);
           Uow.Save();
        }

       public void Dispose()
       {
           Uow.Dispose();
       }
    }
}
