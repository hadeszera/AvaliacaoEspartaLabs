using AvaliacaoEspartaLabs.Domain.Entities;
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

        public async Task<Agenda> BuscarAgendamentoDia(int idOficina)
        {
            return await _context.Agendas.Include(x => x.CargasTrabalho).FirstOrDefaultAsync(x => x.IdOficina == idOficina && x.DataServico.Date == DateTime.Now.Date);
        }

        public async Task<Agenda> BuscarAgendamentoDiaEspecifico(int idOficina, DateTime data)
        {
             return await _context.Agendas.Include(x => x.CargasTrabalho).FirstOrDefaultAsync(x => x.IdOficina == idOficina && x.DataServico.Date == data);
        }

        public async Task<Oficina> BuscarOficinaPorId(int idOficina)
        {
            try
            {
                var oficina = await _context.Oficinas.Include(x=>x.Agendas).ThenInclude(x=>x.CargasTrabalho).FirstOrDefaultAsync(x=>x.Id == idOficina);
                if (oficina == null)
                    throw new Exception("Erro ao buscar a Oficina");

                return oficina;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<Agenda>> BuscarProximosAgendamentos(DateTime dataAgendamentoProximosDias, int idOficina)
        {
            var result = await _context.Agendas.Include(x=>x.CargasTrabalho).
                Where(x => x.IdOficina == idOficina 
                && x.DataServico.Date > DateTime.Now.Date 
                && x.DataServico <= dataAgendamentoProximosDias.Date).
                ToListAsync();
            return result;
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
