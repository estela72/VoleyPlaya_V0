using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Management.Application.DTOs
{
    public record PartidoDto(int Id, string Label, int NumPartido, string Ronda, DateTime? FechaHora, string? Pista, 
        int? ResultadoLocal, int? ResultadoVisitante, string? NombreLocal, string? NombreVisitante,
        bool? ConResultado, string UserResultado, bool? Validado, string UserValidador,        
        int? EdicionGrupoId, int? JornadaId, int? EquipoLocalId, int? EquipoVisitanteId);
}
