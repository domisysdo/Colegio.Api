using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.EmailFamiliarEstudianteNs;
using Colegio.Models.Generales.EmailFamiliarEstudianteNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.EmailFamiliarEstudianteNs
{
    public class EmailFamiliarEstudianteAppService : AsyncCrudAppService<EmailFamiliarEstudiante, EmailFamiliarEstudianteDto, int, PagedAndSortedResultRequestDto, EmailFamiliarEstudianteDto, EmailFamiliarEstudianteDto>, IEmailFamiliarEstudianteAppService
    {
        public EmailFamiliarEstudianteAppService(IRepository<EmailFamiliarEstudiante> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<EmailFamiliarEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<EmailFamiliarEstudiante>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Email.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<EmailFamiliarEstudianteDto>(query.Count(), ObjectMapper.Map<List<EmailFamiliarEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<EmailFamiliarEstudianteDto>(query.Count(), ObjectMapper.Map<List<EmailFamiliarEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<EmailFamiliarEstudiante> ApplySorting(IQueryable<EmailFamiliarEstudiante> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<EmailFamiliarEstudianteDto> GetAllForSelect()
        {
            var paisList = new List<EmailFamiliarEstudiante>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<EmailFamiliarEstudianteDto>(ObjectMapper.Map<List<EmailFamiliarEstudianteDto>>(paisList));
        }
    }
}
