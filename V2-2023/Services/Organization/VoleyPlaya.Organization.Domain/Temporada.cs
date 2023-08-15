using Common.Domain;

using System;
using System.Collections.Generic;


namespace VoleyPlaya.Organization.Domain;

public partial class Temporada : BaseDomain, IAggregateRoot
{
    public string Nombre { get; set; } = string.Empty;

    public bool? Actual { get; set; }
}
