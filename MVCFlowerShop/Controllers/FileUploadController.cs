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

            foreach (var FormFile in files)
            {
                //step 1: before pass the file, check the file content type
                if (FormFile.ContentType.ToLower() != "text/plain")
                {
                    return BadRequest("The " + Path.GetFileName(filepath) +
                        "is not a text file! Please upload a correct text file");
                }

                //step 2: chech whether the file is empty anot
                else if (FormFile.Length <= 0)
                {
                    return BadRequest("The " + Path.GetFileName(filepath) +
                        "is empty!");
                }

                //step 3: check file size got over limit anot
                else if (FormFile.Length > 1048576) //more than 1MB
                {
                    return BadRequest("The " + Path.GetFileName(filepath) +
    "is too big!");
                }
                //step 4: start to transfer the file to the correct destination
                else
                {
                    //e.g file path
                    var filedest = "file path" + i + ".txt";

                    using (var stream = new FileStream(filedest, FileMode.Create))
                    {
                        await FormFile.CopyToAsync(stream);
                    }

                    //read file
                    using (var reader = new StreamReader(FormFile.OpenReadStream()))

                    {
                        contents = contents + "\\n" + await reader.ReadToEndAsync();

                    }
                }
            }
            TempData["message"] = "Success Transfer" + contents;
            return RedirectToAction("Index");

        }
    }
}