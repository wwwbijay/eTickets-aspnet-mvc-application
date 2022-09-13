using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _service.GetAllAsync(n => n.Cinema);
            return View(movies);
        }
        //Get Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            return View(movieDetails);
        }
        //Get Movies/Create/1
        public async Task<IActionResult> Create()
        {
            var movieDropdownData = await _service.NewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }
        //Get Movies/Create/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if(movieDetails == null) return View("Not Found");

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                MovieCategory = movieDetails.MovieCategory,
                ImageUrl = movieDetails.ImageUrl,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),

            };
    
            var movieDropdownData = await _service.NewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("Not Found");
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }


    }
}
