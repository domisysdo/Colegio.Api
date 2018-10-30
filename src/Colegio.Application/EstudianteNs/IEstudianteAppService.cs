using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.EstudianteNs
{
    public interface IEstudianteAppService: IApplicationService
    {
        IEnumerable<GetEstudianteOutput> GetAll();
        Task Create(CreateEstudianteInput input);
        void Update(UpdateEstudianteInput input);
        void Delete(DeleteEstudianteInput input);
        GetEstudianteOutput GetEstudianteById(GetEstudianteInput input);

    }
}
