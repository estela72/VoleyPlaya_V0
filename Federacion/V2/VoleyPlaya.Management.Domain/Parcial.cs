using System;
using System.Collections.Generic;

using VoleyPlaya.Management.Domain.Common;

namespace VoleyPlaya.Management.Domain;

public partial class Parcial
{
    public int Id { get; set; }

    public int PartidoId { get; set; }

    public int? ResultadoLocal { get; set; }

    public int? ResultadoVisitante { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Nombre { get; set; }

    public virtual Partido Partido { get; set; } = null!;

}
