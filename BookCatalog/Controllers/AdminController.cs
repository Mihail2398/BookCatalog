using BookCatalog.Data;
using BookCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Controllers;

public class AdminController : Controller
{
    private readonly AppDbContext _db;

    public AdminController(AppDbContext db) => _db = db;

    // GET: /Admin
    public async Task<IActionResult> Index()
    {
        var books = await _db.Books.OrderBy(b => b.Id).ToListAsync();
        return View(books);
    }

    // GET: /Admin/Create
    public IActionResult Create() => View();

    // POST: /Admin/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Book book)
    {
        if (!ModelState.IsValid) return View(book);

        _db.Books.Add(book);
        await _db.SaveChangesAsync();
        TempData["Message"] = "Книга добавлена";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Admin/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var book = await _db.Books.FindAsync(id);
        if (book == null) return NotFound();
        return View(book);
    }

    // POST: /Admin/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Book book)
    {
        if (id != book.Id) return BadRequest();
        if (!ModelState.IsValid) return View(book);

        try
        {
            _db.Update(book);
            await _db.SaveChangesAsync();
            TempData["Message"] = "Изменения сохранены";
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_db.Books.Any(b => b.Id == id)) return NotFound();
            throw;
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: /Admin/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book == null) return NotFound();
        return View(book);
    }

    // POST: /Admin/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var book = await _db.Books.FindAsync(id);
        if (book != null)
        {
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            TempData["Message"] = "Книга удалена";
        }
        return RedirectToAction(nameof(Index));
    }
}