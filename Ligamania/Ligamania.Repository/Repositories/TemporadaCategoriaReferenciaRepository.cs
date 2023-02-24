using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaCompeticionCategoriaReferenciaRepository : Repository<TemporadaCompeticionCategoriaReferenciaDTO>, ITemporadaCompeticionCategoriaReferenciaRepository
    {
        public TemporadaCompeticionCategoriaReferenciaRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<TemporadaCompeticionCategoriaReferenciaDTO>> GetReferencias(int competicion_Id, int categoria_Id, bool usarMarca = true, string descripcionContains = "")
        {
            ICollection<TemporadaCompeticionCategoriaReferenciaDTO> lista = new List<TemporadaCompeticionCategoriaReferenciaDTO>();
            try
            {
                var l1 = await FindAllAsync(cr => cr.Competicion != null && cr.Categoria != null && cr.Competicion.Id == competicion_Id
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
                Console.WriteLine(x.Message);
                return lista;
            }
        }
    }
}