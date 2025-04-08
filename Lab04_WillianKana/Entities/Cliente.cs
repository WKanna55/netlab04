﻿using System;
using System.Collections.Generic;

namespace Lab04_WillianKana.Entities;

public partial class Cliente
{
    public int Clienteid { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public DateTime? Fechacreacion { get; set; }

    public virtual ICollection<Ordene> Ordenes { get; set; } = new List<Ordene>();
}
