﻿namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public class Endereco : Entidade
    {
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public int Numero { get; set; }
        public Cidade Cidade { get; set; }
    }
}
