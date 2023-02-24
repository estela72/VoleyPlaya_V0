using System;
using System.ComponentModel.DataAnnotations;

namespace General.CrossCutting.Lib
{
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public interface IBaseEntity
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        int Id { get; set; }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        DateTime CreatedDate { get; set; }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        DateTime UpdatedDate { get; set; }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        string CreatedBy { get; set; }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        string UpdatedBy { get; set; }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    }
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public interface IEntity : IBaseEntity
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        string Nombre { get; set; }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    }
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public abstract class BaseEntity : IBaseEntity
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
        private int? _requestedHashCode;
        private int _Id;
        private DateTime _CreatedDateTime;
        private DateTime _UpdatedDateTime;
        private string _CreatedBy;
        private string _UpdatedBy;

        [Key]
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public int Id { get { return _Id; } set { _Id = value; } }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public DateTime CreatedDate { get { return _CreatedDateTime; } set { _CreatedDateTime = value; } }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public DateTime UpdatedDate { get { return _UpdatedDateTime; } set { _UpdatedDateTime = value; } }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public bool IsTransient()
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            return this.Id == default(Int32);
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public override bool Equals(object obj)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public override int GetHashCode()
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public static bool operator ==(BaseEntity left, BaseEntity right)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public static bool operator !=(BaseEntity left, BaseEntity right)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            return !(left == right);
        }

    }
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public abstract class Entity : BaseEntity, IEntity
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
        private string _Nombre;

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public string Nombre { get { return _Nombre; } set { _Nombre = value; } }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    }
}