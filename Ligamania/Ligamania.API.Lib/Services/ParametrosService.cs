using AutoMapper;

using Ligamania.API.Lib.Models;
using Ligamania.Repository;
using Ligamania.Repository.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Services
{
    public interface IParametrosService
    {
        Task<Parametro> GetParametros();
        Task<Parametro> UpdateParametros(Parametro param);
    }
    internal class ParametrosService : IParametrosService
    {
        private readonly IMapper _mapper;
        private readonly ILigamaniaUnitOfWork _ligamaniaUnitOfWork;

        public ParametrosService(ILigamaniaUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _ligamaniaUnitOfWork = unitOfWork;
        }

        public async Task<Parametro> GetParametros()
        {
            var parametros = await _ligamaniaUnitOfWork.ParametroRepository.GetAllAsync();
            return _mapper.Map<Parametro>(parametros.FirstOrDefault());
        }

        public async Task<Parametro> UpdateParametros(Parametro param)
        {
            var settings = _mapper.Map<SettingsDTO>(param);
            var paramUpdated = await _ligamaniaUnitOfWork.ParametroRepository.UpdateAsync(settings);
            if (paramUpdated!=null)
                await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return _mapper.Map<Parametro>(paramUpdated);
        }
    }
}
