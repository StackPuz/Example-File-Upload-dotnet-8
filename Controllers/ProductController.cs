using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ProductController : Controller
    {
        [HttpPost("submit")]
        public IActionResult Submit([FromForm] Models.Product model)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            if (!Directory.Exists(uploadPath)) {
                Directory.CreateDirectory(uploadPath);
            }
            var filePath = Path.Combine(uploadPath, model.Image.FileName);
            using (var target = new FileStream(filePath, FileMode.Create)) {
                model.Image.CopyTo(target);
            }
            return Ok(new {
                Name = model.Name,
                Image = model.Image.FileName
            });
        }
    }
}