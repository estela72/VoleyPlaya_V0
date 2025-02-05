﻿using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Organization.Application.Features.Temporadas.Commands.DeleteTemporada
{
    public class DeleteTemporadaCommand : IRequest<bool>
    {
        public DeleteTemporadaCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}