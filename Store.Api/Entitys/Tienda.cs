using System;
using System.Collections.Generic;

namespace Store.Api.Entitys;

public partial class Tienda
{
    public int Id { get; set; }

    public string Sucursal { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<ArticuloTienda> ArticuloTienda { get; set; } = new List<ArticuloTienda>();
}
