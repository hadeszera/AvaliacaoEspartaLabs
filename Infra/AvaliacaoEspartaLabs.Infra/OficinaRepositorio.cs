﻿using AvaliacaoEspartaLabs.Domain.Entities;
using AvaliacaoEspartaLabs.Domain.Repositorios;
using AvaliacaoEspartaLabs.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoEspartaLabs.Infra
{
    public class OficinaRepositorio : IOficinaRepositorio
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

        public async Task<Oficina> AutenticarOficina(string Cnpj, string Senha)
        {
            try
            {
                var oficina = await _context.Oficinas.FirstOrDefaultAsync(O => O.CNPJ == Cnpj && O.Senha == Senha);
                if (oficina == null)
                    throw new Exception("Usuário ou senha Incorreto");
                return oficina;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CriarOficina(Oficina oficina)
        {
            try
            {
                var oficinaDb = _context.Oficinas.FirstOrDefault(O=>O.CNPJ == oficina.CNPJ);
                if (oficinaDb != null)
                    throw new Exception($"Oficina {oficina.Nome} com o Cnpj {oficina.CNPJ} já existe no banco");

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
