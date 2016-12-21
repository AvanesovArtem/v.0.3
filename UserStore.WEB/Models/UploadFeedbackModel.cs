using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserStore.Models
{
    public class UploadFeedbackModel
    {
        [Required(ErrorMessage = "Сообщение не может быть пустым")]
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string UserName { get; set; }
    }
}