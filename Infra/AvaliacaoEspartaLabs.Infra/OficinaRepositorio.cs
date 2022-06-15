using AvaliacaoEspartaLabs.Domain.Entities;
using AvaliacaoEspartaLabs.Domain.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoEspartaLabs.Infra
{
    internal class OficinaRepositorio : IOficinaRepositorio
    {
        private readonly AppDbContext _context;
        public OficinaRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public void AtualizarOficina(Oficina oficina)
        {
            _context.Entry(oficina).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Task<Oficina> AutenticarOficina(string senha, string Cnpj)
        {
            try
            {
                var oficina = _context.Oficinas.FirstOrDefaultAsync(O => O.CNPJ == Cnpj && O.Senha == O.Senha);
                if (oficina == null)
                    throw new Exception("Oficina não encontrada");
                return oficina;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public void CriarOficina(Oficina oficina)
        {
            try
            {
                var oficinaDb = _context.Oficinas.FirstOrDefault(O=>O.CNPJ == oficina.CNPJ);
                if (oficinaDb != null)
                    throw new Exception("Oficina já existe no banco");

                _context.Add(oficina);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }

        public void ExcluirOficina(int IdOficina)
        {
            try
            {
                var oficina = _context.Oficinas.FirstOrDefault(O => O.Id == IdOficina);
                if (oficina == null)
                    throw new Exception("Id não encontrado");

                _context.Oficinas.Remove(oficina);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }
    }
}
