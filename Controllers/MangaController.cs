using Microsoft.AspNetCore.Mvc;
using MangaBot.Models;
using MangaBot.Services;
using Microsoft.EntityFrameworkCore;
using MangaBot.Data;

namespace MangaBot.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MangaController : ControllerBase
{
    private readonly FakerService _fakerService;
    private readonly ApplicationDbContext _context;

    public MangaController(FakerService fakerService, ApplicationDbContext context)
    {
        _fakerService = fakerService;
        _context = context;
    }

    [HttpPost("generar")]
    public async Task<IActionResult> GenerarMangas(int cantidad = 3500)
    {
        try
        {
            var mangas = _fakerService.GenerarMangas(cantidad);
            
            foreach (var manga in mangas)
            {
                if (!await _context.Mangas.AnyAsync(m => m.Titulo == manga.Titulo))
                {
                    await _context.Mangas.AddAsync(manga);
                }
            }

            await _context.SaveChangesAsync();
            return Ok($"Se generaron {cantidad} mangas exitosamente");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al generar mangas: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerMangas()
    {
        var mangas = await _context.Mangas.ToListAsync();
        return Ok(mangas);
    }
} 