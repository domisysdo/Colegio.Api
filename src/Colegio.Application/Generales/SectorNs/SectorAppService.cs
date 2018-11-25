using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.SectorNs;
using Colegio.Models.Generales.SectorNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.SectorNs
{
    public class SectorAppService : AsyncCrudAppService<Sector, SectorDto, int, PagedAndSortedResultRequestDto, SectorDto, SectorDto>, ISectorAppService
    {
        public SectorAppService(IRepository<Sector> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<SectorDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Sector>();
            var query = Repository.GetAllIncluding(x => x.Municipio);

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Identificador.StartsWith(filter) || x.Nombre.StartsWith(filter) || x.Municipio.Nombre.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<SectorDto>(query.Count(), ObjectMapper.Map<List<SectorDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<SectorDto>(query.Count(), ObjectMapper.Map<List<SectorDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Sector> ApplySorting(IQueryable<Sector> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<SectorDto> GetAllForSelect()
        {
            var paisList = new List<Sector>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<SectorDto>(ObjectMapper.Map<List<SectorDto>>(paisList));
        }
    }
}
