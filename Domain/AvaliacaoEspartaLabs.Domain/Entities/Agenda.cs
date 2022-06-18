using AvaliacaoEspartaLabs.Domain.Shared;
using FluentDateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoEspartaLabs.Domain.Entities
{
    public class Agenda : Base
    {
        public DateTime DataServico { get; set; }

        public int CargaTrabalhoAtual { get; set; }

        public Oficina Oficina { get; set; }

        [ForeignKey("IdOficina")]
        public int IdOficina { get; set; }

        public ICollection<CargaTrabalho> CargasTrabalho { get; set; } = new List<CargaTrabalho>();


        public int BuscarQuantidadeCargasAtuais() {
            return CargasTrabalho.Sum(x => x.UnidadeTrabalho);
        }


        public int RetornarCargaServico(Servico servico) {
            switch (servico) 
            {
                case Servico.AlinhamentoRodas:
                    return 1;
                case Servico.Lavacao:
                    return 2;
                case Servico.TrocarOleo:
                    return 3;
                case Servico.RevisaoBasica:
                    return 5;
                case Servico.RevisaoCompleta:
                    return 8;
                default:
                    break;
            }
            throw new Exception("Erro ao buscar serviço");
        }

        public void PermiteAdicionarCargaTrabalhoAgenda(int cargaTrabalhoMaxima) {
            var CargasTrabalhoAtuais = BuscarQuantidadeCargasAtuais();
            if (DataServico.DayOfWeek == DayOfWeek.Friday || DataServico.DayOfWeek == DayOfWeek.Thursday)
            {
                if (CargasTrabalhoAtuais + cargaTrabalhoMaxima <= cargaTrabalhoMaxima + (0.3 * 10))
                    return;
                else
                    throw new Exception("Não é possivel adicionar pois ultrapassou a carga máxima");
            }
            if (CargasTrabalhoAtuais <= cargaTrabalhoMaxima)
                return;

            throw new Exception("Não é possivel adicionar pois ultrapassou a carga máxima");
        }

        public bool VerificaSeDataFimDeSemana(DayOfWeek data) {
            var diaAgendamento = data;
            if (diaAgendamento == DayOfWeek.Saturday || diaAgendamento == DayOfWeek.Sunday)
                return true;
            else
                return false;

        }

        public bool VerificaSePodeAgendar(DateTime data) {
            DayOfWeek diaAgendamento = data.DayOfWeek;
            if (VerificaSeDataFimDeSemana(diaAgendamento))
                throw new Exception("Data de Agendamento não pode ser feita para um fim de semana");

            var dataInicial = DateTime.Now;
            if (data > dataInicial.AddBusinessDays(5).Date) {
                throw new Exception("Data de Agendamento deve ser feita em um periodo de 5 dias a contar da data de hoje");
            }
            if (data < dataInicial) {
                throw new Exception("Data de Agendamento não pode ser feita no passado");
            }

            return true;
        }
    }
}
