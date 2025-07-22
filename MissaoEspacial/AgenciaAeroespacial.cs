using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissaoEspacial {
    internal class AgenciaAeroespacial {
        private string[] _Paises = new[] { "EUA", "Canada", "França", "Russia", "Brasil", "Alemanha", "Italia", "China" };

        public static List<Astronauta> _Astronautas = new List<Astronauta>();
        public static List<Missao> _Missoes = new List<Missao>();
        public static List<Relatorio> _Relatorios = new List<Relatorio>();


        public static List<Missao> Missoes { get => _Missoes; set { _Missoes = value; } }
        public static List<Astronauta> Astronautas { get => _Astronautas; set { _Astronautas = value; } }
        public static List<Relatorio> Relatorios { get => _Relatorios; set { _Relatorios = value; } }

        public AgenciaAeroespacial() { }

        public AgenciaAeroespacial(Missao missao) {
            _Missoes.Add(missao);
        }

        public AgenciaAeroespacial(Astronauta astronauta) {
            _Astronautas.Add(astronauta);
        }

        public AgenciaAeroespacial(Relatorio relatorio) {
            _Relatorios.Add(relatorio);
        }

        public void Operacoes() {
            Console.Clear();
            string continuar = "sim";
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1) Cadastrar Astronauta");
            Console.WriteLine("2) Cadastrar Missões");
            Console.WriteLine("3) Exibir Missões");
            Console.WriteLine("4) Exibir Astronautas");
            Console.WriteLine("5) Registrar relatório a missão");
            Console.WriteLine("---------------------------------");
            int.TryParse(Console.ReadLine(), out int opcao);
            switch (opcao) {
                case 1:
                    Console.Clear();
                    this.CadastrarTripulação();
                    break;
                case 2:
                    Console.Clear();
                    this.CadastrarMissao();
                    break;
                case 3:
                    Console.Clear();
                    Missao missao = new Missao();
                    missao.ExibirMissoes();
                    Console.WriteLine("Voltar para o menu aperte Enter, para sair digite 'sair'");
                    continuar = Console.ReadLine();
                    if (continuar != "sair") this.Operacoes();
                    break;
                case 4:
                    Console.Clear();
                    Astronauta astronauta = new Astronauta();
                    astronauta.AustronautasInfo();
                    Console.WriteLine("Voltar para o menu aperte Enter, para sair digite 'sair'");
                    continuar = Console.ReadLine();
                    if (continuar != "sair") this.Operacoes();
                    break;
                case 5:
                    Console.Clear();
                    this.CriarRelatorioMissao();
                    Console.WriteLine("Voltar para o menu aperte Enter, para sair digite 'sair'");
                    break;
                default:
                    Console.WriteLine("Opção invalida");
                    this.Operacoes();
                    break;
            }
        }

        public void CadastrarTripulação() {
            string continuar = "sim";
            int j = 0;
            do {
                string titulo = j == 0 ? "Vamos cadastrar" : "Vamos continuar cadastrando";
                Console.WriteLine($"{titulo} os astronautas para missão");
                Console.Write("Digite o nome: ");
                string nome = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"{titulo} os astronautas para missão");
                Console.WriteLine("Digite o data de nascimento (dia - dd): ");
                int.TryParse(Console.ReadLine(), out int dia);
                Console.Clear();
                Console.WriteLine($"{titulo} os astronautas para missão");
                Console.WriteLine("Digite o data de nascimento (mês - mm): ");
                Console.Write($"{dia}/");
                int.TryParse(Console.ReadLine(), out int mes);
                Console.Clear();
                Console.WriteLine($"{titulo} os astronautas para missão");
                Console.WriteLine("Digite o data de nascimento (ano - aaaa): ");
                Console.Write($"{dia}/{mes}/");
                int.TryParse(Console.ReadLine(), out int ano);
                Console.Write($"{dia}/{mes}/{ano}");
                DateTime.TryParse($"{dia}/{mes}/{ano}", out DateTime nascimento);
                Console.Clear();
                Console.WriteLine($"{titulo} os astronautas para missão");
                Console.WriteLine("Selecione o país de origem: ");
                for (int i = 0; i < _Paises.Length; i++) {
                    Console.WriteLine($"\t# {i + 1}) {_Paises[i]}");
                }
                Console.Write("> ");
                int.TryParse(Console.ReadLine(), out int pais);
                string paisOrigem = _Paises[pais == 0 ? 0 : pais - 1];

                new Astronauta(nome, nascimento, paisOrigem);
                Console.WriteLine("------------------------------");
                Console.WriteLine("Para continuar cadastrando aperte Enter, para finalizar digite sair:");
                Console.Write("> ");
                continuar = Console.ReadLine();
                Console.WriteLine("------------------------------");
                j++;
            } while (continuar.ToLower() != "sair");

            this.Operacoes();
        }

        public void CadastrarMissao() {
            string nome;
            DateTime dataLancamento;
            int diasDuracao;
            string continuar = "sim";
            do {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Informe os dados para cadastrar uma missão:");
                Console.Write("Nome da missão: ");
                nome = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Informe os dados para cadastrar uma missão:");
                Console.WriteLine($"Nome da missão: {nome}");
                Console.Write("Data de lançamento (dia): ");
                int.TryParse(Console.ReadLine(), out int dia);
                Console.Clear();
                Console.WriteLine("Informe os dados para cadastrar uma missão:");
                Console.WriteLine($"Nome da missão: {nome}");
                Console.Write($"Data de lançamento (mês): {dia}/");
                int.TryParse(Console.ReadLine(), out int mes);
                Console.Clear();
                Console.WriteLine("Informe os dados para cadastrar uma missão:");
                Console.WriteLine($"Nome da missão: {nome}");
                Console.Write($"Data de lançamento (ano): {dia}/{mes}/");
                int.TryParse(Console.ReadLine(), out int ano);
                DateTime.TryParse($"{dia}/{mes}/{ano}", out DateTime lancamento);
                dataLancamento = lancamento;
                Console.Clear();
                Console.WriteLine("Informe os dados para cadastrar uma missão:");
                Console.WriteLine($"Nome da missão: {nome}");
                Console.WriteLine($"Data de lançamento: {dataLancamento.ToString("dd/MM/yyyy")}");
                Console.Write("Duração da missão: ");
                int.TryParse(Console.ReadLine(), out int duracao);
                diasDuracao = duracao;
                Missao missao = new Missao(nome, dataLancamento, diasDuracao);
                Console.Clear();
                Console.WriteLine("Informe os dados para cadastrar uma missão:");
                Console.WriteLine($"Nome da missão: {nome}");
                Console.WriteLine($"Data de lançamento: {dataLancamento.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Duração da missão: {diasDuracao} dias");
                Console.WriteLine("---------------------------------");
                missao.SelecionarTripulacao(missao);

                Console.WriteLine("Para continuar cadastrando aperte Enter e para finalizar digite 'sair'");
                continuar = Console.ReadLine();
            } while (continuar.ToLower() != "sair");

            this.Operacoes();
        }

        public void CriarRelatorioMissao() {
            string continuar = "sim";
            Console.Clear();
            Console.WriteLine("Selecione a missão:");
            for (int i = 0; i < AgenciaAeroespacial.Missoes.Count; i++) {
                Console.WriteLine($"{i + 1}) {AgenciaAeroespacial.Missoes[i].NomeMissao}");
            }
            int.TryParse(Console.ReadLine(), out int selecao);
            string missaoId = AgenciaAeroespacial.Missoes[selecao == 0 ? 0 : selecao - 1].Id;
            Console.WriteLine("Autor da mensagem:");
            for (int i = 0; i < AgenciaAeroespacial.Astronautas.Count; i++) {
                if (AgenciaAeroespacial.Astronautas[i].MissaoId == missaoId) {
                    Console.WriteLine($"{i + 1}) {AgenciaAeroespacial.Astronautas[i].Nome}");
                }
            }
            int.TryParse(Console.ReadLine(), out int trip);

            string astronautaId = AgenciaAeroespacial.Astronautas[trip == 0 ? 0 : trip - 1].Id;
            do {

                Console.WriteLine("Dia: ");
                Console.WriteLine("Dia: ");
                int.TryParse(Console.ReadLine(), out int dia);
                Console.Clear();
                Console.Write($"Mês: {dia}/");
                int.TryParse(Console.ReadLine(), out int mes);
                Console.Clear();
                Console.Write($"Ano: {dia}/{mes}/");
                int.TryParse(Console.ReadLine(), out int ano);
                Console.Clear();
                DateTime.TryParse($"{dia}/{mes}/{ano}", out DateTime lancamento);
                Console.Write($"Data: {dia}/{mes}/{ano}");
                Console.WriteLine("Registre seu relatório:");
                Console.WriteLine("Obs: Para salva, aperte Enter");
                string mensagem = Console.ReadLine();
                new Relatorio(mensagem, lancamento, missaoId, astronautaId);
                Console.WriteLine("Para continuar cadastrando aperte Enter e para finalizar digite 'sair'");
                continuar = Console.ReadLine();

            } while (continuar != "sair");
            this.Operacoes();
        }
    }
}
