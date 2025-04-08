﻿using System;
using System.Collections.Generic;

namespace Lab04_WillianKana.Entities;

public partial class Pago
{
    public int Pagoid { get; set; }

    public int? Ordenid { get; set; }

    public decimal Monto { get; set; }

    public DateTime? Fechapago { get; set; }

    public string? Metodopago { get; set; }

    public virtual Ordene? Orden { get; set; }
}
