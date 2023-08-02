using GenericLib;

using System;
using System.Collections.Generic;


namespace VoleyPlaya.Organization.Domain;

public partial class Equipo : BaseDomain, IAggregateRoot
{
    public string? Nombre { get; set; }
    public int? EdicionId { get; set; }

    public int? OrdenCalendario { get; set; }

    public int? Jugados { get; set; }

    public int? Ganados { get; set; }

    public int? Perdidos { get; set; }

    public int? PuntosFavor { get; set; }

    public int? PuntosContra { get; set; }

    public double? Coeficiente { get; set; }

    public int? Puntos { get; set; }

    public bool? Retirado { get; set; }

    public int? OrdenEntrada { get; set; }

    public int ClasificacionFinal { get; set; }
}
