using GenericLib;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VoleyPlaya.Organization.Domain;

public partial class Categoria : BaseDomain, IAggregateRoot
{
    public string? Nombre { get; set; }
}
