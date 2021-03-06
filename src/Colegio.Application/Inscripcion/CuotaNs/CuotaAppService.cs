﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Models.Inscripcion.CuotaNs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Inscripcion.CuotaNs
{
    public class CuotaAppService : AsyncCrudAppService<Cuota, CuotaDto, int, PagedAndSortedResultRequestDto, CuotaDto, CuotaDto>, ICuotaAppService
    {
        public CuotaAppService(IRepository<Cuota> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<CuotaDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Cuota>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Inscripcion.EstudianteId.Equals(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<CuotaDto>(query.Count(), ObjectMapper.Map<List<CuotaDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<CuotaDto>(query.Count(), ObjectMapper.Map<List<CuotaDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Cuota> ApplySorting(IQueryable<Cuota> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<CuotaDto> GetAllForSelect()
        {
            var paisList = new List<Cuota>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<CuotaDto>(ObjectMapper.Map<List<CuotaDto>>(paisList));
        }

        public List<CuotaDto> GetCuotasPendiente(int estudianteId)
        {
            var cuotas = new List<Cuota>();

            var query = Repository.GetAll()
                .Where(x => x.Estado == Enums.Estado.A)
                .Where(x => x.Inscripcion.EstudianteId == estudianteId);
            cuotas = query.ToList();

            foreach (var item in cuotas)
            {
                item.MontoMora = 0;
                if(item.FechaVencimiento < DateTime.Now)
                {
                    var diasAtraso = DateTime.Now - item.FechaVencimiento;

                    item.MontoMora = Convert.ToDecimal(item.Monto * (Convert.ToDecimal(diasAtraso.Days) / 360) * 0.6M);
                }
            }

            return new List<CuotaDto>(ObjectMapper.Map<List<CuotaDto>>(cuotas));
        }
    }
}
