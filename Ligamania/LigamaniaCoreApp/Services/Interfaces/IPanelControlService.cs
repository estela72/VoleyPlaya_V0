using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.AdminViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Services.Interfaces
{
    public interface IPanelControlService
    {
        Task<ICollection<TemporadaCompeticionViewModel>> GetCompeticionesActivas();
        Task<TemporadaCompeticionViewModel> GetTemporadaCompeticion(int idCompeticion);
        Task<TemporadaCompeticionViewModel> GetTemporadaCompeticionByNombre(string competicion);
        Task<Response> AbrirAlineaciones(TemporadaCompeticionViewModel competicionPC);
        Task<Response> CerrarAlineaciones(TemporadaCompeticionViewModel competicionPC);
        Task<Response> CalcularPreeliminados(TemporadaCompeticionViewModel competicionPC);
        Task<Response> PublicarCarrusel(TemporadaCompeticionViewModel competicionPC);
        Task<Response> CalcularResultados(TemporadaCompeticionViewModel competicionPC);
        Task<Response> ActualizarClasificacion(TemporadaCompeticionViewModel competicionPC);
        Task<Response> RecalcularResultados(TemporadaCompeticionViewModel competicionPC);
        Task<Response> RecalcularClasificacion(TemporadaCompeticionViewModel competicionPC); 
        Task<Response> ActualizarEliminados(TemporadaCompeticionViewModel competicionPC);
        Task<Response> RescatarEliminados(TemporadaCompeticionViewModel competicionPC);
        Task<Response> CambiarJornada(TemporadaCompeticionViewModel competicionPC);
        Task<Response> AbrirCambios(TemporadaCompeticionViewModel competicionPC);
        Task<Response> AbrirCambiosForzado(TemporadaCompeticionViewModel competicionPC);
        Task<Response> CerrarCambios(TemporadaCompeticionViewModel competicionPC);
        Task<Response> CerrarJornada(TemporadaCompeticionViewModel competicionPC);
        Task<Response> GuardarAlineaciones(TemporadaCompeticionViewModel competicionPC);
        Task<GoleadoresViewModel> GetGoleadores(string club, DateTime fecha);
        Task<Response> ActualizarGoles(GolesJugador goles);
        Task<Response> ActivarRondaCopa(TemporadaCompeticionViewModel competicionPC);
        Task<Response> EstablecerGanadoresPartidosCopa(TemporadaCompeticionViewModel competicion);
        Task<ResponseOfTReturn<TemporadaRondaPartidos>> GetPartidosRondaSinGanador();
        Task<TemporadaPartidoRondaViewModel> GetPartidoRonda(int partidoId);
        Task<Response> EditarJugador(AlineacionViewModel jugadorInfo);
        Task<Response> SetCriterioGanadorPartido(TemporadaPartidoRondaViewModel infoRonda);
        Task<List<TemporadaRondaPartidos>> GetAllRondasConPartidos();
        //Task<Response> ResetearCompeticion(TemporadaCompeticionViewModel competicion);
        Task<Response> CheckResultadoPartidos();
        Task<Response> SetGanadorPartidoManual(TemporadaPartidoRondaViewModel infoRonda);
        Task<int> GetRondaActiva();
        Task<Response> SetAlineacionLibre(TemporadaCompeticionViewModel competicionPC);
    }
}
