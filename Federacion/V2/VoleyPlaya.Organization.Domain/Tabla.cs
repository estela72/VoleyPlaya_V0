using GenericLib;

using System;
using System.Collections.Generic;

namespace VoleyPlaya.Organization.Domain;

public partial class Tabla : BaseDomain, IAggregateRoot
{
    public string? Nombre { get; set; }

    public int NumEquipos { get; set; }

    public int NumPartido { get; set; }

    public string Ronda { get; set; } = null!;

    public string Equipo1 { get; set; } = null!;

    public string Equipo2 { get; set; } = null!;

    public int Jornada { get; set; }

    public int NumGrupos { get; set; }
}
