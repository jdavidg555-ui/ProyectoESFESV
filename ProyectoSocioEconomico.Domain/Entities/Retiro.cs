using System;
using System.Collections.Generic;

namespace ProyectoSocioEconomico.Domain.Entities;

public partial class Retiro
{
    public int Id { get; set; }

    public int IdBeneficiado { get; set; }

    public int IdCaso { get; set; }

    public decimal Monto { get; set; }

    public string MetodoPago { get; set; } = null!;

    public string? DatosPago { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaSolicitud { get; set; }

    public DateTime? FechaProcesado { get; set; }

    public virtual Usuario IdBeneficiadoNavigation { get; set; } = null!;

    public virtual Caso IdCasoNavigation { get; set; } = null!;
}
