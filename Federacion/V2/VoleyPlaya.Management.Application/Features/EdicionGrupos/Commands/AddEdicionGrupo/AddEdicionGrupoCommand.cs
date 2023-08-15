using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Domain.Enums;

namespace VoleyPlaya.Management.Application.Features.EdicionGrupos.Commands.AddEdicionGrupo
{
    public class AddEdicionGrupoCommand : IRequest<EdicionGrupoDto>
    {
        public string Nombre { get; set; } = string.Empty;
        public FaseEdicionGrupo Fase { get; set; } = FaseEdicionGrupo.None;
        public int EdicionId { get; set; }
    }
}
