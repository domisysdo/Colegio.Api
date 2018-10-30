﻿using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Models.Estudiante
{
    public interface IEstudianteManager : IDomainService
    {
        IEnumerable<Estudiante> GetAll();
        Estudiante GetEstudianteById(int estudianteId);
        Task<Estudiante> Create(Estudiante estudiante);
        void Update(Estudiante estudiante);
        void Delete(int estudianteId);
    }
}
