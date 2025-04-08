using System;
using System.Collections.Generic;

namespace Lab04_WillianKana.Entities;

public partial class Categoria
{
    public int Categoriaid { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
