using System.Web.Mvc;
using VideoClub.Core.Interfaces;

namespace VideoClub.Web.Areas.Customers.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            var model = _customerService.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Rent(string customerId)
        {
            return RedirectToAction("Create", "Rental", new { area = "Rentals", customerId });
        }

        [HttpGet]
        public ActionResult Return(string rentalId)
        {
            return RedirectToAction("Return", "Rental", new { area = "Rentals", rentalId });
        }

        [HttpGet]
        public ActionResult ActiveRentals(string customerId)
        {
            return RedirectToAction("Index", "Rental", new { area = "Rentals", customerId });
        }

        [HttpGet]
        public ActionResult Details(string customerId)
        {
            var model = _customerService.Get(customerId);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }
    }
}