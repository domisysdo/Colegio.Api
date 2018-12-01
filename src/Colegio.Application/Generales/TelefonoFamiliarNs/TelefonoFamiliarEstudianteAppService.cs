using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.TelefonoFamiliarEstudianteNs;
using Colegio.Models.Generales.TelefonoFamiliarNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.TelefonoFamiliarEstudianteNs
{
    public class TelefonoFamiliarEstudianteAppService : AsyncCrudAppService<TelefonoFamiliarEstudiante, TelefonoFamiliarEstudianteDto, int, PagedAndSortedResultRequestDto, TelefonoFamiliarEstudianteDto, TelefonoFamiliarEstudianteDto>, ITelefonoFamiliarEstudianteAppService
    {
        public TelefonoFamiliarEstudianteAppService(IRepository<TelefonoFamiliarEstudiante> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<TelefonoFamiliarEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<TelefonoFamiliarEstudiante>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Numero.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<TelefonoFamiliarEstudianteDto>(query.Count(), ObjectMapper.Map<List<TelefonoFamiliarEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<TelefonoFamiliarEstudianteDto>(query.Count(), ObjectMapper.Map<List<TelefonoFamiliarEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<TelefonoFamiliarEstudiante> ApplySorting(IQueryable<TelefonoFamiliarEstudiante> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<TelefonoFamiliarEstudianteDto> GetAllForSelect()
        {
            var paisList = new List<TelefonoFamiliarEstudiante>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<TelefonoFamiliarEstudianteDto>(ObjectMapper.Map<List<TelefonoFamiliarEstudianteDto>>(paisList));
        }
    }
}
