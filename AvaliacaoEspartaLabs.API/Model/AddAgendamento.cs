using AvaliacaoEspartaLabs.Domain.Entities;
using System;

namespace AvaliacaoEspartaLabs.API.Model
{
    public class AddAgendamento
    {
        public DateTime DataAgendamento { get; set; }

        public Servico Servico { get; set; }
    }
}
