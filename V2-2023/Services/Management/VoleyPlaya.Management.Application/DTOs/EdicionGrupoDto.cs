using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Domain.Enums;

namespace VoleyPlaya.Management.Application.DTOs
{
    public record EdicionGrupoDto(int Id, string Nombre, FaseEdicionGrupo Fase, int EdicionId);
}
