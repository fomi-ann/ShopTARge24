using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Data;
using ShopTARge24.Models.Kindergartens;

namespace ShopTARge24.Controllers
{
    public class KindergartensController : Controller
    {
        private readonly ShopTARge24Context _context;

        public KindergartensController
            (
            ShopTARge24Context context
            )
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Kindersgartens
                .Select(x => new KindergartenIndexViewModel
                {
                    Id = x.Id,
                    KindergartenName = x.KindergartenName,
                    GroupName = x.GroupName,
                    CreatedAt = x.CreatedAt,
                    TeacherName = x.TeacherName,
                    ChildrenCount = x.ChildrenCount,
                });
            return View(result);
        }
    }
}

//public class KindergartenIndexViewModel
//{
//    public Guid Id { get; set; }
//    public string GroupName { get; set; }
//    public int ChildrenCount { get; set; }
//    public string KindergartenName { get; set; }
//    public string TeacherName { get; set; }
//    public DateTime CreatedAt { get; set; }
//    public DateTime UpdatedAt { get; set; }

//}