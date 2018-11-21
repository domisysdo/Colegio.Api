using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Models.Generales.PaisNs
{
    public interface IPaisManager : IDomainService
    {
        IEnumerable<Pais> GetAll();
        Pais GetPaisById(int paisId);
        Task<Pais> Create(Pais pais);
        Task Update(Pais pais);
        void Delete(int paisId);
    }
}
