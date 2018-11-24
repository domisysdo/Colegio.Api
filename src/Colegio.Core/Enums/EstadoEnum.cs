using System.ComponentModel;

namespace Colegio.Enums
{
    public enum Estado
    {
        [Description("Activo")]
        A,
        [Description("Inactivo")]
        I        
    }
    public enum Sexo
    {
        [Description("Masculino")]
        M,
        [Description("Fenemino")]
        F
    }
    public enum EstadoCivil
    {
        [Description("Soltero")]
        S,
        [Description("Casado")]
        C,
        [Description("Divorciado")]
        D,
        [Description("Viudo")]
        V,
        [Description("Union Libre")]
        U
    }
}
