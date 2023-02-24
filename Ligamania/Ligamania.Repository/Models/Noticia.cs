using General.CrossCutting.Lib;

using System;

namespace Ligamania.Repository.Models
{
    public partial class NoticiaDTO : Entity
    {
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public int Nivel { get; set; }
        public bool Activa { get; set; }
    }
}