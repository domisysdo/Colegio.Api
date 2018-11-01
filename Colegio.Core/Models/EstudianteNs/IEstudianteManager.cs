using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Models.EstudianteNs
{
    public interface IEstudianteManager : IDomainService
    {
        IEnumerable<Estudiante> GetAll();
        Estudiante GetEstudianteById(int estudianteId);
        Task<Estudiante> Create(Estudiante estudiante);
        Task Update(Estudiante estudiante);
        void Delete(int estudianteId);
    }
}
