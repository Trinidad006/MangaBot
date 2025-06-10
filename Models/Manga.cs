using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaBot.Models;

public class Manga
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Titulo { get; set; } = string.Empty;
    
    [StringLength(500)]
    public string? Descripcion { get; set; }
    
    [StringLength(100)]
    public string? Autor { get; set; }
    
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    
    public bool Activo { get; set; } = true;
    
    public DateTime FechaPublicacion { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Genero { get; set; } = string.Empty;
    
    public int Capitulos { get; set; }
} 