using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.HerramientasViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Services.Interfaces
{
    public interface IHerramientasService
    {
        Task<Response> RevisarClubsAlineaciones();
        Task<AlineacionCompeticionViewModel> GetAlineacionesCompeticion(string competicion);
        Task<Response> AgregarAlineacion(AlineacionCompeticionJornadaViewModel alineacion);
        Task<Response> EditarAlineacion(AlineacionCompeticionJornadaViewModel alineacion);
        Task<Response> BorrarAlineacion(AlineacionCompeticionJornadaViewModel alineacion);
        Task<ICollection<CambioEquipoViewModel>> GetCambiosEquipos();
        Task<List<JugadorRepositoryViewModel>> GetAllJugadoresLigamania();
    }
}
