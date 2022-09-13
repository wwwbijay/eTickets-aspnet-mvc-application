using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class MoviesService:EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context) 
        {
            _context = context;    
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var MovieDetails = await _context.Movies
                .Include(c=>c.Cinema)
                .Include(p=>p.Producer)
                .Include(am=>am.Actors_Movies).ThenInclude(a=>a.Actor)
                .FirstOrDefaultAsync(n=> id == n.Id);

            return MovieDetails;
        }

        public async Task<NewMovieDropdownVM> NewMovieDropdownValues()
        {
            var response = new NewMovieDropdownVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
            };
            return response;
        }
    }
}
