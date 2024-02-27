namespace Store.Api.Dtos;

public class ArticuloDto
{
    public Guid Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? Imagen { get; set; }

    public int? Stock { get; set; }
    public int IdTienda { get; set; }
}
