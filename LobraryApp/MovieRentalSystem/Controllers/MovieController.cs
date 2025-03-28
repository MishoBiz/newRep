using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;

namespace MovieRentalSystem.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all movies (Admin & User)
        public async Task<IActionResult> Index(string search)
        {
            var movies = _context.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                movies = movies.Where(m => m.Title.Contains(search) || m.Genre.Contains(search) || m.Director.Contains(search));
            }

            return View(await movies.ToListAsync());
        }

        // Admin: Add a new movie
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Title, Director, Genre, ReleaseYear")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // Admin: Edit movie details
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Title, Director, Genre, ReleaseYear, IsAvailable")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // Admin: Delete movie
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Rent a movie
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Rent(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null || !movie.IsAvailable)
            {
                return NotFound();
            }

            movie.IsAvailable = false;
            movie.RentedById = User.Identity.Name; // Set the current logged-in user as the renter
            movie.RentalDate = DateTime.Now;

            _context.Update(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Return a rented movie
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Return(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null || movie.RentedById != User.Identity.Name)
            {
                return NotFound();
            }

            movie.IsAvailable = true;
            movie.RentedById = null;
            movie.RentalDate = null;
            movie.ReturnDate = DateTime.Now;

            _context.Update(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
