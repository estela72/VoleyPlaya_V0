using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Domain.Enums;

namespace VoleyPlaya.Management.Application.DTOs;

public record EdicionDto(int Id, string Nombre, string Prueba, Generos Genero, EstadosEdicion Estado, ModelosCompeticion? ModeloCompeticion,
    int TemporadaId, int CompeticionId, int CategoriaId);
