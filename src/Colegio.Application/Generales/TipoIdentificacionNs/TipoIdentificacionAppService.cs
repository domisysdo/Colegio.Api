using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.TipoIdentificacionNs;
using Colegio.Models.Generales.TipoIdentificacionNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.TipoIdentificacionNs
{
    public class TipoIdentificacionAppService : AsyncCrudAppService<TipoIdentificacion, TipoIdentificacionDto, int, PagedAndSortedResultRequestDto, TipoIdentificacionDto, TipoIdentificacionDto>, ITipoIdentificacionAppService
    {
        public TipoIdentificacionAppService(IRepository<TipoIdentificacion> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<TipoIdentificacionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var tipoTelefonoList = new List<TipoIdentificacion>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                tipoTelefonoList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<TipoIdentificacionDto>(query.Count(), ObjectMapper.Map<List<TipoIdentificacionDto>>(tipoTelefonoList));
                return Task.FromResult(result);
            }
            else
            {
                tipoTelefonoList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<TipoIdentificacionDto>(query.Count(), ObjectMapper.Map<List<TipoIdentificacionDto>>(tipoTelefonoList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<TipoIdentificacion> ApplySorting(IQueryable<TipoIdentificacion> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<TipoIdentificacionDto> GetAllForSelect()
        {
            var tipoTelefonoList = new List<TipoIdentificacion>();

            var query = Repository.GetAll();
            tipoTelefonoList = query.ToList();

            return new List<TipoIdentificacionDto>(ObjectMapper.Map<List<TipoIdentificacionDto>>(tipoTelefonoList));
        }
    }
}
