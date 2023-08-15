using General.CrossCutting.Lib;

using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

using VoleyPlaya.Repository.Enums;
using VoleyPlaya.Repository.Services;

namespace VoleyPlaya.Repository.Models
{
    public class Edicion : Entity
    {
        public int TemporadaId { get; private set; }
        public Temporada Temporada { get;set; }
        public int CompeticionId { get; private set; }
        public Competicion Competicion { get; set; }
        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; set; }
        public string Genero { get; init; }
        public string Prueba { get; init; }
        public string? TipoCalendario { get; set; }
        public HashSet<Jornada> Jornadas{ get; private set; }
        public HashSet<EdicionGrupo> Grupos {    get; private set; }
        public HashSet<Equipo> Equipos { get; private set; }
        public string? ModeloCompeticion {   get; set; }
        public EnumEstadoEdicion Estado { get; set; }
        public Edicion()
        {
            Jornadas = new HashSet<Jornada>();
            Grupos = new HashSet<EdicionGrupo>();
            Equipos = new HashSet<Equipo>();
        }
    }
}
