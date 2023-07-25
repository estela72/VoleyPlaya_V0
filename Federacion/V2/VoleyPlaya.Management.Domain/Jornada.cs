using System;
using System.Collections.Generic;

using VoleyPlaya.Management.Domain.Common;

namespace VoleyPlaya.Management.Domain;

public partial class Jornada : IAggregateRoot
{
    public int Id { get; set; }

    public int Numero { get; set; }

    public DateTime Fecha { get; set; }

    public int EdicionId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Nombre { get; set; }

    public virtual Edicion Edicion { get; set; } = null!;
}
