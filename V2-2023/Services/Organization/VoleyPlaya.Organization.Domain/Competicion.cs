using Common.Domain;

using System;
using System.Collections.Generic;

namespace VoleyPlaya.Organization.Domain;

public partial class Competicion : BaseDomain, IAggregateRoot
{
    public string Nombre { get; set; } = string.Empty;
}
