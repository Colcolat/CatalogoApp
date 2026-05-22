using CatalogoApp.Domain.Models;

namespace CatalogoApp.Domain.Interfaces;

public interface IReviewRepository
{
    List<Review> ObtenerPorItem(int itemId);
    void Agregar(Review review);
}