using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoEspartaLabs.Domain.Shared
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

    }
}
