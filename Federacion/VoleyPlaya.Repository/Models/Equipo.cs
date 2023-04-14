﻿using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository.Models
{
    public class Equipo:Entity
    {
        Edicion? _edicion;
        EdicionGrupo? _edicionGrupo;
        int? _ordenCalendario;
        int? _jugados;
        int? _ganados;
        int? _perdidos;
        int? _puntosFavor;
        int? _puntosContra;
        double? _coeficiente;
        int? _puntos;

        HashSet<Partido>? _locales;
        HashSet<Partido>? _visitantes;

        int? _edicionId;
        int? _edicionGrupoId;

        public Equipo()
        {
            _locales = new HashSet<Partido>();
            _visitantes = new HashSet<Partido>();
        }

        public Equipo(EdicionGrupo edicionGrupo)
        {
            _edicion = edicionGrupo.Edicion;
            _edicionGrupo = edicionGrupo;
            _locales = new HashSet<Partido>();
            _visitantes = new HashSet<Partido>();
        }
        public int? EdicionId { get => _edicionId; set => _edicionId = value; }
        public int? EdicionGrupoId { get => _edicionGrupoId; set => _edicionGrupoId = value; }
        public Edicion? Edicion { get => _edicion; set => _edicion = value; }
        public EdicionGrupo? EdicionGrupo { get => _edicionGrupo; set => _edicionGrupo = value; }
        public int? OrdenCalendario { get => _ordenCalendario; set => _ordenCalendario = value; }
        public int? Jugados { get => _jugados; set => _jugados = value; }
        public int? Ganados { get => _ganados; set => _ganados = value; }
        public int? Perdidos { get => _perdidos; set => _perdidos = value; }
        public int? PuntosFavor { get => _puntosFavor; set => _puntosFavor = value; }
        public int? PuntosContra { get => _puntosContra; set => _puntosContra = value; }
        public double? Coeficiente { get => _coeficiente; set => _coeficiente = value; }
        public int? Puntos { get => _puntos; set => _puntos = value; }
        public HashSet<Partido>? Locales { get => _locales; set => _locales = value; }
        public HashSet<Partido>? Visitantes { get => _visitantes; set => _visitantes = value; }
    }
}
