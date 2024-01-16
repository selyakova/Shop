using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Models.Email;

namespace Shop.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailServices _emailServices;

        public EmailController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmailDto dto = new EmailDto()
                {
                    To = model.To,
                    Subject = model.Subject,
                    Body = model.Body
                };

                _emailServices.SendEmail(dto);
                return View(model);
            }

            return View(nameof(Index));
        }
    }
}
