﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Extensions;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Extensions;
using Abp.UI;
using Colegio.Generales.EmailEstudianteNs;
using Colegio.Models.Generales.EmailEstudianteNs;
using Colegio.Models.Inscripcion.EstudianteNs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Inscripcion.EstudianteNs
{
    public class EstudianteAppService : AsyncCrudAppService<Estudiante, EstudianteDto, int, PagedAndSortedResultRequestDto, EstudianteDto, EstudianteDto>, IEstudianteAppService
    {
        IRepository<EmailEstudiante> _emailRepository;
        public EstudianteAppService(IRepository<Estudiante> repository, IRepository<EmailEstudiante> emailReposiroty)
            : base(repository)
        {
            _emailRepository = emailReposiroty;
        }

        public override Task<EstudianteDto> Create(EstudianteDto input)
        {
            if (input.Id > 0)
            {
                Estudiante estudiante = Repository.GetAll().Where(x => x.Id == input.Id).Include(x => x.ListaEmail).FirstOrDefault();

                if (estudiante != null)
                {
                    if (estudiante.ListaEmail == null)
                    {
                        estudiante.ListaEmail = new List<EmailEstudiante>();
                    }
                    if (estudiante.ListaEmail.Count() > 0)
                    {
                        for (int i = 0; i < estudiante.ListaEmail.Count(); i++)
                        {
                            var emailEstudiante = estudiante.ListaEmail[i];
                            var item = input.ListaEmail.FirstOrDefault(x => x.Id == emailEstudiante.Id);

                            if (item == null)
                            {
                                estudiante.ListaEmail.Remove(emailEstudiante);
                            }
                            else
                            {
                                emailEstudiante.Email = item.Email;
                                emailEstudiante.TipoEmailId = item.TipoEmailId;
                            }
                        }
                        if (input.ListaEmail != null)
                        {
                            foreach (EmailEstudianteDto emailEstudianteDto in input.ListaEmail.Where(x => x.Id == 0))
                            {
                                var emailEstudiante = ObjectMapper.Map<EmailEstudiante>(emailEstudianteDto);
                                estudiante.ListaEmail.Add(emailEstudiante);
                            }
                        }
                    }
                    Repository.DetachFromDbContext(estudiante);
                }
                else
                {
                    throw new UserFriendlyException("No se pudo buscar el estudiante");
                }
            }

            var result = Repository.InsertOrUpdate(ObjectMapper.Map<Estudiante>(input));
            return Task.FromResult(ObjectMapper.Map<EstudianteDto>(result));
        }

        public Task<PagedResultDto<EstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Estudiante>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Nombres.StartsWith(filter) || x.PrimerApellido.StartsWith(filter)
                                                             || x.SegundoApellido.StartsWith(filter)
                                                             || x.Identificador.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<EstudianteDto>(query.Count(), ObjectMapper.Map<List<EstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<EstudianteDto>(query.Count(), ObjectMapper.Map<List<EstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Estudiante> ApplySorting(IQueryable<Estudiante> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<EstudianteDto> GetAllForSelect()
        {
            var paisList = new List<Estudiante>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<EstudianteDto>(ObjectMapper.Map<List<EstudianteDto>>(paisList));
        }

        public Task<EstudianteDto> GetIncluding(int estudianteId)
        {
            var estudiante = new List<Estudiante>();

            estudiante = Repository.GetAll()
                    .Include(x => x.ListaDireccionEstudiante)
                    .Include(x => x.ListaTelefonos)
                        .ThenInclude(x => x.TipoTelefono)
                    .Include(x => x.ListaFamiliarEstudiante)
                    .Include(x => x.ListaEmail)
                        .ThenInclude(x => x.TipoEmail)

            .Where(x => x.Id == estudianteId)
            .ToList();


            var res = new List<EstudianteDto>(ObjectMapper.Map<List<EstudianteDto>>(estudiante))
                       .FirstOrDefault();

            return Task.FromResult(res);
        }

    }
}
