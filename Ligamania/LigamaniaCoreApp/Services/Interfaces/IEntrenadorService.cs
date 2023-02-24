using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Models.EntrenadorViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Utils;

namespace LigamaniaCoreApp.Services.Interfaces
{
    public interface IEntrenadorService
    {
        Task<AlineacionesCambiosViewModel> GetAlineaciones(string user);
        Task<Response> CambioJugador(InfoCambioJugador infoCambioJugador);
        Task<CarruselViewModel> GetCarrusel(string competicion, string categoria, int numJornada);
        Task<Response> EliminaAlineacion(InfoCambioJugador infoCambio);
    }
}
