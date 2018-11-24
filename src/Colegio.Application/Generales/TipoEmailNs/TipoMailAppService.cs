using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.TipoEmailNs;
using Colegio.Models.Generales.TipoEmailNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.TipoEmailNs
{
    public class TipoEmailAppService : AsyncCrudAppService<TipoEmail, TipoEmailDto, int, PagedAndSortedResultRequestDto, TipoEmailDto, TipoEmailDto>, ITipoEmailAppService
    {
        public TipoEmailAppService(IRepository<TipoEmail> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<TipoEmailDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var tipoTelefonoList = new List<TipoEmail>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                tipoTelefonoList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<TipoEmailDto>(query.Count(), ObjectMapper.Map<List<TipoEmailDto>>(tipoTelefonoList));
                return Task.FromResult(result);
            }
            else
            {
                tipoTelefonoList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<TipoEmailDto>(query.Count(), ObjectMapper.Map<List<TipoEmailDto>>(tipoTelefonoList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<TipoEmail> ApplySorting(IQueryable<TipoEmail> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<TipoEmailDto> GetAllForSelect()
        {
            var tipoTelefonoList = new List<TipoEmail>();

            var query = Repository.GetAll();
            tipoTelefonoList = query.ToList();

            return new List<TipoEmailDto>(ObjectMapper.Map<List<TipoEmailDto>>(tipoTelefonoList));
        }
    }
}
