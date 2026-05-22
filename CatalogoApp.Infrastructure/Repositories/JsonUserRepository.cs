using System.Text.Json;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Infrastructure.Repositories;

public class JsonUserRepository : IUserRepository
{
    private readonly string _filePath;

    public JsonUserRepository(string filePath)
    {
        _filePath = filePath;
        var carpeta = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(carpeta))
            Directory.CreateDirectory(carpeta);
    }

    public User? ObtenerPorUsername(string username)
    {
        return Leer().FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
    }

    public void Agregar(User user)
    {
        var lista = Leer();
        user.Id = lista.Count > 0 ? lista.Max(u => u.Id) + 1 : 1;
        lista.Add(user);
        Guardar(lista);
    }

    private List<User> Leer()
    {
        if (!File.Exists(_filePath)) return new();
        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<User>>(json) ?? new();
    }

    private void Guardar(List<User> lista)
    {
        var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}