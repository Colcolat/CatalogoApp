using System.Text.Json;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Infrastructure.Repositories;

public class JsonReviewRepository : IReviewRepository
{
    private readonly string _filePath;

    public JsonReviewRepository(string filePath)
    {
        _filePath = filePath;
        var carpeta = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(carpeta))
            Directory.CreateDirectory(carpeta);
    }

    public List<Review> ObtenerPorItem(int itemId)
    {
        return Leer().Where(r => r.ItemId == itemId).ToList();
    }

    public void Agregar(Review review)
    {
        var lista = Leer();
        review.Id = lista.Count > 0 ? lista.Max(r => r.Id) + 1 : 1;
        lista.Add(review);
        Guardar(lista);
    }

    private List<Review> Leer()
    {
        if (!File.Exists(_filePath)) return new();
        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Review>>(json) ?? new();
    }

    private void Guardar(List<Review> lista)
    {
        var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}