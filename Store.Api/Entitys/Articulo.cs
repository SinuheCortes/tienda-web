using System;
using System.Collections.Generic;

namespace Store.Api.Entitys;

public partial class Articulo
{
    public Guid Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? Imagen { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<ArticuloTienda> ArticuloTienda { get; set; } = new List<ArticuloTienda>();

    public virtual ICollection<ClienteArticulo> ClienteArticulos { get; set; } = new List<ClienteArticulo>();
}
