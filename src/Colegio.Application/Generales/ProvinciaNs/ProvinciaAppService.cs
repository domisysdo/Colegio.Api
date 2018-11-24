using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.ProvinciaNs;
using Colegio.Models.Generales.PaisNs;
using Colegio.Models.Generales.ProvinciaNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.ProvinciaNs
{
    public class ProvinciaAppService : AsyncCrudAppService<Provincia, ProvinciaDto, int, PagedAndSortedResultRequestDto, ProvinciaDto, ProvinciaDto>, IProvinciaAppService
    {
        readonly IRepository<Pais> _paisRepository;
        public ProvinciaAppService(IRepository<Provincia> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<ProvinciaDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Provincia>();
            var query = Repository.GetAllIncluding(x => x.Pais);

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Identificador.StartsWith(filter) || x.Nombre.StartsWith(filter) || x.Pais.Nombre.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<ProvinciaDto>(query.Count(), ObjectMapper.Map<List<ProvinciaDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<ProvinciaDto>(query.Count(), ObjectMapper.Map<List<ProvinciaDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }


        protected override IQueryable<Provincia> ApplySorting(IQueryable<Provincia> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<ProvinciaDto> GetAllForSelect()
        {
            var provinciaList = new List<Provincia>();

            var query = Repository.GetAll();
            provinciaList = query.ToList();

            return new List<ProvinciaDto>(ObjectMapper.Map<List<ProvinciaDto>>(provinciaList));

        }
    }
}
