using System.Text.Json.Serialization;

namespace ContaCorrente_Backend.Models
{
    public class ContraParte
    {
        [JsonPropertyName("bank")]
        public string Banco { get; private set; }

        [JsonPropertyName("branch")]
        public string Agencia { get; private set; }

        [JsonPropertyName("account")]
        public string Conta { get; private set; }

        [JsonConstructor]
        public ContraParte(string banco, string agencia, string conta)
        {
            Banco = banco;
            Agencia = agencia;
            Conta = conta;
        }
    }

    public class Parte
    {
        [JsonPropertyName("bank")]
        public string Banco { get; private set; }

        [JsonPropertyName("branch")]
        public string Agencio { get; private set; }

        [JsonPropertyName("cpf")]
        public string CPF { get; private set; }

        [JsonConstructor]
        public Parte(string banco, string agencio, string cPF)
        {
            Banco = banco;
            Agencio = agencio;
            CPF = cPF;
        }
    }

    public class MovimentoRequest
    {
        [JsonPropertyName("event")]
        public string Evento { get; private set; }

        [JsonPropertyName("target")]
        public ContraParte ContraParte { get; private set; }

        [JsonPropertyName("origin")]
        public Parte Parte { get; private set; }

        [JsonPropertyName("amount")]
        public decimal Valor { get; private set; }

        [JsonConstructor]
        public MovimentoRequest(string evento, ContraParte contraParte, Parte parte, decimal valor)
        {
            Evento = evento;
            ContraParte = contraParte;
            Parte = parte;
            Valor = valor;
        }
    }
}
