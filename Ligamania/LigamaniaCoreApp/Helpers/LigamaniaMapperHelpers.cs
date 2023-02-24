using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.GlobalViewModels;

namespace LigamaniaCoreApp.Helpers
{
    public static class LigamaniaMapperHelpers
    {
        
        internal static EquipoClasificacionViewModel MapEquipoClasificacionViewModel(IMapper mapper, TemporadaClasificacionDTO clasificacion, 
            ICollection<TemporadaCompeticionCategoriaReferenciaDTO> referencias, ICollection<TemporadaClasificacionDTO> clasificacionesSinBot)
        {
            EquipoClasificacionViewModel equipoClasificacionViewModel = new EquipoClasificacionViewModel
            {
                Equipo = clasificacion.Equipo.Nombre,
                Diferencia = clasificacion.Diferencia,
                Empatados = clasificacion.Empatados,
                Ganados = clasificacion.Ganados,
                GolesContra = clasificacion.GolesContra,
                GolesFavor = clasificacion.GolesFavor,
                GolesExtraContra = clasificacion.GolesExtraContra,
                GolesExtraFavor = clasificacion.GolesExtraFavor,
                Jugados = clasificacion.Jugados,
                Perdidos = clasificacion.Perdidos,
                Puesto = clasificacion.Puesto,
                PuestoSinBot = clasificacion.Puesto,
                Puntos = clasificacion.Puntos
            }; 
                //mapper.Map<EquipoClasificacionViewModel>(clasificacion);
            // en función del puesto, asignamos el premio
            // clasificacionesSinBot nos llega ordenado de forma descendente sin equipos bot
            int posicion = clasificacionesSinBot.ToList().FindIndex(c => c.Equipo.Nombre.Equals(equipoClasificacionViewModel.Equipo));
            posicion++;
            equipoClasificacionViewModel.Puesto = clasificacion.Puesto;
            equipoClasificacionViewModel.PuestoSinBot = posicion;
            // dependiendo del puesto, tendrá un color (TEmporadaCompeticionCategoriaReferencia)
            if (posicion != 0)
            {
                var referencia = referencias
                    .FirstOrDefault(r => /*r.UsarColor &&*/ posicion >= r.PosicionInicial && posicion <= r.PosicionFinal);

                var premio = mapper.Map<ReferenciaPremioViewModel>(referencia);
                equipoClasificacionViewModel.Premio = premio;
            }
            return equipoClasificacionViewModel;
        }
    }
}
