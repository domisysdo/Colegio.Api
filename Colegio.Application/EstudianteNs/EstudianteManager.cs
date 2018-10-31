using Abp.Application.Services;
using AutoMapper;
using Colegio.Models.EstudianteNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.EstudianteNs
{
    public class EstudianteManager : ApplicationService, IEstudianteAppService
    {
        private readonly IEstudianteManager _estudianteManager;

        public EstudianteManager(IEstudianteManager estudianteManager)
        {
            _estudianteManager = estudianteManager;
        }

        public async Task Create(CreateEstudianteInput input)
        {
            Estudiante output = Mapper.Map<CreateEstudianteInput, Estudiante>(input);
            await _estudianteManager.Create(output);
        }

        public void Delete(DeleteEstudianteInput input)
        {
            _estudianteManager.Delete(input.Id);
        }

        public IEnumerable<GetEstudianteOutput> GetAll()
        {
            var getAll = _estudianteManager.GetAll().ToList();
            List<GetEstudianteOutput> output = Mapper.Map<List<Estudiante>, List<GetEstudianteOutput>>(getAll);
            return output;
        }

        public GetEstudianteOutput GetEstudianteById(GetEstudianteInput input)
        {
            var getEstudiante = _estudianteManager.GetEstudianteById(input.Id);
            GetEstudianteOutput output = Mapper.Map<Estudiante, GetEstudianteOutput>(getEstudiante);
            return output;
        }

        public void Update(UpdateEstudianteInput input)
        {
            Estudiante output = Mapper.Map<UpdateEstudianteInput, Estudiante>(input);
            _estudianteManager.Update(output);
        }
    }
}
