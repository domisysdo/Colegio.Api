using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Models.EstudianteNs
{
    public class EstudianteManager : DomainService, IEstudianteManager
    {
        private readonly IRepository<Estudiante> _repositoryEstudiante;

        public EstudianteManager(IRepository<Estudiante> repositoryEstudiante)
        {
            _repositoryEstudiante = repositoryEstudiante;
        }

        public async Task<Estudiante> Create(Estudiante entity)
        {
            var estudiante = _repositoryEstudiante.FirstOrDefault(x => x.Id == entity.Id);

            if (estudiante != null)
            {
                throw new UserFriendlyException("El estudiante ya existe");
            }
            else
            {
                return await _repositoryEstudiante.InsertAsync(entity);
            }
        }

        public void Delete(int estudianteId)
        {
            var estudiante = _repositoryEstudiante.FirstOrDefault(x => x.Id == estudianteId);

            if (estudiante == null)
            {
                throw new UserFriendlyException("No se encontró el estudiante");
            }
            else
            {
                _repositoryEstudiante.Delete(estudiante);
            }
        }

        public IEnumerable<Estudiante> GetAll()
        {
            return _repositoryEstudiante.GetAllList();
        }

        public Estudiante GetEstudianteById(int estudianteId)
        {
            return _repositoryEstudiante.Get(estudianteId);
        }

        public async Task Update(Estudiante entity)
        {
           await _repositoryEstudiante.UpdateAsync(entity);
        }
    }
}
