using General.CrossCutting.Lib;

using Ligamania.Generic.Lib.Enums;
using Ligamania.Repository.Models;

using System;
using System.Collections.Generic;

namespace Ligamania.API.Lib.Models
{
    public class Entrenador : Response
    {
        public string Id { get; private set; }
        public string Nombre { get; private set; }
        public EstadoEntrenador Estado { get; private set; }
        public TipoEntrenador Tipo { get; private set; }
        public int NumEquipos { get; private set; }
        public IEnumerable<Equipo> Equipos { get; set; }
        public Entrenador()
        {
        }

        public Entrenador(string errorMessage) : base(errorMessage)
        { }

        internal void SetNumEquipos(int v)
        {
            NumEquipos = v;
        }
    }
}