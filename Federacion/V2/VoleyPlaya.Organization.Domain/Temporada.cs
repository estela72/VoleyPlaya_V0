using System;
using System.Collections.Generic;

using VoleyPlaya.Organization.Domain.Common;

namespace VoleyPlaya.Organization.Domain;

public partial class Temporada : IAggregateRoot
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Nombre { get; set; }

    public bool? Actual { get; set; }

    //public virtual ICollection<Edicione> Ediciones { get; set; } = new List<Edicione>();
}
