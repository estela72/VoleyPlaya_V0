using GenericLib;

using System;
using System.Collections.Generic;

namespace VoleyPlaya.Management.Domain;

public partial class Parcial : BaseDomain
{
    public int PartidoId { get; set; }
    private Partido? _partido;
    public Partido Partido
    {
        get { return _partido ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Partido)); }
        set { _partido = value; }
    }
    public int? ResultadoLocal { get; set; }

    public int? ResultadoVisitante { get; set; }
}
