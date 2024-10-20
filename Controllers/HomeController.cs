using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcProject.Models;

namespace MyMvcProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Upload(IFormFile fileToUpload)
    {
        if (fileToUpload == null || fileToUpload.Length == 0)
        {
            return Content("Please select a file to upload.");
        }

        // Save the file to a desired location (adjust the path as needed)
        string filePath = Path.Combine("Uploads", fileToUpload.FileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            fileToUpload.CopyTo(stream);
        }

        return Content($"File uploaded successfully: {fileToUpload.FileName}");
    }

}
