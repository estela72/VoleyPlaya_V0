﻿using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Organization.Application.Features.Equipos.Commands.DeleteEquipo
{
    public class DeleteEquipoCommand : IRequest<bool>
    {
        public DeleteEquipoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
