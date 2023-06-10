namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public interface IDao
    {
        string Salvar(Candidato candidato);
        string Deletar(Candidato candidato);
        string Atualizar(Candidato candidato);
        string Criar(Candidato candidato);
        IEnumerable<Candidato> Consultar(Candidato candidato);
    }
}
