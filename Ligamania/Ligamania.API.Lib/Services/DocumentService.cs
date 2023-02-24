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
    public interface IDocumentService
    {
        Task<IEnumerable<Documento>> GetAllDocumentos();
        Task<Documento> Create(Documento docToCreate);
        Task<Documento> GetDocumentoById(int id);
        Task<Documento> UpdateDocumento(int id, Documento docToUpdate);
        Task<Documento> DeleteById(int id);
    }
    public class DocumentService : IDocumentService
    {
        private readonly IMapper _mapper;
        private readonly ILigamaniaUnitOfWork _ligamaniaUnitOfWork;

        public DocumentService(ILigamaniaUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _ligamaniaUnitOfWork = unitOfWork;
        }
        public async Task<Documento> Create(Documento docToCreate)
        {
            var documento = _ligamaniaUnitOfWork.DocumentsRepository.FindBy(c => c.Nombre.Equals(docToCreate.Nombre));
            if (documento.Any()) // ya existe un calendario con este nombre
                return new Documento("Ya existe un documento con este nombre");

            DocumentsDTO newDocumento = new DocumentsDTO { Nombre = docToCreate.Nombre, Description = docToCreate.Description, ContentType=docToCreate.ContentType, Content=docToCreate.Content};
            var documentoCreated = await _ligamaniaUnitOfWork.DocumentsRepository.CreateAsync(newDocumento);
            var saved = await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            if (saved) return _mapper.Map<Documento>(documentoCreated);
            return new Documento("Se ha producido un error al crear el documento");
        }

        public async Task<Documento> DeleteById(int id)
        {
            var deleted = await _ligamaniaUnitOfWork.DocumentsRepository.DeleteAsync(id);
            var saved = await _ligamaniaUnitOfWork.SaveEntitiesAsync();

            if (saved) return new Documento("Documento eliminado correctamente");
            return new Documento("Se ha producido un error al eliminar el documento");
        }

        public async Task<IEnumerable<Documento>> GetAllDocumentos()
        {
            var list = await _ligamaniaUnitOfWork.DocumentsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Documento>>(list);
        }

        public async Task<Documento> GetDocumentoById(int id)
        {
            var documento = await _ligamaniaUnitOfWork.DocumentsRepository.GetByIdAsync(id);
            return _mapper.Map<Documento>(documento);
        }

        public async Task<Documento> UpdateDocumento(int id, Documento docToUpdate)
        {
            var doc = _mapper.Map<DocumentsDTO>(docToUpdate);
            var updated = await _ligamaniaUnitOfWork.DocumentsRepository.UpdateAsync(doc);
            var saved = await _ligamaniaUnitOfWork.SaveEntitiesAsync();

            if (saved) return new Documento("Documento actualizado correctamente");
            return new Documento("Se ha producido un error al actualizar el documento");
        }
    }
}
