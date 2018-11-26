using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Models.Inscripcion.GeneralNs.FamiliarEstudianteNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Incripcion.FamiliarEstudianteNs
{
    public class FamiliarEstudianteAppService : AsyncCrudAppService<FamiliarEstudiante, FamiliarEstudianteDto, int, PagedAndSortedResultRequestDto, FamiliarEstudianteDto, FamiliarEstudianteDto>, IFamiliarEstudianteAppService
    {
        public FamiliarEstudianteAppService(IRepository<FamiliarEstudiante> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<FamiliarEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<FamiliarEstudiante>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Nombres.StartsWith(filter) || x.PrimerApellido.StartsWith(filter) 
                                                             || x.SegundoApellido.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<FamiliarEstudianteDto>(query.Count(), ObjectMapper.Map<List<FamiliarEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<FamiliarEstudianteDto>(query.Count(), ObjectMapper.Map<List<FamiliarEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<FamiliarEstudiante> ApplySorting(IQueryable<FamiliarEstudiante> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<FamiliarEstudianteDto> GetAllForSelect()
        {
            var paisList = new List<FamiliarEstudiante>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<FamiliarEstudianteDto>(ObjectMapper.Map<List<FamiliarEstudianteDto>>(paisList));
        }
    }
}
