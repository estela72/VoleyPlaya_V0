using System;

namespace LigamaniaCoreApp.Data.DataModels.Base.Interfaces
{
    public interface IBaseEntity
    {
    }

    public interface IEntity : IBaseEntity
    {
        int Id { get; set; }
    }
    public interface IAuditableEntity : IEntity
    {
        DateTime CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime UpdatedDate { get; set; }

        string UpdatedBy { get; set; }
    }

    public interface IEntityName : IEntity
    {
        string Nombre { get; set; }
    }
    public interface IAuditableNameEntity : IEntityName, IAuditableEntity
    {

    }
}
