using System;


namespace CadastroFaculdade.ConsoleApp
{
    public class FaculdadeRepositorio
    {
        public List<Faculdade> faculdades = new List<Faculdade>();

        public void IncluirFaculdade(Faculdade faculdade)
        {
            faculdades.Add(faculdade);
        }

        public List<Faculdade> ConsultarFaculdades(string termo)
        {
            return faculdades
                .Where(f => f.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Faculdade ObterPorId(Guid id)
        {
            return faculdades.FirstOrDefault(f => f.Id == id);
        }
    }
}
