using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.Partidos.Commands.UpdatePartido
{
    public class UpdatePartidoCommand : IRequest<PartidoDto>
    {
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public int NumPartido { get; set; }
        public string Ronda { get; set; } = string.Empty;
        public DateTime? FechaHora { get; set; }
        public string? Pista { get; set; }
        public int? ResultadoLocal { get; set; }
        public int? ResultadoVisitante { get; set; }
        public string? NombreLocal { get; set; }
        public string? NombreVisitante { get; set; }
        public bool? ConResultado { get; set; }
        public string UserResultado { get; set; }
        public bool? Validado { get; set; }
        public string UserValidador { get; set; }
        public int? EdicionGrupoId { get; set; }
        public int? JornadaId { get; set; }
        public int? EquipoLocalId { get; set; }
        public int? EquipoVisitanteId { get; set; }
    }
}
