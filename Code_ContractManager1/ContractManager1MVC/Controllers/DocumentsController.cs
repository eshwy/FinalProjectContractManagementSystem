using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContractManager1MVC.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public IActionResult Index()
        {
            List<string> docs = Directory.GetFiles(wwwrootDirectory).Select(Path.GetFileName).ToList();
            ViewBag.test = docs;
            return View(docs);
        }

        [HttpPost]  
        public async Task<IActionResult> Index(IFormFile mydoc)
        {
            if(mydoc != null)
            {
                var path = Path.Combine(wwwrootDirectory, Path.GetFileNameWithoutExtension(mydoc.FileName) + Path.GetExtension(mydoc.FileName));

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await mydoc.CopyToAsync(stream);
                }
            }
            return View();
        }
        public async Task<IActionResult> Download(string filePath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",filePath);
            var memory = new MemoryStream();
            using (var stream= new FileStream(path,FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);
            return File(memory, contentType, fileName);
        }
    }
}
