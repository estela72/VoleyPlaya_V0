using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.AdminViewModels
{
    public class TemporadaJornadaJugadorViewModel
    {
        public int? IdTemporadaJornadaJugador { get; set; }
        public int IdJugador { get; set; }
        public string Jugador { get; set; }
        public bool Activo { get; set; }
        public string Club { get; set; }
        public bool ClubActivo { get; set; }
        public string Puesto { get; set; }
        public int OrdenPuesto { get; set; }
        public bool? Eliminado { get; set; }
        public int? GolesFavor { get; set; }
        public int? GolesContra { get; set; }
        public bool Preeliminado { get; set; }

        public Dictionary<string, int> VecesPorCompeticionCategoria { get; set; }

        public int Golden
        {
            get
            {
                string comp = VecesPorCompeticionCategoria.Keys.FirstOrDefault(k => k.Contains("Golden"));
                if (!string.IsNullOrEmpty(comp)) return VecesPorCompeticionCategoria[comp];
                return 0;
            }
        }
        public int SilverA
        {
            get
            {
                string comp = VecesPorCompeticionCategoria.Keys.FirstOrDefault(k => k.Contains("Silver A"));
                if (!string.IsNullOrEmpty(comp)) return VecesPorCompeticionCategoria[comp];
                return 0;
            }
        }
        public int SilverB
        {
            get
            {
                string comp = VecesPorCompeticionCategoria.Keys.FirstOrDefault(k => k.Contains("Silver B"));
                if (!string.IsNullOrEmpty(comp)) return VecesPorCompeticionCategoria[comp];
                return 0;
            }
        }
        public int Copa
        {
            get
            {
                string comp = VecesPorCompeticionCategoria.Keys.FirstOrDefault(k => k.Contains("Copa"));
                if (!string.IsNullOrEmpty(comp)) return VecesPorCompeticionCategoria[comp];
                return 0;
            }
        }
        public int Supercopa
        {
            get
            {
                string comp = VecesPorCompeticionCategoria.Keys.FirstOrDefault(k => k.Contains("Supercopa"));
                if (!string.IsNullOrEmpty(comp)) return VecesPorCompeticionCategoria[comp];
                return 0;
            }
        }
        public int Promocion
        {
            get
            {
                string comp = VecesPorCompeticionCategoria.Keys.FirstOrDefault(k => k.Contains("Promocion"));
                if (!string.IsNullOrEmpty(comp)) return VecesPorCompeticionCategoria[comp];
                return 0;
            }
        }
    }
}
