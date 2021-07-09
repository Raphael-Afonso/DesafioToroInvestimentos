using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaCorrente_Backend.Models
{
    public class ContaCorrente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; private set; }
        public string Titular { get; private set; }
        public string Inscricao { get; private set; }
        public string Agencia { get; private set; }
        public string Conta { get; private set; }
        [Column(TypeName = "decimal(18, 2)")]
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
        public ContaCorrente(string titular, string inscricao, string conta)
        {
            Agencia = "0001";
            Titular = titular;
            Inscricao = inscricao;
            Conta = conta;
        }
    }
}
