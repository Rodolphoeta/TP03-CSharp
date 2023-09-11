using System;
using CadastroFaculdade;
using CadastroFaculdade;
using System.Globalization;

namespace CadastroFaculdade.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new FaculdadeRepositorio();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Incluir Faculdade");
                Console.WriteLine("2. Consultar Faculdades");
                Console.WriteLine("3. Sair");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out int escolha))
                {
                    switch (escolha)
                    {
                        case 1:
                            IncluirFaculdade(repository);
                            break;
                        case 2:
                            ConsultarFaculdades(repository);
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
            }
        }

        static void IncluirFaculdade(FaculdadeRepositorio repository)
        {
            Console.WriteLine("Informe os dados da faculdade:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Data de Fundação (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime fundacao))
            {
                Console.Write("Número de Alunos: ");
                if (int.TryParse(Console.ReadLine(), out int alunos))
                {
                    Console.Write("É pública (true/false): ");
                    if (bool.TryParse(Console.ReadLine(), out bool publica))
                    {
                        Console.Write("Avaliação: ");
                        if (double.TryParse(Console.ReadLine(), out double avaliacao))
                        {
                            var faculdade = new Faculdade
                            {
                                Nome = nome,
                                Fundacao = fundacao,
                                Alunos = alunos,
                                Publica = publica,
                                Avaliacao = avaliacao
                            };
                            repository.IncluirFaculdade(faculdade);
                            Console.WriteLine("Faculdade cadastrada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Valor de avaliação inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valor de público inválido.");
                    }
                }
                else
                {
                    Console.WriteLine("Número de alunos inválido.");
                }
            }
            else
            {
                Console.WriteLine("Data de fundação inválida.");
            }
        }

        static void ConsultarFaculdades(FaculdadeRepositorio repository)
        {
            Console.Write("Digite um termo de pesquisa: ");
            string termo = Console.ReadLine();

            var faculdadesEncontradas = repository.ConsultarFaculdades(termo);

            if (faculdadesEncontradas.Count > 0)
            {
                Console.WriteLine("Faculdades encontradas:");
                for (int i = 0; i < faculdadesEncontradas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {faculdadesEncontradas[i].Nome}");
                }

                Console.Write("Digite o número da faculdade para ver os detalhes: ");
                if (int.TryParse(Console.ReadLine(), out int escolha))
                {
                    if (escolha >= 1 && escolha <= faculdadesEncontradas.Count)
                    {
                        var faculdadeSelecionada = faculdadesEncontradas[escolha - 1];
                        Console.WriteLine($"Nome: {faculdadeSelecionada.Nome}");
                        Console.WriteLine($"Data de Fundação: {faculdadeSelecionada.Fundacao:dd-MM-yyyy}");
                        Console.WriteLine($"Número de Alunos: {faculdadeSelecionada.Alunos}");
                        Console.WriteLine($"É pública: {faculdadeSelecionada.Publica}");
                        Console.WriteLine($"Avaliação: {faculdadeSelecionada.Avaliacao}");
                        Console.WriteLine($"Tempo de fundação: {faculdadeSelecionada.CalcularIdade()} anos");
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida.");
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma faculdade encontrada com o termo de pesquisa.");
            }
        }
    }
}
