using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository.Models
{
    public class Jornada : Entity
    {
        int _edicionId;
        int _numero;
        DateTime _fecha;

        public int Numero { get => _numero; set => _numero = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public int EdicionId { get => _edicionId; set => _edicionId = value; }
        public Edicion Edicion { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
