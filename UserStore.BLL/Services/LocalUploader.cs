using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace UserStore.BLL.Services
{
   static class LocalUploader
    {
        public static string SaveImage(HttpPostedFileBase image, string path,string name)
        {
            Bitmap bitmap = new Bitmap(new Bitmap(image.InputStream), 350, 260);
            bitmap.Save(path, ImageFormat.Jpeg);
            string filePath = "~/Image/" + name.Replace(" ", "") + ".png";
            return filePath;
        }
    }
}
