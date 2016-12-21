using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStore.BLL.DTO
{
   public class UploadOrderDTO
    {
        public string UserEmail { get; set; }
        public int NumberOfHome { get; set; }
        public int Housing { get; set; }
        public string Street { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public int NumberOfFlat { get; set; }
        public int Access { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }
}
