namespace ContaCorrente_Backend.Models
{
    public class ContaCorrente
    {
        public int ID { get; private set; }
        public string Titular { get; private set; }
        public string Inscricao { get; private set; }
        public string Agencia { get; private set; }
        public string Conta { get; private set; }
        public decimal Saldo { get; private set; }

        public ContaCorrente(int iD, string titular, string inscricao, string agencia, string conta, decimal saldo)
        {
            ID = iD;
            Titular = titular;
            Inscricao = inscricao;
            Agencia = agencia;
            Conta = conta;
            Saldo = saldo;
        }
    }
}
