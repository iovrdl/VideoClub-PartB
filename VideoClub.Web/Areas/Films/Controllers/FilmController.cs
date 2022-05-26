using System.Threading.Tasks;
using System.Web.Mvc;
using VideoClub.Core.Entities;
using VideoClub.Core.Enumeration;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Models.Dtos;
using VideoClub.Infrastructure.Services.Interfaces;
using VideoClub.Web.Areas.Films.Models;

namespace VideoClub.Web.Areas.Films.Controllers
{
    [Authorize]
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly ICopyService _copyService;
        private readonly IPaginationService _paginationService;

        public FilmController(IFilmService filmService, ICopyService copyService, IPaginationService paginationService)
        {
            _filmService = filmService;
            _copyService = copyService;
            _paginationService = paginationService;
        }

        public async Task<ActionResult> Index(int? page, string search, Genre? genre)
        {
            var pagination = new PaginationDto(page, 5);
            var films = await _paginationService.GetPaginatedFilms(pagination, search, genre);

            return View(films);
        }

        [HttpGet]
        public ActionResult Rent(int filmId)
        {
            return RedirectToAction("Create", "Rental", new { area = "Rentals", filmId });
        }

        [HttpGet]
        public ActionResult Details(int filmId)
        {
            var model = _filmService.Get(filmId);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var model = new CreateFilmBindingModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CreateFilmBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var film = new Film
            {
                Title = model.Title,
                Description = model.Description,
                Genre = model.Genre
            };

            _filmService.Add(film);
            _copyService.Add(film.Id, model.Copies);

            return RedirectToAction("Index");
        }
    }
}