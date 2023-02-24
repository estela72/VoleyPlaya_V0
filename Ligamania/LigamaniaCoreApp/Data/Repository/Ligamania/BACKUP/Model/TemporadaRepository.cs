using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaRepository : GenericAuditableNameRepository<Temporada>, ITemporadaRepository
    {
        public TemporadaRepository(DbContext context)
            : base(context)
        {

        }
        public Temporada GetActual()
        {
            //return _dbset.Where(x => x.Actual).FirstOrDefault();
            return Find(x => x.Actual);
        }
        public Task<Temporada> GetActualAsync()
        {
            return FindAsync(x => x.Actual);
        }


        //public List<TemporadaCompeticion> GetCompeticionesActivas(int id)
        //{
        //    //return _dbset
        //    //    .Include(t => t.TemporadaCompeticion)
        //    //    .Where(t => t.Id.Equals(id))
        //    //    .FirstOrDefault()
        //    //    .TemporadaCompeticion
        //    //    .Where(c=>c.Activa)
        //    //    .ToList();
        //    var temporada = Get(id);
        //    var tempCompeticiones = temporada.TemporadaCompeticion.Where(c => c.Activa).ToList();
        //    return tempCompeticiones;
        //}

        public IQueryable<byte[]> GetImgClasificacion(int id)
        {
            var img = from temp in _dbset where temp.Id == id select temp.Img_Clasificacion;
            return img;
        }

        public async Task<IQueryable<byte[]>> GetImgClasificacionAsync(int id)
        {
            return await Task.Run(() => GetImgClasificacion(id));
        }
    }
}
