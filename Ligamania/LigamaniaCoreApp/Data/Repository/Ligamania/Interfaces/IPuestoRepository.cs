﻿using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface IPuestoRepository : IGenericAuditableNameRepository<PuestoDTO>
    {
        //Puesto GetById(int id);
        //Puesto GetByName(string strPuesto);
    }
}
