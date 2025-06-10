using Bogus;
using MangaBot.Models;
using System.Collections.Generic;

namespace MangaBot.Services;

public class FakerService
{
    private readonly HashSet<string> _titulosUnicos = new();
    private readonly Faker<Manga> _mangaFaker;

    public FakerService()
    {
        _mangaFaker = new Faker<Manga>()
            .RuleFor(m => m.Titulo, f => GenerarTituloUnico(f))
            .RuleFor(m => m.Descripcion, f => f.Lorem.Paragraph())
            .RuleFor(m => m.Autor, f => f.Name.FullName())
            .RuleFor(m => m.FechaCreacion, f => f.Date.Past())
            .RuleFor(m => m.Activo, f => f.Random.Bool(0.9f));
    }

    private string GenerarTituloUnico(Faker f)
    {
        string titulo;
        do
        {
            titulo = f.Lorem.Sentence(3, 5);
        } while (!_titulosUnicos.Add(titulo));

        return titulo;
    }

    public IEnumerable<Manga> GenerarMangas(int cantidad)
    {
        return _mangaFaker.Generate(cantidad);
    }
} 