using ContaCorrente_Backend.Context;
using ContaCorrente_Backend.Models;
using ContaCorrente_Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContaCorrente_Backend.Services
{
    public class ContaCorrenteService
    {
        private readonly ContaCorrenteRepository _repository;
        public ContaCorrenteService(DbContextOptions<SQLContext> options)
        {
            _repository = new(options);
        }

        private ContaCorrente Depositar(MovimentoRequest movimento)
        {
            ContaCorrente ContraParte = _repository.BuscarPorAgenciaEConta(
                movimento.ContraParte.Agencia, movimento.ContraParte.Conta);

            if (ContraParte.Inscricao.Equals(movimento.Parte.CPF))
                _repository.IncrementarSaldo(movimento.Valor, ContraParte);
            else
                throw new ApplicationException("CPF da parte é diferente da contra parte!");

            return ContraParte;
        }
        public ContaCorrente ProcessarMovimento(MovimentoRequest movimento)
        {
            if (movimento.Evento.Equals("TRANSFER"))
                return Depositar(movimento);
            else
                throw new ApplicationException("Evento não reconhecido!");
        }
    }
}
