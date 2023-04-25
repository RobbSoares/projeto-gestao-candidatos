using System.ComponentModel;
using System.Reflection;

namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public enum TipoTelefone
    {
        [Description("Residencial")]
        Residencial,
        [Description("Celular")]
        Celular,
        [Description("Contato")]
        Contato
    }
}
