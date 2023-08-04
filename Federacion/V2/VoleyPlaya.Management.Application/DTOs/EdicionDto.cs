using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Management.Application.DTOs
{
    public record EdicionDto(int Id, int TemporadaId, int CompeticionId, int CategoriaId, string Genero, string Prueba);
}
