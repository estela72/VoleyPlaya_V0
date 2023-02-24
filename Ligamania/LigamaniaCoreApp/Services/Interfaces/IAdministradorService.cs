using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.AdminViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Utils;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Services.Interfaces
{
    public interface IAdministradorService
    {
        Task<ICollection<ClubViewModel>> GetClubsViewModel();
        Task<ResponseOfTReturn<ClubViewModel>> BajaClub(int id);
        Task<ResponseOfTReturn<ClubViewModel>> AltaClub(int id);
        Task<ICollection<JugadorViewModel>> GetJugadoresViewModel();
        Task<ICollection<TemporadaJugadorViewModel>> GetJugadoresViewModelFromTemporada(int temporadaId);
        Task<List<TemporadaJugadorViewModel>> GetAllJugadoresWithTemporada();

        Task<Response> CopiarJugadoresEntreTemporadas(int fromTemporada, int toTemporada);
        eCheckJugadorResponse CheckNombreJugador(string jugadorName);
        Task<Response> AltaJugador(TemporadaJugadorViewModel jugadorInfo, TemporadaDTO preTemporada);
        Task<Response> EditarJugador(TemporadaJugadorViewModel jugadorInfo);
        Task<Response> BorrarJugador(int idJugador);
        Task<Response> BajaJugador(int idJugador);
        Task<Response> BorrarTemporadaJugador(int idJugador);
        Task<Response> BajaTemporadaJugador(int idJugador);
        Task<Response> EditarTemporadaJugador(TemporadaJugadorViewModel jugadorInfo);
        eCheckClubResponse CheckNuevoClub(ClubViewModel club);
        Task<Response> NuevoClub(ClubViewModel club);
        Task<ResponseOfTReturn<List<string>>> LoadJugadoresFromExcel(string clubName, List<JugadorActivoExcelDto> jugadores);
        Task<Response> DesactivarAllJugadores();
    }
}
