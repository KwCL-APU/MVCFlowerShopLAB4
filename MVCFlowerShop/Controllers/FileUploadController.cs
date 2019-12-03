using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCFlowerShop.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post (List<IFormFile>files)
        {

            long sizes = files.Sum(f => f.Length);
            var filepath = Path.GetTempFileName();
            return RedirectToAction("Index");

        }
    }
}