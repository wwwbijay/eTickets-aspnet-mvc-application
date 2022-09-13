using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;
        public CinemasController(ICinemaService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var cinemas = await _service.GetAllAsync();
            return View(cinemas);
        }
        //GET: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Logo, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            
            await _service.AddAsync(cinema);

            return RedirectToAction(nameof(Index));

        }

        //GET: Cinemas/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("Not Found");
            return View(cinemaDetails);

        }
        //GET: Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("Not Found");
            return View(cinemaDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Logo, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.UpdateAsync(id, cinema);

            return RedirectToAction(nameof(Index));

        }
        //GET: Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("Not Found");
            return View(cinemaDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("Not Found");


            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
