using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.IncidenciaEstudianteNs;
using Colegio.Models.Generales.IncidenciaEstudianteNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.IncidenciaEstudianteNs
{
    public class IncidenciaEstudianteAppService : AsyncCrudAppService<IncidenciaEstudiante, IncidenciaEstudianteDto, int, PagedAndSortedResultRequestDto, IncidenciaEstudianteDto, IncidenciaEstudianteDto>, IIncidenciaEstudianteAppService
    {
        public IncidenciaEstudianteAppService(IRepository<IncidenciaEstudiante> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<IncidenciaEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<IncidenciaEstudiante>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<IncidenciaEstudianteDto>(query.Count(), ObjectMapper.Map<List<IncidenciaEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<IncidenciaEstudianteDto>(query.Count(), ObjectMapper.Map<List<IncidenciaEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<IncidenciaEstudiante> ApplySorting(IQueryable<IncidenciaEstudiante> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<IncidenciaEstudianteDto> GetAllForSelect()
        {
            var paisList = new List<IncidenciaEstudiante>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<IncidenciaEstudianteDto>(ObjectMapper.Map<List<IncidenciaEstudianteDto>>(paisList));
        }
    }
}
