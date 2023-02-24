using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class TemporadaEquipoAccion
    {
        public int Id { get; set; }
        public bool Accion { get; set; }
        public string NuevaCategoria { get; set; }
        public string Equipo { get; set; }
        public string NuevoEquipo { get; set; }
        public string Categoria { get; set; }
    }
}
