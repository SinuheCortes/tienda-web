using System;
using System.Collections.Generic;

namespace Store.Api.Entitys;

public partial class ArticuloTienda
{
    public Guid Id { get; set; }

    public Guid IdArticulo { get; set; }

    public int IdTienda { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Articulo IdArticuloNavigation { get; set; } = null!;

    public virtual Tienda IdTiendaNavigation { get; set; } = null!;
}
