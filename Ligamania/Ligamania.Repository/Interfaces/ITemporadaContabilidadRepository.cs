﻿using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaContabilidadRepository : IRepository<TemporadaContabilidadDTO>
    {
        Task<ICollection<TemporadaContabilidadDTO>> GetContabilidadByTemporada(int id);
    }
}