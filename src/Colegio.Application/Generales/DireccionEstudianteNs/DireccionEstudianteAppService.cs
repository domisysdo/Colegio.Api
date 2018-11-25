using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.DireccionEstudianteNs;
using Colegio.Models.Generales.DireccionEstudianteNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.DireccionEstudianteNs
{
    public class DireccionEstudianteAppService : AsyncCrudAppService<DireccionEstudiante, DireccionEstudianteDto, int, PagedAndSortedResultRequestDto, DireccionEstudianteDto, DireccionEstudianteDto>, IDireccionEstudianteAppService
    {
        public DireccionEstudianteAppService(IRepository<DireccionEstudiante> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<DireccionEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<DireccionEstudiante>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<DireccionEstudianteDto>(query.Count(), ObjectMapper.Map<List<DireccionEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<DireccionEstudianteDto>(query.Count(), ObjectMapper.Map<List<DireccionEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<DireccionEstudiante> ApplySorting(IQueryable<DireccionEstudiante> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<DireccionEstudianteDto> GetAllForSelect()
        {
            var paisList = new List<DireccionEstudiante>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<DireccionEstudianteDto>(ObjectMapper.Map<List<DireccionEstudianteDto>>(paisList));
        }
    }
}
