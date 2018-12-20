using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Models.Inscripcion.PagoNs;
using Colegio.Models.Inscripcion.CuotaNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Colegio.Inscripcion.CuotaNs;
using Colegio.Inscripcion.PagoDetalleNs;
using Abp.EntityFrameworkCore.Repositories;

namespace Colegio.Inscripcion.PagoNs
{
    public class PagoAppService : AsyncCrudAppService<Pago, PagoDto, int, PagedAndSortedResultRequestDto, PagoDto, PagoDto>, IPagoAppService
    {
        IRepository<Cuota> _cuotaRepository;
        IPagoDetalleAppService _pagoDetalleAppService;
        public PagoAppService(IRepository<Pago> repository,
                                     IRepository<Cuota> cuotaRepository,
                                     IPagoDetalleAppService pagoDetalleAppService)
            : base(repository)
        {
            this._cuotaRepository = cuotaRepository;
            this._pagoDetalleAppService = pagoDetalleAppService;
        }

        public Task<PagedResultDto<PagoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Pago>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Inscripcion.Estudiante.Identificador.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<PagoDto>(query.Count(), ObjectMapper.Map<List<PagoDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<PagoDto>(query.Count(), ObjectMapper.Map<List<PagoDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Pago> ApplySorting(IQueryable<Pago> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<PagoDto> GetAllForSelect()
        {
            var paisList = new List<Pago>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<PagoDto>(ObjectMapper.Map<List<PagoDto>>(paisList));
        }

        public PagoDto GetIncluding(int PagoId)
        {
            var pago = new List<Pago>();
            pago = Repository.GetAllIncluding(x => x.Inscripcion,
                    x => x.Inscripcion.Estudiante,
                    x => x.PagoDetalle
                )
                .Where(x => x.Id == PagoId)
                .ToList();

            return new List<PagoDto>(ObjectMapper.Map<List<PagoDto>>(pago))
                .FirstOrDefault();
        }

        public override Task<PagoDto> Create(PagoDto input)
        {
            var detalles = input.PagoDetalle;
            input.Fecha = DateTime.Now;
            var id = Repository.InsertAndGetId(ObjectMapper.Map<Pago>(input));
            
            try
            {

                input = GetIncluding(id);
                
                foreach(var item in detalles)
                {
                    item.PagoId = id;
                    _pagoDetalleAppService.Create(item);
                    var cuota = _cuotaRepository.Get(item.CuotaId);

                    cuota.Balance -= item.MontoPago;
                    cuota.MontoMoraPago += item.MontoMoraPago;
                    if(cuota.Balance <= 0)
                    {
                        cuota.Estado = Enums.Estado.C;
                    }

                    _cuotaRepository.Update(cuota);
                }
            }
            catch
            {
                throw;
            }

            return Task.FromResult(input);
        }
    }
}
