using Libraryapp2.Data;
using Libraryapp2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class BookController : Controller
{
    private readonly LibraryDbContext _context;

    public BookController(LibraryDbContext context)
    {
        _context = context;
    }

    // GET: Book/Index
    public async Task<IActionResult> Index()
    {
        var books = await _context.Books.ToListAsync();
        return View(books);
    }

    // GET: Book/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    // POST: Book/Borrow/5
    [HttpPost]
    public async Task<IActionResult> Borrow(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null || book.Status == "Borrowed")
        {
            return NotFound();
        }

        book.Status = "Borrowed";
        // Set the borrower as the logged-in user
        book.BorrowedById = User.Identity.Name; // Or get user from session

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // POST: Book/Return/5
    [HttpPost]
    public async Task<IActionResult> Return(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null || book.Status == "Available")
        {
            return NotFound();
        }

        book.Status = "Available";
        book.BorrowedById = null; // Clear the borrowed info

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}