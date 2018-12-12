using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colegio.Models.Notas.MetodoEvaluacionNs
{
    public class MetodoEvaluacion: AuditedEntity<int>
    {
        public string Descripcion { get; set; }
        public List<DetalleMetodoEvaluacion> ListaMetodoEvaluacion { get; set; }
    }
}
