using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.TelefonoEstudianteNs;
using Colegio.Models.Generales.TelefonoEstudianteNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.TelefonoEstudianteNs
{
    public class TelefonoEstudianteAppService : AsyncCrudAppService<TelefonoEstudiante, TelefonoEstudianteDto, int, PagedAndSortedResultRequestDto, TelefonoEstudianteDto, TelefonoEstudianteDto>, ITelefonoEstudianteAppService
    {
        public TelefonoEstudianteAppService(IRepository<TelefonoEstudiante> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<TelefonoEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<TelefonoEstudiante>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Numero.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<TelefonoEstudianteDto>(query.Count(), ObjectMapper.Map<List<TelefonoEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<TelefonoEstudianteDto>(query.Count(), ObjectMapper.Map<List<TelefonoEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<TelefonoEstudiante> ApplySorting(IQueryable<TelefonoEstudiante> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<TelefonoEstudianteDto> GetAllForSelect()
        {
            var paisList = new List<TelefonoEstudiante>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<TelefonoEstudianteDto>(ObjectMapper.Map<List<TelefonoEstudianteDto>>(paisList));
        }
    }
}
