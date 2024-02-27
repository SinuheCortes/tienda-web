using System;
using System.Collections.Generic;

namespace Store.Api.Entitys;

public partial class ClienteArticulo
{
    public Guid Id { get; set; }

    public Guid IdCliente { get; set; }

    public Guid IdArticulo { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Articulo IdArticuloNavigation { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
