﻿using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface INoticiaRepository : IRepository<NoticiaDTO>
    {
        Task<NoticiaDTO> GetLastNew();
    }
}