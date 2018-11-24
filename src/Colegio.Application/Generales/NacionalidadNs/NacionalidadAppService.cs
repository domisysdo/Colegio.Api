using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.NacionalidadNs;
using Colegio.Models.Generales.NacionalidadNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.NacionalidadNs
{
    public class NacionalidadAppService : AsyncCrudAppService<Nacionalidad, NacionalidadDto, int, PagedAndSortedResultRequestDto, NacionalidadDto, NacionalidadDto>, INacionalidadAppService
    {
        public NacionalidadAppService(IRepository<Nacionalidad> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<NacionalidadDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var tipoDireccionList = new List<Nacionalidad>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                tipoDireccionList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<NacionalidadDto>(query.Count(), ObjectMapper.Map<List<NacionalidadDto>>(tipoDireccionList));
                return Task.FromResult(result);
            }
            else
            {
                tipoDireccionList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<NacionalidadDto>(query.Count(), ObjectMapper.Map<List<NacionalidadDto>>(tipoDireccionList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Nacionalidad> ApplySorting(IQueryable<Nacionalidad> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<NacionalidadDto> GetAllForSelect()
        {
            var tipoDireccionList = new List<Nacionalidad>();

            var query = Repository.GetAll();
            tipoDireccionList = query.ToList();

            return new List<NacionalidadDto>(ObjectMapper.Map<List<NacionalidadDto>>(tipoDireccionList));
        }
    }
}
