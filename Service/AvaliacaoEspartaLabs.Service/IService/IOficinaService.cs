using AvaliacaoEspartaLabs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoEspartaLabs.Service.IService
{
    public interface IOficinaService
    {
        public void CriarOficina(Oficina oficina);

        public void ExcluirOficina(int IdOficina);

        public void AtualizarOficina(Oficina oficina);

        public Task<Oficina> AutenticarOficina(string senha, string Cnpj);

        public Task AdicionarAgendamento(AddAgendamento agendamento); 
    }
}
