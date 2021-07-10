using ContaCorrente_Backend.Context;
using ContaCorrente_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ContaCorrente_Backend.Repositories
{
    public class ContaCorrenteRepository
    {
        private readonly SQLContext _context;
        public ContaCorrenteRepository(DbContextOptions<SQLContext> options)
        {
            _context = new(options);
        }

        public ContaCorrente CriarContaCorrente(ContaCorrente contaCorrente)
        {
            _context.ContaCorrente.Add(contaCorrente);
            _context.SaveChanges();
            return contaCorrente;
        }

        public ContaCorrente BuscarPorAgenciaEConta(string agencia, string conta)
        {
            ContaCorrente ContaCorrente = _context.ContaCorrente
                .Where(c => c.Agencia.Equals(agencia) && c.Conta.Equals(conta))
                .FirstOrDefault();
            if (ContaCorrente is not null)
                return ContaCorrente;
            else
                throw new System.ApplicationException("Conta não localizada!");
        }

        public ContaCorrente IncrementarSaldo(decimal valorAReceber, ContaCorrente contaAReceber)
        {
            contaAReceber.Depositar(valorAReceber);
            _context.SaveChanges();
            return contaAReceber;
        }
    }
}
