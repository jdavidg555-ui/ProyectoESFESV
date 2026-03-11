using System;
using System.Collections.Generic;

namespace ProyectoSocioEconomico.Domain.Entities;

public partial class Comprobante
{
    public int Id { get; set; }

    public int IdDonacion { get; set; }

    public string UrlArchivo { get; set; } = null!;

    public DateTime FechaSubida { get; set; }

    public string CodigoComprobante { get; set; } = null!;

    public int DonacionId { get; set; }

    public virtual Donacione Donacion { get; set; } = null!;
}
