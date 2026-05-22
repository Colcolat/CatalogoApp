namespace CatalogoApp.Domain.Models;

public class Review
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int Estrellas { get; set; }   // 1–5
    public string Autor { get; set; } = string.Empty;
    public string Comentario { get; set; } = string.Empty;
}