using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace UserStore.BLL.DTO
{
   public class UploadProductDTO
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Absolutepath { get; set; }
        public decimal Price { get; set; }
        public HttpPostedFileBase Image { get; set; }


    }
}
