using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.ChuckNorrisDtos;
using Shop.Core.ServiceInterface;
using Shop.Models.ChuckNorris;

namespace Shop.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly IChuckNorrisServices _chuckNorrisServices;

        public ChuckNorrisController
            (
                IChuckNorrisServices chuckNorrisServices
            )
        {
            _chuckNorrisServices = chuckNorrisServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchChuckNorrisJokes(ChuckNorrisViewModel model)
        {
            return RedirectToAction("Joke", "ChuckNorris");
        }

        [HttpGet]
        public IActionResult Joke()
        {
            ChuckNorrisResultDto dto = new();

            _chuckNorrisServices.ChuckNorrisResult(dto);
            ChuckNorrisViewModel vm = new();

            //vm.Categories = dto.Categories;
            vm.Created_At = dto.CreatedAt;
            vm.Icon_Url = dto.IconUrl;
            vm.Id = dto.Id;
            vm.Updated_At = dto.UpdatedAt;
            vm.Url = dto.Url;
            vm.Value = dto.Value;

            return View(vm);
        }
    }
}
