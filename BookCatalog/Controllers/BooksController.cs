using BookCatalog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Controllers;

public class BooksController : Controller
{
    private readonly AppDbContext _db;

    public BooksController(AppDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var books = await _db.Books.OrderBy(b => b.Title).ToListAsync();
        return View(books);
    }

    public async Task<IActionResult> Details(int id)
    {
        var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book == null) return NotFound();
        return View(book);
    }
}