using CatalogoApp.Domain.Models;

namespace CatalogoApp.Domain.Interfaces;

public interface IUserRepository
{
    User? ObtenerPorUsername(string username);
    void Agregar(User user);
}