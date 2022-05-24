using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;

namespace WebCam.Web.Pages
{
    public class IndexModel : PageModel
    {

        public IActionResult OnGet()
        {
            return Page();
        }


        public IActionResult OnPost([FromForm] byte[] image)
        {
            if (image != null)
            {
                if (! Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "WebCamImages")))
                {
                    Directory.CreateDirectory("WebCamImages");
                }
                string fileName = Guid.NewGuid().ToString();
                string path = Path.Combine(Directory.GetCurrentDirectory(), "WebCamImages", $"{fileName}.png");
                using (FileStream file = System.IO.File.Create(path))
                {
                    file.Write(image);
                }
                return RedirectToPage();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}