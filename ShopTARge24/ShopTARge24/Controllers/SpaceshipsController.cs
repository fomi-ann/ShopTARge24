using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Data;

namespace ShopTARge24.Controllers
{

    public class SpaceshipsController : Controller
    {
        private readonly ShopTARge24Context _context;

        public SpaceshipsController
            (
            
            )
        {

        }
        public IActionResult Index()
        {
            var result = 
            return View();
        }
    }
}
