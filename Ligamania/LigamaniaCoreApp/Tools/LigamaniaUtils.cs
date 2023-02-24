using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Helpers;
using LigamaniaCoreApp.Models.AdminViewModels;
using LigamaniaCoreApp.Models.GlobalViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Utils
{
    public static class LigamaniaUtils
    {
        public static DateTime GetLocalTime(DateTime serverTime)
        {
            //var timeZoneInfos = TimeZoneInfo.GetSystemTimeZones();
            //DateTime serverTime = DateTime.Now;
            DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "Romance Standard Time");
            return _localTime;
        }

        public static Tuple<ResultadoPartidoViewModel, TemporadaClasificacionDTO, TemporadaClasificacionDTO> ResultadoPartido(TemporadaClasificacionDTO clasiActualEquipoA, TemporadaClasificacionDTO clasiActualEquipoB,
            ICollection<AlineacionDTO> aliEquipoA, ICollection<AlineacionDTO> aliEquipoB, ICollection<TemporadaJornadaJugadorDTO> goleadores)
        {
            ResultadoPartidoViewModel resultado = new ResultadoPartidoViewModel();
            TemporadaClasificacionDTO newClasiEquipoA = new TemporadaClasificacionDTO();
            TemporadaClasificacionDTO newClasiEquipoB = new TemporadaClasificacionDTO();

            newClasiEquipoA.Ganados = clasiActualEquipoA.Ganados;
            newClasiEquipoA.Perdidos = clasiActualEquipoA.Perdidos;
            newClasiEquipoA.Empatados = clasiActualEquipoA.Empatados;

            newClasiEquipoB.Ganados = clasiActualEquipoB.Ganados;
            newClasiEquipoB.Perdidos = clasiActualEquipoB.Perdidos;
            newClasiEquipoB.Empatados = clasiActualEquipoB.Empatados;

            int golesExtra1 = 0;
            int golesExtra2 = 0;

            #region Equipo local y equipo visitante tienen alineación
            if (aliEquipoA != null && aliEquipoB != null && aliEquipoA.Count > 0 && aliEquipoB.Count > 0)
            {
                // Calculamos la suma de los goles a favor del equipo 1 + suma de los goles en contra del equipo 2
                resultado.GF1_GC2 = CalculaGoles(aliEquipoA, aliEquipoB, goleadores, out golesExtra2);

                resultado.GF2_GC1 = CalculaGoles(aliEquipoB, aliEquipoA, goleadores, out golesExtra1);

                // calculamos los nuevos puntos a favor y en contra de cada equipo 
                resultado.newGF1 = clasiActualEquipoA.GolesFavor + resultado.GF1_GC2;
                resultado.newGF2 = clasiActualEquipoB.GolesFavor + resultado.GF2_GC1;
                resultado.newGC1 = clasiActualEquipoA.GolesContra + resultado.GF2_GC1;
                resultado.newGC2 = clasiActualEquipoB.GolesContra + resultado.GF1_GC2;

                resultado.newGEF1 = clasiActualEquipoA.GolesExtraFavor + golesExtra2;
                resultado.newGEF2 = clasiActualEquipoB.GolesExtraFavor + golesExtra1;
                resultado.newGEC1 = clasiActualEquipoA.GolesExtraContra + golesExtra1;
                resultado.newGEC2 = clasiActualEquipoB.GolesExtraContra + golesExtra2;

                newClasiEquipoA.GolesFavor = resultado.newGF1;
                newClasiEquipoB.GolesFavor = resultado.newGF2;
                newClasiEquipoA.GolesContra = resultado.newGC1;
                newClasiEquipoB.GolesContra = resultado.newGC2;
                resultado.p1 = resultado.GF1_GC2;
                resultado.p2 = resultado.GF2_GC1;

                newClasiEquipoA.GolesExtraContra = resultado.newGEC1;
                newClasiEquipoB.GolesExtraContra = resultado.newGEC2;
                newClasiEquipoA.GolesExtraFavor = resultado.newGEF1;
                newClasiEquipoB.GolesExtraFavor = resultado.newGEF2;

                // en función del resultado, sabemos cuales son los nuevos valores para partidos ganados, empatados y perdidos
                if (resultado.GF1_GC2 > resultado.GF2_GC1)
                {
                    newClasiEquipoA.Ganados = clasiActualEquipoA.Ganados + 1;
                    newClasiEquipoB.Perdidos = clasiActualEquipoB.Perdidos + 1;
                }
                else if (resultado.GF1_GC2 == resultado.GF2_GC1)
                {
                    newClasiEquipoA.Empatados = clasiActualEquipoA.Empatados + 1;
                    newClasiEquipoB.Empatados = clasiActualEquipoB.Empatados + 1;
                }
                else if (resultado.GF1_GC2 < resultado.GF2_GC1)
                {
                    newClasiEquipoA.Perdidos = clasiActualEquipoA.Perdidos + 1;
                    newClasiEquipoB.Ganados = clasiActualEquipoB.Ganados + 1;
                }

                // calculamos los puntos de cada equipo
                resultado.puntos1 = (3 * newClasiEquipoA.Ganados) + newClasiEquipoA.Empatados;
                resultado.puntos2 = (3 * newClasiEquipoB.Ganados) + newClasiEquipoB.Empatados;

                resultado.dif1 = resultado.newGF1 - resultado.newGC1;
                resultado.dif2 = resultado.newGF2 - resultado.newGC2;

                // actualizamos partidos jugados
                newClasiEquipoA.Jugados = clasiActualEquipoA.Jugados + 1;
                newClasiEquipoB.Jugados = clasiActualEquipoB.Jugados + 1;
            }
            #endregion
            #region Equipo local tiene alineación y equipo visitante no la tiene
            else if (aliEquipoA != null && aliEquipoA.Count > 0 && (aliEquipoB == null || aliEquipoB.Count == 0))
            {
                // Partidos jugados, ganados, empatados y perdidos
                newClasiEquipoA.Jugados = clasiActualEquipoA.Jugados + 1;
                newClasiEquipoB.Jugados = clasiActualEquipoB.Jugados + 1;
                newClasiEquipoA.Ganados = clasiActualEquipoA.Ganados + 1;
                newClasiEquipoB.Perdidos = clasiActualEquipoB.Perdidos + 1;

                resultado.GF1_GC2 = CalculaGoles(aliEquipoA, null, goleadores, out golesExtra2);
                resultado.GF2_GC1 = CalculaGoles(null, aliEquipoA, goleadores, out golesExtra1);

                // calculamos los nuevos puntos a favor y en contra de cada equipo 
                resultado.newGF1 = clasiActualEquipoA.GolesFavor + Math.Max(1, resultado.GF1_GC2);
                resultado.newGC1 = clasiActualEquipoA.GolesContra;
                resultado.newGC2 = clasiActualEquipoB.GolesContra + Math.Max(1, resultado.GF1_GC2);

                // calculamos los puntos de cada equipo
                resultado.puntos1 = (3 * newClasiEquipoA.Ganados) + newClasiEquipoA.Empatados;
                resultado.puntos2 = (3 * newClasiEquipoB.Ganados) + newClasiEquipoB.Empatados;

                // calculamos la diferencia de puntos
                resultado.dif1 = resultado.newGF1 - resultado.newGC1;
                resultado.dif2 = resultado.newGF2 - resultado.newGC2;

                resultado.p1 = Math.Max(1, resultado.GF1_GC2);
                resultado.p2 = 0;

                newClasiEquipoA.GolesFavor = resultado.newGF1;
                newClasiEquipoB.GolesFavor = resultado.newGF2;
                newClasiEquipoA.GolesContra = resultado.newGC1;
                newClasiEquipoB.GolesContra = resultado.newGC2;

                resultado.newGEF1 = clasiActualEquipoA.GolesExtraFavor + 0;
                resultado.newGEF2 = clasiActualEquipoB.GolesExtraFavor + 0;
                resultado.newGEC1 = clasiActualEquipoA.GolesExtraContra + 0;
                resultado.newGEC2 = clasiActualEquipoB.GolesExtraContra + 0;

                newClasiEquipoA.GolesExtraContra = resultado.newGEC1;
                newClasiEquipoB.GolesExtraContra = resultado.newGEC2;
                newClasiEquipoA.GolesExtraFavor = resultado.newGEF1;
                newClasiEquipoB.GolesExtraFavor = resultado.newGEF2;


            }
            #endregion
            #region Equipo local no tiene alineación y equipo visitante sí la tiene
            else if ((aliEquipoA == null || aliEquipoA.Count == 0) && aliEquipoB != null && aliEquipoB.Count > 0)
            {
                // Partidos jugados, ganados, empatados y perdidos
                newClasiEquipoA.Jugados = clasiActualEquipoA.Jugados + 1;
                newClasiEquipoB.Jugados = clasiActualEquipoB.Jugados + 1;
                newClasiEquipoB.Ganados = clasiActualEquipoB.Ganados + 1;
                newClasiEquipoA.Perdidos = clasiActualEquipoA.Perdidos + 1;

                resultado.GF1_GC2 = CalculaGoles(null, aliEquipoB, goleadores, out golesExtra2);
                resultado.GF2_GC1 = CalculaGoles(aliEquipoB, null, goleadores, out golesExtra1);

                // calculamos los nuevos puntos a favor y en contra de cada equipo 
                resultado.newGF2 = clasiActualEquipoB.GolesFavor + Math.Max(1, resultado.GF2_GC1);
                resultado.newGC2 = clasiActualEquipoB.GolesContra;
                resultado.newGC1 = clasiActualEquipoA.GolesContra + Math.Max(1, resultado.GF2_GC1);

                // calculamos los puntos de cada equipo
                resultado.puntos1 = (3 * newClasiEquipoA.Ganados) + newClasiEquipoA.Empatados;
                resultado.puntos2 = (3 * newClasiEquipoB.Ganados) + newClasiEquipoB.Empatados;

                // calculamos la diferencia de puntos
                resultado.dif1 = resultado.newGF1 - resultado.newGC1;
                resultado.dif2 = resultado.newGF2 - resultado.newGC2;

                resultado.p1 = 0;
                resultado.p2 = Math.Max(1, resultado.GF2_GC1);

                newClasiEquipoA.GolesFavor = resultado.newGF1;
                newClasiEquipoB.GolesFavor = resultado.newGF2;
                newClasiEquipoA.GolesContra = resultado.newGC1;
                newClasiEquipoB.GolesContra = resultado.newGC2;

                resultado.newGEF1 = clasiActualEquipoA.GolesExtraFavor + 0;
                resultado.newGEF2 = clasiActualEquipoB.GolesExtraFavor + 0;
                resultado.newGEC1 = clasiActualEquipoA.GolesExtraContra + 0;
                resultado.newGEC2 = clasiActualEquipoB.GolesExtraContra + 0;

                newClasiEquipoA.GolesExtraContra = resultado.newGEC1;
                newClasiEquipoB.GolesExtraContra = resultado.newGEC2;
                newClasiEquipoA.GolesExtraFavor = resultado.newGEF1;
                newClasiEquipoB.GolesExtraFavor = resultado.newGEF2;

            }
            #endregion
            #region Equipo local y equipo visitante no tienen alineación
            else if ((aliEquipoA == null && aliEquipoB == null) || (aliEquipoA.Count == 0 && aliEquipoB.Count == 0))
            {
                // Partidos jugados, ganados, empatados y perdidos
                newClasiEquipoA.Jugados = clasiActualEquipoA.Jugados + 1;
                newClasiEquipoB.Jugados = clasiActualEquipoB.Jugados + 1;
                newClasiEquipoB.Perdidos = clasiActualEquipoB.Perdidos + 1;
                newClasiEquipoA.Perdidos = clasiActualEquipoA.Perdidos + 1;

                resultado.GF1_GC2 = 0;
                resultado.GF2_GC1 = 0;

                // calculamos los nuevos puntos a favor y en contra de cada equipo 
                resultado.newGF2 = clasiActualEquipoB.GolesFavor;
                resultado.newGF1 = clasiActualEquipoA.GolesFavor;
                resultado.newGC2 = clasiActualEquipoB.GolesContra + 1;
                resultado.newGC1 = clasiActualEquipoA.GolesContra + 1;

                // calculamos los puntos de cada equipo
                resultado.puntos1 = (3 * newClasiEquipoA.Ganados) + newClasiEquipoA.Empatados;
                resultado.puntos2 = (3 * newClasiEquipoB.Ganados) + newClasiEquipoB.Empatados;

                // calculamos la diferencia de puntos
                resultado.dif1 = resultado.newGF1 - resultado.newGC1;
                resultado.dif2 = resultado.newGF2 - resultado.newGC2;
                resultado.p1 = 0;
                resultado.p2 = 0;

                newClasiEquipoA.GolesFavor = resultado.newGF1;
                newClasiEquipoB.GolesFavor = resultado.newGF2;
                newClasiEquipoA.GolesContra = resultado.newGC1;
                newClasiEquipoB.GolesContra = resultado.newGC2;

                resultado.newGEF1 = clasiActualEquipoA.GolesExtraFavor + 0;
                resultado.newGEF2 = clasiActualEquipoB.GolesExtraFavor + 0;
                resultado.newGEC1 = clasiActualEquipoA.GolesExtraContra + 0;
                resultado.newGEC2 = clasiActualEquipoB.GolesExtraContra + 0;

                newClasiEquipoA.GolesExtraContra = resultado.newGEC1;
                newClasiEquipoB.GolesExtraContra = resultado.newGEC2;
                newClasiEquipoA.GolesExtraFavor = resultado.newGEF1;
                newClasiEquipoB.GolesExtraFavor = resultado.newGEF2;

            }
            #endregion

            return new Tuple<ResultadoPartidoViewModel, TemporadaClasificacionDTO, TemporadaClasificacionDTO>(resultado, newClasiEquipoA, newClasiEquipoB);
        }

        private static int CalculaGoles(ICollection<AlineacionDTO> aliEquipoA, ICollection<AlineacionDTO> aliEquipoB, ICollection<TemporadaJornadaJugadorDTO> goleadores, out int sumaGC)
        {
            int goles = 0;

             int sumaGF = 0;
             sumaGC = 0;

            // sumar los goles a favor de los jugadores de la alineacion local
            if (aliEquipoA != null)
            {
                foreach (var aliJug in aliEquipoA)
                {
                    int gf = goleadores.Where(g => g.Jugador.Nombre.Equals(aliJug.Jugador.Nombre)).Select(g => g.GolesFavor).FirstOrDefault();
                    sumaGF += gf;
                }
            }
            // sumar los goles en contra de los jugadores de la alineacion visitante
            if (aliEquipoB != null)
            {
                foreach (var aliJug in aliEquipoB)
                {
                    int gc = goleadores.Where(g => g.Jugador.Nombre.Equals(aliJug.Jugador.Nombre)).Select(g => g.GolesContra).FirstOrDefault();
                    sumaGC += gc;
                }
            }
            goles = sumaGF + sumaGC;

            return goles;
        }

        public static ClasificacionViewModel SetClasificacionViewModel(IMapper mapper, CompeticionDTO competicion, CompeticionCategoriaDTO categoria,
            ICollection<TemporadaCompeticionCategoriaReferenciaDTO> referencias, 
            ICollection<TemporadaClasificacionDTO> clasificaciones, 
            ICollection<TemporadaClasificacionDTO> clasificacionesSinBot, TemporadaCompeticionCategoriaDTO temporadaCompCat)
        {
            ClasificacionViewModel clasificacionViewModel = new ClasificacionViewModel
            {
                Categoria = competicion.Nombre + " - " + categoria.Categoria.Nombre,
                Premios = new List<ReferenciaPremioViewModel>(),
                Equipos = new List<EquipoClasificacionViewModel>()
            };
            foreach (var referencia in referencias)
            {
                ReferenciaPremioViewModel referenciaPremioViewModel = mapper.Map<ReferenciaPremioViewModel>(referencia);
                clasificacionViewModel.Premios.Add(referenciaPremioViewModel);
            }
            foreach (var clasificacion in clasificaciones)
            {
                EquipoClasificacionViewModel equipoClasificacionViewModel = LigamaniaMapperHelpers.MapEquipoClasificacionViewModel(mapper, clasificacion, referencias, clasificacionesSinBot);
                clasificacionViewModel.Equipos.Add(equipoClasificacionViewModel);
            }
            if (temporadaCompCat.MarcarPichichi)
            {
                var equiposSinPremio = clasificacionViewModel.Equipos.Where(e => e.Premio == null && e.PuestoSinBot!=0);
                if (equiposSinPremio.Any())
                {
                    // ordenar por puesto
                    var pichichi = equiposSinPremio.OrderByDescending(e => e.GolesFavor).Take(1);
                    var refPichichi = clasificacionViewModel.Premios.FirstOrDefault(e => e.Descripcion.Contains("Pichichi"));
                    pichichi.Single().Premio = refPichichi;
                }
            }
            clasificacionViewModel.Equipos = clasificacionViewModel.Equipos.OrderBy(c => c.Puesto).ToList();
            return clasificacionViewModel;
        }
        public static void CheckJugadoresAlineacion(List<AlineacionViewModel> alineacionActual, ICollection<string> aliprevia,
            ICollection<TemporadaJornadaJugadorDTO> goleadores, ICollection<string> preeliminados, ICollection<string> eliminados, ICollection<string> eliminadosPrevios,
            ICollection<TemporadaJornadaJugadorDTO> infoJugadores=null)
        {
            if (alineacionActual == null) return;

            foreach (var ali in alineacionActual)
            {
                if (aliprevia == null)
                    ali.Cambiado = true;
                else if (!aliprevia.Contains(ali.Jugador))
                    ali.Cambiado = true;
                else
                    ali.Cambiado = false;

                ali.Preeliminado = preeliminados != null ? preeliminados.Contains(ali.Jugador) : false;
                ali.Eliminado = eliminados != null && eliminadosPrevios!=null ? eliminados.Contains(ali.Jugador) || eliminadosPrevios.Contains(ali.Jugador) : false;

                if (goleadores != null)
                {
                    var goleador = goleadores.FirstOrDefault(g => g.Jugador.Nombre.Equals(ali.Jugador));
                    if (goleador != null) { ali.GF = goleador.GolesFavor; ali.GC = goleador.GolesContra; }
                }

                if (infoJugadores != null)
                {
                    var infoJugador = infoJugadores.FirstOrDefault(j => j.Jugador.Nombre.Equals(ali.Jugador));
                    if (infoJugador != null) 
                    { 
                        ali.MinutosJugados = infoJugador.MinutosJugados.GetValueOrDefault(); 
                        ali.TarjetasAmarillas = infoJugador.TarjetasAmarillas.GetValueOrDefault(); 
                        ali.TarjetasRojas = infoJugador.TarjetasRojas.GetValueOrDefault(); 
                    }
                }
            }
        }
    }
}
