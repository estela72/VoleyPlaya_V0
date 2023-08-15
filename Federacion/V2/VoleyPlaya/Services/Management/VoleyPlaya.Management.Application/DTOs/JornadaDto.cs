using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Management.Application.DTOs
{
    public record JornadaDto(int Id, string Nombre, int Numero, DateTime Fecha, int EdicionId);
}
