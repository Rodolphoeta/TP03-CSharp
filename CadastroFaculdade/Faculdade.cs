using System;

namespace CadastroFaculdade
{
    public class Faculdade
    {
        public string Nome { get; set; }
        public DateTime Fundacao { get; set; }
        public int Alunos { get; set; }
        public bool Publica { get; set; }
        public double Avaliacao { get; set; }
        public Guid Id { get; } = Guid.NewGuid();

        public int CalcularIdade()
        {
            return DateTime.Now.Year - Fundacao.Year;
        }
    }
}
