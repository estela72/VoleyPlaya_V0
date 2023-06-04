using System;
using System.ComponentModel.DataAnnotations;

namespace General.CrossCutting.Lib
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
    public interface IEntity : IBaseEntity
    {
        string Nombre { get; set; }
    }
    public abstract class BaseEntity : IBaseEntity
    {
        private int? _requestedHashCode;
        private int _Id;
        private DateTime _CreatedDateTime;
        private DateTime _UpdatedDateTime;
        private string _CreatedBy;
        private string _UpdatedBy;

        [Key]
        public int Id { get { return _Id; } set { _Id = value; } }

        public DateTime CreatedDate { get { return _CreatedDateTime; } set { _CreatedDateTime = value; } }
        public DateTime UpdatedDate { get { return _UpdatedDateTime; } set { _UpdatedDateTime = value; } }
        public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
        public bool IsTransient()
        {
            return this.Id == default(Int32);
        }

        public override bool Equals(object obj)
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

        public override int GetHashCode()
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

        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(BaseEntity left, BaseEntity right)
        {
            return !(left == right);
        }

    }
    public abstract class Entity : BaseEntity, IEntity
    {
        private string _Nombre;

        public string Nombre { get { return _Nombre; } set { _Nombre = value; } }
    }
}