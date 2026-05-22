using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Application.Services;

public class ReviewService
{
    private readonly IReviewRepository _repo;

    public ReviewService(IReviewRepository repo)
    {
        _repo = repo;
    }

    public List<Review> ObtenerPorItem(int itemId)
    {
        return _repo.ObtenerPorItem(itemId);
    }

    public void Agregar(Review review)
    {
        if (review.Estrellas < 1 || review.Estrellas > 5)
            throw new ArgumentException("Las estrellas deben ser entre 1 y 5.");
        _repo.Agregar(review);
    }
}