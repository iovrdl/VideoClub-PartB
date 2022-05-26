using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Web.Areas.Rentals.Models;

namespace VideoClub.Web.Areas.Rentals.Controllers
{
    [Authorize]
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;
        private readonly IFilmService _filmService;
        private readonly ICopyService _copyService;
        private readonly ICustomerService _customerService;

        public RentalController(IRentalService rentalService, IFilmService filmService,
            ICopyService copyService, ICustomerService customerService)
        {
            _rentalService = rentalService;
            _filmService = filmService;
            _copyService = copyService;
            _customerService = customerService;
        }

        public ActionResult Index(string customerId)
        {
            IEnumerable<Rental> model;

            if (!User.IsInRole("Admin"))
            {
                customerId = User.Identity.GetUserId();
                model = _rentalService.GetByCustomerId(customerId);
            }
            else
            {
                model = customerId == null
                    ? _rentalService.GetActive()
                    : _rentalService.GetByCustomerId(customerId);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create(int? filmId, string customerId)
        {
            if (!User.IsInRole("Admin"))
            {
                customerId = User.Identity.GetUserId();
            }

            var model = new CreateRentalBindingModel
            {
                CustomerId = customerId,
                Films = new List<Film>(_filmService.GetAvailable()),
                Customers = new List<Customer>(_customerService.GetAll())
            };

            if (filmId != null)
            {
                model.FilmId = (int)filmId;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRentalBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var copy = _copyService.GetFirstAvailable(model.FilmId);

            var rental = new Rental
            {
                FilmId = model.FilmId,
                CopyId = copy.Id,
                CustomerId = model.CustomerId,
                RentalDate = model.RentalDate,
                ReturnDate = model.ReturnDate,
                Note = model.Note,
                IsActive = true
            };

            _rentalService.Add(rental);
            _copyService.UpdateIsAvailable(copy.Id, false);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Return(int rentalId)
        {
            var rental = _rentalService.Get(rentalId);
            _rentalService.UpdateIsActive(rental.Id, false);
            _copyService.UpdateIsAvailable(rental.CopyId, true);

            return RedirectToAction("Index");
        }
    }
}