using System;
using System.Collections.Generic;

namespace ProyectoSocioEconomico.Domain.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string? Dui { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? ImagenPerfil { get; set; }
    public required string FrontDUI { get; set; }
    public required string ReverseDUI { get; set; }
    public int IdRol { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Caso> Casos { get; set; } = new List<Caso>();

    public virtual ICollection<Donacione> Donaciones { get; set; } = new List<Donacione>();

    public virtual Role IdRolNavigation { get; set; } = null!;

    public virtual ICollection<InscripcionesVoluntario> InscripcionesVoluntarios { get; set; } = new List<InscripcionesVoluntario>();

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual ICollection<Programa> Programas { get; set; } = new List<Programa>();

    public virtual ICollection<Retiro> Retiros { get; set; } = new List<Retiro>();
}
