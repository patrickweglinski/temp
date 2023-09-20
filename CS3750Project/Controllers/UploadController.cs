using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourProject.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace YourProject.Controllers
{
    public class UploadController : Controller
    {
        // GET: Image/Index
        public IActionResult Index()
        {
            return View();
        }

        // POST: Image/Upload
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "Please select a file to upload.";
                return View("Index");
            }

            // Generate a unique filename for the uploaded image
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);

            // Define the path where the file will be saved
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads", uniqueFileName);

            // Save the file to the specified path
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // You can save additional information about the image in your database here
            // For now, let's assume a simple ImageModel
            var imageModel = new ImageModel
            {
                FileName = uniqueFileName,
                FilePath = filePath,
                UploadDate = DateTime.Now
            };

            // TODO: Save imageModel to your database
         
          
            ViewBag.Message = "File uploaded successfully!";
            ViewBag.ImagePath = uniqueFileName; // Pass the image path to the view
            ViewBag.FilePath = filePath;

            return View("Index");


        }
    }
}