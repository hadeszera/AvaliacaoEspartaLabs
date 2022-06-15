using AvaliacaoEspartaLabs.Domain.Shared;
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

        public IEnumerable<CargaTrabalho> CargasTrabalho { get; set; }
    }
}
