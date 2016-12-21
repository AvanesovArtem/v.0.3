using System;

namespace UserStore.BLL.DTO
{
   public class CommentDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}
