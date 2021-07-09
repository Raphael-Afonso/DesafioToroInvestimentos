using ContaCorrente_Backend.Context;
using ContaCorrente_Backend.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
