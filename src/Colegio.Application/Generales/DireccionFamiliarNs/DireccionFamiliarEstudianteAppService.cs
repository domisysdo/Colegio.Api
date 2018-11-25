using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.DireccionFamiliarEstudianteNs;
using Colegio.Models.Generales.DireccionFamiliarEstudianteNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.DireccionFamiliarEstudianteNs
{
    public class DireccionFamiliarEstudianteAppService : AsyncCrudAppService<DireccionFamiliarEstudiante, DireccionFamiliarEstudianteDto, int, PagedAndSortedResultRequestDto, DireccionFamiliarEstudianteDto, DireccionFamiliarEstudianteDto>, IDireccionFamiliarEstudianteAppService
    {
        public DireccionFamiliarEstudianteAppService(IRepository<DireccionFamiliarEstudiante> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<DireccionFamiliarEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<DireccionFamiliarEstudiante>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<DireccionFamiliarEstudianteDto>(query.Count(), ObjectMapper.Map<List<DireccionFamiliarEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<DireccionFamiliarEstudianteDto>(query.Count(), ObjectMapper.Map<List<DireccionFamiliarEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<DireccionFamiliarEstudiante> ApplySorting(IQueryable<DireccionFamiliarEstudiante> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<DireccionFamiliarEstudianteDto> GetAllForSelect()
        {
            var paisList = new List<DireccionFamiliarEstudiante>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<DireccionFamiliarEstudianteDto>(ObjectMapper.Map<List<DireccionFamiliarEstudianteDto>>(paisList));
        }
    }
}
