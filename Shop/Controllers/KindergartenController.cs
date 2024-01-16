using Microsoft.AspNetCore.Mvc;
using Shop.Models.Kindergarten;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;

namespace Shop.Controllers
{
    public class KindergartenController : Controller
    {

        private readonly ShopContext _context;
        private readonly IKindergartenServices _kindergartenServices;

        public KindergartenController
            (
                ShopContext context,
                IKindergartenServices kindergartenServices
            )
        {
            _context = context;
            _kindergartenServices = kindergartenServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Kindergartens
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new Shop.Models.Kindergarten.KindergartenIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    Teacher = x.Teacher,
                    ChildrenCount = x.ChildrenCount,
                    KindergartenName = x.KindergartenName,
                });

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var kindergarten = await _kindergartenServices.GetAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            var vm = new Shop.Models.Kindergarten.KindergartenDetailsViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.Teacher = kindergarten.Teacher;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.ModifiedAt = kindergarten.ModifiedAt;

            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            KindergartenCreateUpdateViewModel vm = new();

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(KindergartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {


                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                Teacher = vm.Teacher,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,

            };

            var result = await _kindergartenServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var kindergarten = await _kindergartenServices.GetAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            var vm = new KindergartenCreateUpdateViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.Teacher = kindergarten.Teacher;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.ModifiedAt = kindergarten.ModifiedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(KindergartenCreateUpdateViewModel vm)
        {

            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                Teacher = vm.Teacher,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,

            };

            var result = await _kindergartenServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var kindergarten = await _kindergartenServices.GetAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            var vm = new KindergartenDeleteViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.Teacher = kindergarten.Teacher;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.ModifiedAt = kindergarten.ModifiedAt;

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var kindergartenId = await _kindergartenServices.Delete(id);

            if (kindergartenId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
