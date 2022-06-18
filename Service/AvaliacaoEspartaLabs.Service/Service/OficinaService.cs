using AvaliacaoEspartaLabs.Domain.Entities;
using AvaliacaoEspartaLabs.Domain.Repositorios;
using AvaliacaoEspartaLabs.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoEspartaLabs.Service.Service
{
    public class OficinaService : IOficinaService
    {
        private readonly IOficinaRepositorio _oficinaRepositorio;
        public OficinaService(IOficinaRepositorio oficinaRepositorio)
        {
            _oficinaRepositorio = oficinaRepositorio;
        }

        public async Task AdicionarAgendamento(AddAgendamento agendamento)
        {
            var oficina = await _oficinaRepositorio.BuscarOficinaPorId(agendamento.IdOficina);

            if (oficina.Agendas.Any())
            {
                var agenda = oficina.Agendas.FirstOrDefault(x => x.DataServico.Date == agendamento.DataAgendamento.Date);
                if (agenda != null)
                {
                    await AddComAgendamentoPrevio(agenda, agendamento, oficina);
                }
                else
                {
                    await AddSemAgendamentoPrevio(agendamento, oficina);
                }
            }
            else
            {
                await AddSemAgendamentoPrevio(agendamento, oficina);
            }
        }

        public async Task AddComAgendamentoPrevio(Agenda agenda, AddAgendamento agendamento, Oficina oficina)
        {
            agenda.DataServico = agendamento.DataAgendamento;
            agenda.IdOficina = agendamento.IdOficina;
            agenda.VerificaSePodeAgendar(agendamento.DataAgendamento);
           
            var cargaTrabalho = new CargaTrabalho();
            cargaTrabalho.UnidadeTrabalho = agenda.RetornarCargaServico(agendamento.Servico);
            cargaTrabalho.Servico = agendamento.Servico;
            foreach (var agendaOficina in oficina.Agendas) {
                if (agenda.Id == agendaOficina.Id)
                    agendaOficina.CargasTrabalho.Add(cargaTrabalho);
                    agendaOficina.PermiteAdicionarCargaTrabalhoAgenda(oficina.CargaTrabalhoMaxima);
            }

            _oficinaRepositorio.AtualizarOficina(oficina);
        }


        public async Task AddSemAgendamentoPrevio(AddAgendamento agendamento, Oficina oficina)
        {
            var agenda = new Agenda();
            agenda.DataServico = agendamento.DataAgendamento;
            agenda.IdOficina = agendamento.IdOficina;
            agenda.VerificaSePodeAgendar(agendamento.DataAgendamento);
            var cargaTrabalho = new CargaTrabalho();
            cargaTrabalho.UnidadeTrabalho = agenda.RetornarCargaServico(agendamento.Servico);
            cargaTrabalho.Servico = agendamento.Servico;
            agenda.CargasTrabalho.Add(cargaTrabalho);
            agenda.PermiteAdicionarCargaTrabalhoAgenda(oficina.CargaTrabalhoMaxima);
            oficina.Agendas.Add(agenda);
            AtualizarOficina(oficina);
        }

        public void AtualizarOficina(Oficina oficina)
        {
            try
            {
                _oficinaRepositorio.AtualizarOficina(oficina);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Oficina> AutenticarOficina(string senha, string Cnpj)
        {
            try
            {
                return await _oficinaRepositorio.AutenticarOficina(senha, Cnpj);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void CriarOficina(Oficina oficina)
        {
            try
            {
                _oficinaRepositorio.CriarOficina(oficina);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void ExcluirOficina(int IdOficina)
        {
            try
            {
                _oficinaRepositorio.ExcluirOficina(IdOficina);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
