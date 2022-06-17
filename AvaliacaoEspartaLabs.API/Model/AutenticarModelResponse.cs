using AvaliacaoEspartaLabs.Application.DTO;

namespace AvaliacaoEspartaLabs.API.Model
{
    public class AutenticarModelResponse
    {
        public string Token { get; set; }

        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public int IdOficina { get; set; }

    }
}
