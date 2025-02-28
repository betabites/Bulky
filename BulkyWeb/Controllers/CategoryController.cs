using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyWeb.Controllers;

public class CategoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}