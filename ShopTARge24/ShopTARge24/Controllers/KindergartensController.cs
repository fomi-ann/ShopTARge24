using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Data;
using ShopTARge24.Models.Kindergartens;
using ShopTARge24.ApplicationServices.Services;


namespace ShopTARge24.Controllers
{
    public class KindergartensController : Controller
    {
        private readonly ShopTARge24Context _context;
        private readonly IKindergartenServices _kindergartenServices;

        public KindergartensController
            (
            ShopTARge24Context context,
            IKindergartenServices kindergartenServices
            )
        {
            _context = context;
            _kindergartenServices = kindergartenServices;
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

        [HttpGet]
        public IActionResult Create()
        {
            KindergartenCreateViewModel result = new();
            return View("Create", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(KindergartenCreateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                KindergartenName = vm.KindergartenName,
                ChildrenCount = vm.ChildrenCount,
                TeacherName = vm.TeacherName,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };

            var result = await _kindergartenServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
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