using System;
using System.Collections.Generic;

namespace ProyectoSocioEconomico.Domain.Entities;

public partial class LogsFinanciero
{
    public int Id { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public decimal Monto { get; set; }

    public DateTime Fecha { get; set; }

    public string? Descripcion { get; set; }

    public int ReferenciaId { get; set; }
}
