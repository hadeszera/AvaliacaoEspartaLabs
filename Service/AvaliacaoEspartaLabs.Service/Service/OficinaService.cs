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
