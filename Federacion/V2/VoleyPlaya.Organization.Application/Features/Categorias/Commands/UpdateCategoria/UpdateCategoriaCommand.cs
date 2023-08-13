﻿using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Categorias.Commands.UpdateCategoria;

public class UpdateCategoriaCommand : IRequest<CategoriaDto>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}
