﻿using System;
using System.Collections.Generic;

namespace Store.Api.Entitys;

public partial class Cliente
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<ClienteArticulo> ClienteArticulos { get; set; } = new List<ClienteArticulo>();
}
