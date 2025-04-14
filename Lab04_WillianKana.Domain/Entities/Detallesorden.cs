﻿namespace Lab04_WillianKana.Domain.Entities;

public partial class Detallesorden
{
    public int Detalleid { get; set; }

    public int? Ordenid { get; set; }

    public int? Productoid { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public virtual Ordene? Orden { get; set; }

    public virtual Producto? Producto { get; set; }
}
