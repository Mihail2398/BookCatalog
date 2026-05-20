using BookCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "Война и мир",
                Author = "Лев Толстой",
                Genre = "Роман",
                Year = 1869,
                Price = 850,
                Description = "Эпический роман-эпопея о русском обществе в эпоху войн против Наполеона.",
                CoverUrl = "https://images.unsplash.com/photo-1544947950-fa07a98d237f?w=400"
            },
            new Book
            {
                Id = 2,
                Title = "Преступление и наказание",
                Author = "Фёдор Достоевский",
                Genre = "Психологический роман",
                Year = 1866,
                Price = 720,
                Description = "Роман о бедном студенте Раскольникове и его моральных терзаниях.",
                CoverUrl = "https://images.unsplash.com/photo-1543002588-bfa74002ed7e?w=400"
            },
            new Book
            {
                Id = 3,
                Title = "Мастер и Маргарита",
                Author = "Михаил Булгаков",
                Genre = "Фантастика",
                Year = 1967,
                Price = 650,
                Description = "Мистический роман о визите дьявола в советскую Москву.",
                CoverUrl = "https://images.unsplash.com/photo-1535905557558-afc4877a26fc?w=400"
            }
        );
    }
}