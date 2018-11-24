using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.TipoTelefonoNs;
using Colegio.Models.Generales.TipoTelefonoNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.TipoTelefonoNs
{
    public class TipoTelefonoAppService : AsyncCrudAppService<TipoTelefono, TipoTelefonoDto, int, PagedAndSortedResultRequestDto, TipoTelefonoDto, TipoTelefonoDto>, ITipoTelefonoAppService
    {
        public TipoTelefonoAppService(IRepository<TipoTelefono> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<TipoTelefonoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var tipoTelefonoList = new List<TipoTelefono>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                tipoTelefonoList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<TipoTelefonoDto>(query.Count(), ObjectMapper.Map<List<TipoTelefonoDto>>(tipoTelefonoList));
                return Task.FromResult(result);
            }
            else
            {
                tipoTelefonoList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<TipoTelefonoDto>(query.Count(), ObjectMapper.Map<List<TipoTelefonoDto>>(tipoTelefonoList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<TipoTelefono> ApplySorting(IQueryable<TipoTelefono> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<TipoTelefonoDto> GetAllForSelect()
        {
            var tipoTelefonoList = new List<TipoTelefono>();

            var query = Repository.GetAll();
            tipoTelefonoList = query.ToList();

            return new List<TipoTelefonoDto>(ObjectMapper.Map<List<TipoTelefonoDto>>(tipoTelefonoList));
        }
    }
}
