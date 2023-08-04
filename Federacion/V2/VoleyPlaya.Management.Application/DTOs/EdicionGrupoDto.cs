using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Management.Application.DTOs
{
    public record EdicionGrupoDto(int Id, int EdicionId, string Nombre, string Tipo);
}
