using AutoMapper;

using Ligamania.API.Lib.Models;
using Ligamania.API.Lib.Services;
using Ligamania.Web.Models;
using Ligamania.Web.Models.Club;
using Ligamania.Web.Models.Competicion;
using Ligamania.Web.Models.Contabilidad;
using Ligamania.Web.Models.Jugador;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Services
{
    public interface IPreparacionService
    {
        Task<IEnumerable<CompeticionVM>> GetAllCompeticiones();
        Task<IEnumerable<CategoriaVM>> GetCategorias(int idCompeticion);
        Task<CompeticionVM> DeleteCompeticionById(int id);
        Task<CompeticionVM> GetCompeticionById(int id);
        Task<CompeticionVM> UpdateCompeticion(int id, CompeticionVM competicion);
        Task<CompeticionVM> CreateCompeticion(CompeticionVM competicion);
        Task<CompeticionVM> UpdateCategoriaToCompeticion(int newCategoria, int competicionId);
        Task<ParametroVM> GetParametros();
        Task<CompeticionVM> DeleteCategoriaFromCompeticion(int competicionId, int categoriaId);
        Task<IEnumerable<ClubVM>> GetAllClubs();
        Task<ClubVM> CreateClub(ClubVM club);
        Task<ClubVM> GetClubById(int id);
        Task<IEnumerable<DocumentoVM>> GetAllDocumentos();
        Task<IEnumerable<CalendarioVM>> GetAllCalendarios();
        Task<IEnumerable<JugadorVM>> GetAllJugadores();
        Task<ParametroVM> UpdateParametros(ParametroVM parametro);
        Task<ClubVM> UpdateClub(int id, ClubVM club);
        Task<ClubVM> DeleteClubById(int id);
        Task<JugadorVM> CreateJugador(JugadorVM jugador);
        Task<JugadorVM> UpdateJugador(int id, JugadorVM jugador);
        Task<JugadorVM> GetJugadorById(int id);
        Task<DocumentoVM> GetDocumentoById(int id);
        Task<JugadorVM> DeleteJugadorById(int id);
        Task<CalendarioVM> CreateCalendario(CalendarioVM calendario);
        Task<CalendarioVM> GetCalendarioById(int id);
        Task<CalendarioVM> UpdateCalendario(int id, CalendarioVM calendario);
        Task<CalendarioVM> DeleteCalendarioById(int id);
        Task<CalendarioVM> UpdatePartidoCalendario(int calendarioId, int id, int jornada, string local, string visitante);
        Task<CalendarioVM> DeletePartidoCalendario(int calendarioId, int id);
        Task<DocumentoVM> CreateDocumento(DocumentoVM documento);
        Task<DocumentoVM> DeleteDocumentoById(int id);
        Task<DocumentoVM> UpdateDocumento(int id, DocumentoVM documento);
        Task<IEnumerable<ContabilidadVM>> GetContabilidades();
        Task<string> UpdateContabilidadTemporadaAsync(ConceptoContabilidad contabilidad);
        Task<string> RemoveContabilidadTemporada(int id);
        Task<string> UpdatePremioTemporadaAsync(PremioContabilidadVM premio);
        Task<string> RemovePremioTemporada(int id);
    }
    public class PreparacionService : IPreparacionService
    {
        private const string CompeticionDummyName = "Dummy";
        private ILocalStorageService _localStorageService;
        private IMapper _mapper;
        private readonly ICompeticionService _competicionService;
        private readonly IClubService _clubService;
        private readonly IJugadorService _jugadorService;
        private readonly ICalendarioService _calendarioService;
        private readonly IDocumentService _documentService;
        private readonly IParametrosService _parametrosService;
        private readonly ITemporadaService _temporadaService;

        public PreparacionService(
            ILocalStorageService localStorageService
            , IMapper mapper
            , ICompeticionService competicionService
            , IClubService clubService
            , IJugadorService jugadorService
            , ICalendarioService calendarioService
            , IDocumentService documentService
            , IParametrosService parametrosService
            , ITemporadaService temporadaService
        )
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _competicionService = competicionService;
            _clubService = clubService;
            _jugadorService = jugadorService;
            _calendarioService = calendarioService;
            _documentService = documentService;
            _parametrosService = parametrosService;
            _temporadaService = temporadaService;
        }

        public async Task<IEnumerable<CompeticionVM>> GetAllCompeticiones()
        {
            var list = await _competicionService.GetAllCompeticiones();
            return _mapper.Map<IEnumerable<CompeticionVM>>(list);
        }

        public async Task<IEnumerable<CategoriaVM>> GetCategorias(int idCompeticion)
        {
            var list = await _competicionService.GetCategorias(idCompeticion);
            return _mapper.Map<IEnumerable<CategoriaVM>>(list);
        }

        public async Task<CompeticionVM> DeleteCompeticionById(int id)
        {
            var competicion = await _competicionService.DeleteCompeticionById(id);
            return _mapper.Map<CompeticionVM>(competicion);
        }

        public async Task<CompeticionVM> GetCompeticionById(int id)
        {
            var competicion = await _competicionService.GetCompeticionById(id);
            return _mapper.Map<CompeticionVM>(competicion);
        }

        public async Task<CompeticionVM> UpdateCompeticion(int id, CompeticionVM editCompeticion)
        {
            var competicionUpdated = _mapper.Map<Competicion>(editCompeticion);
            var competicion = await _competicionService.UpdateCompeticion(id, competicionUpdated);
            return _mapper.Map<CompeticionVM>(competicion);
        }

        public async Task<CompeticionVM> CreateCompeticion(CompeticionVM createCompeticion)
        {
            var competicionCreated = _mapper.Map<Competicion>(createCompeticion);
            var competicion = await _competicionService.Create(competicionCreated);
            return _mapper.Map<CompeticionVM>(competicion);
        }

        public async Task<CompeticionVM> UpdateCategoriaToCompeticion(int newCategoria, int competicionId)
        {
            var competicion = await _competicionService.UpdateCategoriaToCompeticion(newCategoria, competicionId);
            return _mapper.Map<CompeticionVM>(competicion);
        }

        public async Task<CompeticionVM> DeleteCategoriaFromCompeticion(int competicionId, int categoriaId)
        {
            var competicion = await _competicionService.DeleteCategoriaFromCompeticion(competicionId, categoriaId);
            return _mapper.Map<CompeticionVM>(competicion);
        }

        public async Task<IEnumerable<ClubVM>> GetAllClubs()
        {
            var list = await _clubService.GetAllClubs();
            return _mapper.Map<IEnumerable<ClubVM>>(list);
        }

        public async Task<ClubVM> CreateClub(ClubVM club)
        {
            var clubToCreate = _mapper.Map<Club>(club);
            var clubCreated = await _clubService.Create(clubToCreate);
            return _mapper.Map<ClubVM>(clubCreated);
        }

        public async Task<ClubVM> GetClubById(int id)
        {
            var club = await _clubService.GetClubById(id);
            return _mapper.Map<ClubVM>(club);
        }

        public async Task<ClubVM> UpdateClub(int id, ClubVM clubToUpdate)
        {
            var clubUpdated = _mapper.Map<Club>(clubToUpdate);
            var club = await _clubService.UpdateClub(id, clubUpdated);
            return _mapper.Map<ClubVM>(club);
        }

        public async Task<ClubVM> DeleteClubById(int id)
        {
            var club = await _clubService.DeleteById(id);
            return _mapper.Map<ClubVM>(club);
        }

        public async Task<IEnumerable<JugadorVM>> GetAllJugadores()
        {
            var list = await _jugadorService.GetAllJugadores();
            return _mapper.Map<IEnumerable<JugadorVM>>(list);
        }

        public async Task<JugadorVM> CreateJugador(JugadorVM jugador)
        {
            var JugadorToCreate = _mapper.Map<Jugador>(jugador);
            var JugadorCreated = await _jugadorService.Create(JugadorToCreate);
            return _mapper.Map<JugadorVM>(JugadorCreated);
        }

        public async Task<JugadorVM> UpdateJugador(int id, JugadorVM jugadorToUpdate)
        {
            var JugadorUpdated = _mapper.Map<Jugador>(jugadorToUpdate);
            var Jugador = await _jugadorService.UpdateJugador(id, JugadorUpdated);
            return _mapper.Map<JugadorVM>(Jugador);
        }

        public async Task<JugadorVM> GetJugadorById(int id)
        {
            var Jugador = await _jugadorService.GetJugadorById(id);
            return _mapper.Map<JugadorVM>(Jugador);
        }

        public async Task<JugadorVM> DeleteJugadorById(int id)
        {
            var Jugador = await _jugadorService.DeleteById(id);
            return _mapper.Map<JugadorVM>(Jugador);
        }

        public async Task<IEnumerable<CalendarioVM>> GetAllCalendarios()
        {
            var list = await _calendarioService.GetAllCalendarios();
            return _mapper.Map<IEnumerable<CalendarioVM>>(list);
        }

        public async Task<CalendarioVM> CreateCalendario(CalendarioVM calendario)
        {
            var calendarioToCreate = _mapper.Map<Calendario>(calendario);
            var calendarioCreated = await _calendarioService.Create(calendarioToCreate);
            return _mapper.Map<CalendarioVM>(calendarioCreated);
        }

        public async Task<CalendarioVM> GetCalendarioById(int id)
        {
            var calendario = await _calendarioService.GetCalendarioById(id);
            return _mapper.Map<CalendarioVM>(calendario);
        }

        public async Task<CalendarioVM> UpdateCalendario(int id, CalendarioVM calendario)
        {
            var calendarioToUpdate = _mapper.Map<Calendario>(calendario);
            var calendarioUpdated = await _calendarioService.UpdateCalendario(id, calendarioToUpdate);
            return _mapper.Map<CalendarioVM>(calendarioUpdated);
        }

        public async Task<CalendarioVM> DeleteCalendarioById(int id)
        {
            var calendario = await _calendarioService.DeleteById(id);
            return _mapper.Map<CalendarioVM>(calendario);
        }

        public async Task<CalendarioVM> UpdatePartidoCalendario(int calendarioId, int id, int jornada, string local, string visitante)
        {
            var calendario = await _calendarioService.UpdatePartidoCalendario(calendarioId, id, jornada, local, visitante);
            return _mapper.Map<CalendarioVM>(calendario);
        }

        public async Task<CalendarioVM> DeletePartidoCalendario(int calendarioId, int id)
        {
            var calendario = await _calendarioService.DeletePartidoCalendario(calendarioId, id);
            return _mapper.Map<CalendarioVM>(calendario);
        }

        public async Task<IEnumerable<DocumentoVM>> GetAllDocumentos()
        {
            var list = await _documentService.GetAllDocumentos();
            return _mapper.Map<IEnumerable<DocumentoVM>>(list);
        }

        public async Task<DocumentoVM> GetDocumentoById(int id)
        {
            var documento = await _documentService.GetDocumentoById(id);
            return _mapper.Map<DocumentoVM>(documento);
        }

        public async Task<DocumentoVM> CreateDocumento(DocumentoVM documento)
        {
            var documentoToCreate = _mapper.Map<Documento>(documento);
            var documentoCreated = await _documentService.Create(documentoToCreate);
            return _mapper.Map<DocumentoVM>(documentoCreated);
        }

        public async Task<DocumentoVM> DeleteDocumentoById(int id)
        {
            var documento = await _documentService.DeleteById(id);
            return _mapper.Map<DocumentoVM>(documento);
        }

        public async Task<DocumentoVM> UpdateDocumento(int id, DocumentoVM documentoToUpdate)
        {
            var doc = _mapper.Map<Documento>(documentoToUpdate);
            var documento = await _documentService.UpdateDocumento(id, doc);
            return _mapper.Map<DocumentoVM>(documento); 
        }

        public async Task<ParametroVM> GetParametros()
        {
            var parametros = await _parametrosService.GetParametros();
            return _mapper.Map<ParametroVM>(parametros);
        }

        public async Task<ParametroVM> UpdateParametros(ParametroVM parametro)
        {
            var param = _mapper.Map<Parametro>(parametro);
            var parametroUpdated = await _parametrosService.UpdateParametros(param);
            return _mapper.Map<ParametroVM>(parametroUpdated);
        }

        public async Task<IEnumerable<ContabilidadVM>> GetContabilidades()
        {
            List<ContabilidadVM> lista = new List<ContabilidadVM>();
            var list = await _temporadaService.GetContabilidades();
            var temporadas = list.Select(c => c.Temporada).Distinct();
            foreach (var temporada in temporadas)
            {
                var conceptos = list.Where(c => c.Temporada.Equals(temporada)).ToList();
                var premios = await _temporadaService.GetPremiosTemporadaAsync(temporada);
                var contabilidad = new ContabilidadVM
                {
                    Temporada = temporada,
                    Equipos = conceptos.First().Equipos,
                    Conceptos = _mapper.Map<List<ConceptoContabilidad>>(conceptos),
                    RepartoPremios = _mapper.Map<List<PremioContabilidadVM>>(premios)
                };
                lista.Add(contabilidad);
            }
            return lista;
        }

        public async Task<string> UpdateContabilidadTemporadaAsync(ConceptoContabilidad contabilidad)
        {
            var concepto = _mapper.Map<ContabilidadDto>(contabilidad);
            var updated = await _temporadaService.UpdateConceptoContabilidad(concepto);
            return updated;
        }

        public async Task<string> RemoveContabilidadTemporada(int id)
        {
            return await _temporadaService.RemoveConceptoContabilidad(id);
        }

        public async Task<string> UpdatePremioTemporadaAsync(PremioContabilidadVM premio)
        {
            return await _temporadaService.UpdatePremioTemporadaAsync(_mapper.Map<PremioDto>(premio));
        }

        public async Task<string> RemovePremioTemporada(int id)
        {
            return await _temporadaService.RemovePremioTemporadaAsynd(id);
        }
    }
}
