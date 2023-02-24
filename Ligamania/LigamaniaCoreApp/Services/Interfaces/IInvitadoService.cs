using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Utils;

namespace LigamaniaCoreApp.Services.Interfaces
{
    public interface IInvitadoService
    {
        Task<ICollection<HistorialViewModel>> GetHistorial();
        Task<HistorialEquipoViewModel> GetHistorialEquipo(string equipo);
        string GetImageCategoriaHistorial(string categoria, int puesto);
        Task<ClasificacionHistoricaViewModel> GetClasificacionHistorica();
        Task<PremiosViewModel> GetPremiosTemporada(TemporadaDTO temporada, ICollection<TemporadaEquipoDTO> equipos);
        Task<ICollection<ReglamentoViewModel>> GetAllReglamentos();
        Task<ReglamentoViewModel> FindReglamento(int fileId);
        Task<ICollection<CalendarioViewModel>> GetCalendarios();
        Task<PremiosViewModel> GetPremiosTemporada(string temporada);
        Task<Response> SaveDocument(string descripcion, string filename, string contentType, byte[] bytes);
        Task<Response> DeleteDocumento(int id);
    }
}
