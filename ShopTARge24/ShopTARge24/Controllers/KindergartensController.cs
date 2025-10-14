using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Data;
using ShopTARge24.Models.Kindergartens;
using ShopTARge24.ApplicationServices.Services;
using ShopTARge24.Core.Domain;
using Microsoft.EntityFrameworkCore;


namespace ShopTARge24.Controllers
{
    public class KindergartensController : Controller
    {
        private readonly ShopTARge24Context _context;
        private readonly IKindergartenServices _kindergartenServices;
        private readonly IFileServices _fileServices;

        public KindergartensController
            (
            ShopTARge24Context context,
            IKindergartenServices kindergartenServices,
            IFileServices fileServices
            )
        {
            _context = context;
            _kindergartenServices = kindergartenServices;
            _fileServices = fileServices;
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
            KindergartenCreateUpdateViewModel result = new();
            return View("CreateUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(KindergartenCreateUpdateViewModel vm)
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

                Files = vm.Files,
                Images = vm.Images
                .Select(x => new FileToDBdto{
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    KindergartenId = x.KindergartenId
                }).ToArray()
            };

            var result = await _kindergartenServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var kindergarten = await _kindergartenServices.DetailAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            KindergartenImageViewModel[] images = await FilesFromDB(id);

            var vm = new KindergartenCreateUpdateViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.TeacherName = kindergarten.TeacherName;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            vm.Images.AddRange(images);

            return View("CreateUpdate", vm);

        }

        [HttpPost]
        public async Task<IActionResult> Update(KindergartenCreateUpdateViewModel vm)
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

                Files = vm.Files,
                Images = vm.Images
                .Select(x => new FileToDBdto
                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    KindergartenId = x.KindergartenId
                }).ToArray()
            };

            var result = await _kindergartenServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var kindergarten = await _kindergartenServices.DetailAsync(id);
            if (kindergarten == null)
            {
                return NotFound();
            }

            KindergartenImageViewModel[] images = await FilesFromDB(id);

            var vm = new KindergartenDeleteViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.TeacherName = kindergarten.TeacherName;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            vm.Images.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var kindergarten = await _kindergartenServices.Delete(id);

            if (kindergarten == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var kindergarten = await _kindergartenServices.DetailAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            KindergartenImageViewModel[] images = await FilesFromDB(id);

            var vm = new KindergartenDetailsViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.TeacherName = kindergarten.TeacherName;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            vm.Images.AddRange(images);

            return View(vm);
        }

        private async Task<KindergartenImageViewModel[]> FilesFromDB(Guid id)
        {
            return await _context.FileToDBs
                .Where(x => x.KindergartenId == id)
                .Select(y => new KindergartenImageViewModel
                {
                    Id = y.Id,
                    KindergartenId = y.KindergartenId,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveImage(Guid imageId, Guid kindergartenId)
        {
            await _fileServices.RemoveImageFromDB(imageId);


            return RedirectToAction(nameof(Update), new { id = kindergartenId });
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