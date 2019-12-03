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
            int i = 1; string contents = "";

            foreach(var FormFile in files)
            {
                //step 1: before pass the file, check the file content type
                if(FormFile.ContentType.ToLower() != "text/plain")
                {
                    return BadRequest("The " + Path.GetFileName(filepath) +
                        "is not a text file! Please upload a correct text file");
                }
            }
            return RedirectToAction("Index");

        }
    }
}