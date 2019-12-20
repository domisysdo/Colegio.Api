using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Models.Inscripcion.PagoDetalleNs;
using Colegio.Models.Inscripcion.CuotaNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Colegio.Inscripcion.CuotaNs;

namespace Colegio.Inscripcion.PagoDetalleNs
{
    public class PagoDetalleAppService : AsyncCrudAppService<PagoDetalle, PagoDetalleDto, int, PagedAndSortedResultRequestDto, PagoDetalleDto, PagoDetalleDto>, IPagoDetalleAppService
    {
        public PagoDetalleAppService(IRepository<PagoDetalle> repository,
                                     ICuotaAppService cuotaAppService)
            : base(repository)
        {

        }

        public Task<PagedResultDto<PagoDetalleDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<PagoDetalle>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.PagoId.Equals(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<PagoDetalleDto>(query.Count(), ObjectMapper.Map<List<PagoDetalleDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<PagoDetalleDto>(query.Count(), ObjectMapper.Map<List<PagoDetalleDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<PagoDetalle> ApplySorting(IQueryable<PagoDetalle> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<PagoDetalleDto> GetAllForSelect()
        {
            var paisList = new List<PagoDetalle>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<PagoDetalleDto>(ObjectMapper.Map<List<PagoDetalleDto>>(paisList));
        }

        public PagoDetalleDto GetIncluding(int PagoDetalleId)
        {
            var pago = new List<PagoDetalle>();
            pago = Repository.GetAllIncluding(x => x.Pago,
                    x => x.Cuota,
                    x => x.Cuota.Inscripcion
                )
                .Where(x => x.Id == PagoDetalleId)
                .ToList();

            return new List<PagoDetalleDto>(ObjectMapper.Map<List<PagoDetalleDto>>(pago))
                .FirstOrDefault();
        }

    }
}
