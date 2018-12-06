using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Extensions;
using Colegio.Generales.EmailEstudianteNs;
using Colegio.Models.Generales.EmailEstudianteNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.EmailEstudianteNs
{
    public class EmailEstudianteAppService : ApplicationService //AsyncCrudAppService<EmailEstudiante, EmailEstudianteDto, int, PagedAndSortedResultRequestDto, EmailEstudianteDto, EmailEstudianteDto>, IEmailEstudianteAppService
    {
        IRepository<EmailEstudiante> _emailRepository;
        public EmailEstudianteAppService(IRepository<EmailEstudiante> emailRepository)
        {

        }        
        public void Create(List<EmailEstudiante> emailEstudiantes)
        {
            _emailRepository.GetDbContext().RemoveRange(_emailRepository.GetAll());
            _emailRepository.GetDbContext().AddRange(emailEstudiantes);
        }

        public List<EmailEstudianteDto> GetAllForSelect()
        {
            var paisList = new List<EmailEstudiante>();

            var query = _emailRepository.GetAllIncluding(x => x.TipoEmail);
            paisList = query.ToList();

            return new List<EmailEstudianteDto>(ObjectMapper.Map<List<EmailEstudianteDto>>(paisList));
        }
    }
}
