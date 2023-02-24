using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaCompeticionCategoriaReferenciaRepository : GenericAuditableRepository<TemporadaCompeticionCategoriaReferenciaDTO>, ITemporadaCompeticionCategoriaReferenciaRepository
    {
        public TemporadaCompeticionCategoriaReferenciaRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<ICollection<TemporadaCompeticionCategoriaReferenciaDTO>> GetReferencias(int competicion_Id, int categoria_Id, bool usarMarca=true, string descripcionContains="")
        {
            ICollection<TemporadaCompeticionCategoriaReferenciaDTO> lista = new List<TemporadaCompeticionCategoriaReferenciaDTO>();
            try
            {
                var l1 = await FindAllAsync(cr => cr.Competicion != null && cr.Categoria != null && cr.Competicion.Id==competicion_Id
                        && cr.Categoria.Id == categoria_Id).ConfigureAwait(false);
                //var l2 = l1.Where(cr => cr.Competicion.Id.Equals(competicion_Id)
                //        && cr.Categoria.Id.Equals(categoria_Id));
                var l2 = l1.Where(cr => cr.Descripcion.Contains(descripcionContains)).ToList();
                var l3 = l1.Where(cr => cr.UsarMarca == usarMarca).ToList();
                lista = l3;
                return lista;
            }
            catch (Exception x)
            {
                return lista;
            }
        }
    }
}
