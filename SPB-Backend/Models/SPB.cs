using System.Text.Json.Serialization;

namespace SPB_Backend.Models
{
    public class Parte
    {
        public string Banco { get; private set; }
        public string Agencia { get; private set; }
        public string CPF { get; private set; }

        [JsonConstructor]
        public Parte(string banco, string agencia, string cPF)
        {
            Banco = banco;
            Agencia = agencia;
            CPF = cPF;
        }
    }
    public class ContraParte
    {
        public string Banco { get; private set; }
        public string Agencia { get; private set; }
        public string Conta { get; private set; }

        [JsonConstructor]
        public ContraParte(string banco, string agencia, string conta)
        {
            Banco = banco;
            Agencia = agencia;
            Conta = conta;
        }
    }
    public class SPB
    {
        public ContraParte ContraParte { get; private set; }
        public Parte Parte { get; private set; }
        public decimal Valor { get; private set; }

        [JsonConstructor]
        public SPB(ContraParte contraParte, Parte parte, decimal valor)
        {
            ContraParte = contraParte;
            Parte = parte;
            Valor = valor;
        }
    }
}
