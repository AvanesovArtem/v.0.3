using System;

namespace UserStore.DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}