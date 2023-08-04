using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Management.Application.DTOs
{
    public record PartidoDto(int Id, int EdicionGrupoId, int EquipoLocalId, int EquipoVisitanteId, int ResultadoLocal, int ResultadoVisitante, int Jornada, int NumeroPartido,
        DateTime FechaHora, string Pista);
}
