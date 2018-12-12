using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Colegio.Models.Inscripcion.GeneralNs.PeriodoNs;
using System;
using System.Linq;

namespace Colegio.Models.Inscripcion.EstudianteNs
{
    public class EstudianteManager : DomainService, IEstudianteManager
    {
        IRepository<Estudiante> _estudianteRepository;
        IRepository<Periodo> _periodoRepository;
        public EstudianteManager(IRepository<Estudiante> estudianteRepository,
                                 IRepository<Periodo> periodoRepository)
        {
            _estudianteRepository = estudianteRepository;
            _periodoRepository = periodoRepository;
        }
        public string GetSiguienteIdentificador()
        {
            double secuenciaIdentificador = 0;
            string periodoActual = "";

            if (_estudianteRepository.LongCount() > 0)
            {
                secuenciaIdentificador = _estudianteRepository.GetAll()
                                        .ToList()
                                        .Max(x => x.SecuenciaIdentificador);
            }

            if (_periodoRepository.LongCount() > 0)
            {
                periodoActual = _periodoRepository.GetAll()
                                .Where(x => x.FechaInicio >= DateTime.Now)
                                .FirstOrDefault()?.Identificador;
            }

            return periodoActual + "-" + (secuenciaIdentificador + 1).ToString().PadLeft(5, '0');
        }
    }
}
