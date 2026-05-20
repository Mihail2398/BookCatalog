using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Models;

public class Book
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Название обязательно")]
    [StringLength(200, ErrorMessage = "Максимум 200 символов")]
    [Display(Name = "Название")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Автор обязателен")]
    [StringLength(100)]
    [Display(Name = "Автор")]
    public string Author { get; set; } = string.Empty;

    [Required(ErrorMessage = "Жанр обязателен")]
    [StringLength(50)]
    [Display(Name = "Жанр")]
    public string Genre { get; set; } = string.Empty;

    [Range(1, 3000, ErrorMessage = "Год должен быть от 1 до 3000")]
    [Display(Name = "Год издания")]
    public int Year { get; set; }

    [Range(0, 100000, ErrorMessage = "Цена должна быть положительной")]
    [Display(Name = "Цена")]
    public decimal Price { get; set; }

    [StringLength(2000)]
    [Display(Name = "Описание")]
    public string? Description { get; set; }

    [Url(ErrorMessage = "Введите корректный URL")]
    [Display(Name = "URL обложки")]
    public string? CoverUrl { get; set; }
}