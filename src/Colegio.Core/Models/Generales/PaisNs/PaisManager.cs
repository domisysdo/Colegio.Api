using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Models.Generales.PaisNs
{
    public class PaisManager : DomainService, IPaisManager
    {
        private readonly IRepository<Pais> _repositoryPais;

        public PaisManager(IRepository<Pais> repositoryPais)
        {
            _repositoryPais = repositoryPais;
        }

        public async Task<Pais> Create(Pais entity)
        {
            var Pais = _repositoryPais.FirstOrDefault(x => x.Id == entity.Id);

            if (Pais != null)
            {
                throw new UserFriendlyException("El país ya existe");
            }
            else
            {
                return await _repositoryPais.InsertAsync(entity);
            }
        }

        public void Delete(int PaisId)
        {
            var Pais = _repositoryPais.FirstOrDefault(x => x.Id == PaisId);

            if (Pais == null)
            {
                throw new UserFriendlyException("No se encontró el país");
            }
            else
            {
                _repositoryPais.Delete(Pais);
            }
        }

        public IEnumerable<Pais> GetAll()
        {
            return _repositoryPais.GetAllList();
        }

        public Pais GetPaisById(int PaisId)
        {
            return _repositoryPais.Get(PaisId);
        }

        public async Task Update(Pais entity)
        {
           await _repositoryPais.UpdateAsync(entity);
        }
    }
}
