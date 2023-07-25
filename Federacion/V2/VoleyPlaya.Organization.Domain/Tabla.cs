using System;
using System.Collections.Generic;

using VoleyPlaya.Organization.Domain.Common;

namespace VoleyPlaya.Organization.Domain;

public partial class Tabla : IAggregateRoot
{
    public int Id { get; set; }

    public int NumEquipos { get; set; }

    public int NumPartido { get; set; }

    public string Ronda { get; set; } = null!;

    public string Equipo1 { get; set; } = null!;

    public string Equipo2 { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Nombre { get; set; }

    public int Jornada { get; set; }

    public int NumGrupos { get; set; }
}
