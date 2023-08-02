using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Organization.Application.DTOs
{
    public record TablaDto(int Id, string Nombre, string Equipo1, string Equipo2, string Ronda);
}
