using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Models.Inscripcion.EstudianteNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Incripcion.EstudianteNs
{
    public class EstudianteAppService : AsyncCrudAppService<Estudiante, EstudianteDto, int, PagedAndSortedResultRequestDto, EstudianteDto, EstudianteDto>, IEstudianteAppService
    {
        public EstudianteAppService(IRepository<Estudiante> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<EstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Estudiante>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Nombres.StartsWith(filter) || x.PrimerApellido.StartsWith(filter) 
                                                             || x.SegundoApellido.StartsWith(filter)
                                                             || x.Identificador.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<EstudianteDto>(query.Count(), ObjectMapper.Map<List<EstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<EstudianteDto>(query.Count(), ObjectMapper.Map<List<EstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Estudiante> ApplySorting(IQueryable<Estudiante> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<EstudianteDto> GetAllForSelect()
        {
            var paisList = new List<Estudiante>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<EstudianteDto>(ObjectMapper.Map<List<EstudianteDto>>(paisList));
        }
    }
}
