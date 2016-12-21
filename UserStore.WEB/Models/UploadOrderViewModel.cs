using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserStore.Models
{
    public class UploadOrderViewModel
    {
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