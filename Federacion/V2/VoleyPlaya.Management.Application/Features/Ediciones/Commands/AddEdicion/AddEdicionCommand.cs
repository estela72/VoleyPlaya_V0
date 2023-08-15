using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Domain.Enums;

namespace VoleyPlaya.Management.Application.Features.Ediciones.Commands.AddEdicion
{
    public class AddEdicionCommand : IRequest<EdicionDto>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Prueba { get; set; } = string.Empty;
        public Generos Genero { get; set; } = Generos.None;
        public EstadosEdicion Estado { get; set; } = EstadosEdicion.Registrada;
        public ModelosCompeticion? Modelo { get; set; }
        public int TemporadaId { get; set; }
        public int CompeticionId { get; set; }
        public int CategoriaId { get; set; }
    }
}
