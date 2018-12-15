using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Extensions;
using Colegio.Generales.MetodoEvaluacionNs;
using Colegio.Models.Notas.MetodoEvaluacionNs;
using Colegio.Notas.DetalleMetodoEvaluacionNs;
using Colegio.Notas.MetodoEvaluacionNs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.MetodoEvaluacionNs
{
    public class MetodoEvaluacionAppService : AsyncCrudAppService<MetodoEvaluacion, MetodoEvaluacionDto, int, PagedAndSortedResultRequestDto, MetodoEvaluacionDto, MetodoEvaluacionDto>, IMetodoEvaluacionAppService
    {
        IRepository<DetalleMetodoEvaluacion> _detalleMetodoEvaluacionRepository;
        public MetodoEvaluacionAppService(IRepository<MetodoEvaluacion> repository,
                                          IRepository<DetalleMetodoEvaluacion> detalleMetodoEvaluacionRepository
                                          )
            : base(repository)
        {
            _detalleMetodoEvaluacionRepository = detalleMetodoEvaluacionRepository;
        }


        public override Task<MetodoEvaluacionDto> Create(MetodoEvaluacionDto input)
        {
            var result = Repository.InsertOrUpdate(ObjectMapper.Map<MetodoEvaluacion>(input));
            if (input.Id > 0)
            {
                MetodoEvaluacion metodoEvaluacion = Repository.Get(input.Id);
                ModificarDetalleMetodoEvaluacion(ObjectMapper.Map<List<DetalleMetodoEvaluacion>>(input.ListaMetodoEvaluacion), metodoEvaluacion.Id);
                CurrentUnitOfWork.SaveChanges();
            }
            return Task.FromResult(ObjectMapper.Map<MetodoEvaluacionDto>(result));
        }

        public Task<PagedResultDto<MetodoEvaluacionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var MetodoEvaluacionList = new List<MetodoEvaluacion>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                MetodoEvaluacionList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<MetodoEvaluacionDto>(query.Count(), ObjectMapper.Map<List<MetodoEvaluacionDto>>(MetodoEvaluacionList));
                return Task.FromResult(result);
            }
            else
            {

                MetodoEvaluacionList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<MetodoEvaluacionDto>(query.Count(), ObjectMapper.Map<List<MetodoEvaluacionDto>>(MetodoEvaluacionList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<MetodoEvaluacion> ApplySorting(IQueryable<MetodoEvaluacion> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Descripcion asc";
            }
            return base.ApplySorting(query, input);
        }

        public Task<MetodoEvaluacionDto> GetIncluding()
        {
            var metodoEvaluacion = new List<MetodoEvaluacion>();

            metodoEvaluacion = Repository.GetAll()
                               .Include(x => x.ListaMetodoEvaluacion)
                               .ToList();

            var res = new List<MetodoEvaluacionDto>(ObjectMapper.Map<List<MetodoEvaluacionDto>>(metodoEvaluacion))
                          .FirstOrDefault();

            return Task.FromResult(res);

        }

        public List<MetodoEvaluacionDto> GetAllForSelect()
        {
            var MetodoEvaluacionList = new List<MetodoEvaluacion>();

            var query = Repository.GetAll();
            MetodoEvaluacionList = query.ToList();

            return new List<MetodoEvaluacionDto>(ObjectMapper.Map<List<MetodoEvaluacionDto>>(MetodoEvaluacionList));
        }

        public List<DetalleMetodoEvaluacionDto> GetDetalleMetodosEvaluacion(int metodoEvaluacionId)
        {
            var MetodoEvaluacionList = new List<DetalleMetodoEvaluacion>();

            var query = _detalleMetodoEvaluacionRepository.GetAll().Where(x => x.MetodoEvaluacionId == metodoEvaluacionId);
            MetodoEvaluacionList = query.ToList();

            return new List<DetalleMetodoEvaluacionDto>(ObjectMapper.Map<List<DetalleMetodoEvaluacionDto>>(MetodoEvaluacionList));
        }

        public void ModificarDetalleMetodoEvaluacion(List<DetalleMetodoEvaluacion> detalleMetodoEvaluacion, int metodoEvaluacionId)
        {
            detalleMetodoEvaluacion.ToList().ForEach(x => x.MetodoEvaluacionId = metodoEvaluacionId);

            _detalleMetodoEvaluacionRepository.GetDbContext().RemoveRange(_detalleMetodoEvaluacionRepository
                                                                          .GetAll()
                                                                          .Where(x => x.MetodoEvaluacionId == metodoEvaluacionId));

            _detalleMetodoEvaluacionRepository.GetDbContext().AddRange(detalleMetodoEvaluacion.Where(x => x.Id > 0));
        }

    }
}
