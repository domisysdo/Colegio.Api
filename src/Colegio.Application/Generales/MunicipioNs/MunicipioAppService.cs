using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.MunicipioNs;
using Colegio.Models.Generales.PaisNs;
using Colegio.Models.Generales.MunicipioNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.MunicipioNs
{
    public class MunicipioAppService : AsyncCrudAppService<Municipio, MunicipioDto, int, PagedAndSortedResultRequestDto, MunicipioDto, MunicipioDto>, IMunicipioAppService
    {
        readonly IRepository<Pais> _paisRepository;
        public MunicipioAppService(IRepository<Municipio> repository, IRepository<Pais> paisRepository)
            : base(repository)
        {
            _paisRepository = paisRepository;
        }

        public Task<PagedResultDto<MunicipioDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Municipio>();
            var query = Repository.GetAllIncluding(x => x.Provincia);

            query = ApplySorting(query, input);

            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Identificador.StartsWith(filter) || x.Nombre.StartsWith(filter) || x.Provincia.Nombre.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<MunicipioDto>(query.Count(), ObjectMapper.Map<List<MunicipioDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<MunicipioDto>(query.Count(), ObjectMapper.Map<List<MunicipioDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }


        protected override IQueryable<Municipio> ApplySorting(IQueryable<Municipio> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<MunicipioDto> GetAllForSelect()
        {
            var paisList = new List<Municipio>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<MunicipioDto>(ObjectMapper.Map<List<MunicipioDto>>(paisList));
        }
    }
}
