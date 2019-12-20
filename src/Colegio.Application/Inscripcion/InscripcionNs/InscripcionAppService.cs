using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Models.Inscripcion.InscripcionNs;
using Colegio.Models.Inscripcion.CuotaNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Colegio.Inscripcion.CuotaNs;

namespace Colegio.Inscripcion.InscripcionNs
{
    public class InscripcionAppService : AsyncCrudAppService<Models.Inscripcion.InscripcionNs.Inscripcion, InscripcionDto, int, PagedAndSortedResultRequestDto, InscripcionDto, InscripcionDto>, IInscripcionAppService
    {
        ICuotaAppService _cuotaAppService;
        public InscripcionAppService(IRepository<Models.Inscripcion.InscripcionNs.Inscripcion> repository,
                                     ICuotaAppService cuotaAppService)
            : base(repository)
        {
            this._cuotaAppService = cuotaAppService;
        }

        public Task<PagedResultDto<InscripcionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Models.Inscripcion.InscripcionNs.Inscripcion>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Estudiante.Identificador.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<InscripcionDto>(query.Count(), ObjectMapper.Map<List<InscripcionDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<InscripcionDto>(query.Count(), ObjectMapper.Map<List<InscripcionDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Models.Inscripcion.InscripcionNs.Inscripcion> ApplySorting(IQueryable<Models.Inscripcion.InscripcionNs.Inscripcion> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<InscripcionDto> GetAllForSelect()
        {
            var paisList = new List<Models.Inscripcion.InscripcionNs.Inscripcion>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<InscripcionDto>(ObjectMapper.Map<List<InscripcionDto>>(paisList));
        }

        public InscripcionDto GetIncluding(int InscripcionId)
        {
            var inscripcion = new List<Models.Inscripcion.InscripcionNs.Inscripcion>();
            inscripcion = Repository.GetAllIncluding(x => x.Estudiante,
                    x => x.Grupo,
                    x => x.Periodo,
                    x => x.Grupo.Materia)
                .Where(x => x.Id == InscripcionId)
                .ToList();

            return new List<InscripcionDto>(ObjectMapper.Map<List<InscripcionDto>>(inscripcion))
                .FirstOrDefault();
        }

        public override Task<InscripcionDto> Create(InscripcionDto input)
        {
            var cuotas = new List<CuotaDto>();

            var id = Repository.InsertAndGetId(ObjectMapper.Map<Models.Inscripcion.InscripcionNs.Inscripcion>(input));
            
            try
            {

                input = GetIncluding(id);

                DateTime fechaAnterior = input.Periodo.FechaInicio;
                for (DateTime vencimiento = input.Periodo.FechaFin; vencimiento > input.Periodo.FechaInicio; vencimiento = vencimiento.AddMonths(-1))
                {
                    while(vencimiento.Day < input.Periodo.FechaFin.Day && vencimiento.AddDays(1).Month < fechaAnterior.Month)
                    {
                        vencimiento = vencimiento.AddDays(1);
                    }
                    cuotas.Add(new CuotaDto
                    {
                        InscripcionId = id,
                        Estado = Enums.Estado.A,
                        FechaVencimiento = vencimiento,
                    });
                    fechaAnterior = vencimiento;
                }

                foreach(var item in cuotas)
                {
                    item.Monto = input.Grupo.Materia.PrecioTotal / cuotas.Count;
                    item.Balance = item.Monto;
                    item.MontoMoraPago = 0;
                }

                cuotas.OrderBy(x => x.FechaVencimiento);

                foreach (var item in cuotas.OrderBy(x => x.FechaVencimiento))
                {
                    _cuotaAppService.Create(item);
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
