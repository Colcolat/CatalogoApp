using System.Security.Cryptography;
using System.Text;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Application.Services;

public class UserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public bool Registrar(string username, string password)
    {
        // No permitir usernames duplicados
        if (_repo.ObtenerPorUsername(username) != null)
            return false;

        var user = new User
        {
            Username = username,
            PasswordHash = Hashear(password)
        };
        _repo.Agregar(user);
        return true;
    }

    public bool ValidarCredenciales(string username, string password)
    {
        var user = _repo.ObtenerPorUsername(username);
        if (user == null) return false;
        return user.PasswordHash == Hashear(password);
    }
    
    private static string Hashear(string texto)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(texto));
        return Convert.ToHexString(bytes);
    }
}