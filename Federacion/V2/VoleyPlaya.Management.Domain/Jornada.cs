using Common.Domain;

using System;
using System.Collections.Generic;


namespace VoleyPlaya.Management.Domain;

public partial class Jornada : BaseDomain, IAggregateRoot
{

    public int Numero { get; set; }

    public DateTime Fecha { get; set; }

    public int EdicionId { get; set; }
    private Edicion? _edicion;
    public Edicion Edicion
    {
        get { return _edicion ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Edicion)); }
        set { _edicion = value; }
    }

    public string Nombre { get; set; } = string.Empty;
}
