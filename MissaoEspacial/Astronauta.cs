using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissaoEspacial {
    public class Astronauta {
        private string[] _Paises = new[] {"EUA", "Canada", "França", "Russia", "Brasil", "Alemanha", "Italia", "China"};
        private Utils Utils = new Utils();
        public string Id { get; private set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string PaisOrigem { get; set; }
        public string MissaoId { get; set; }

        public Astronauta() { }

        public Astronauta(string nome, DateTime dataNascimento) {
            this.Id = Utils.CriarId();
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.PaisOrigem = _Paises[0];
            new AgenciaAeroespacial(this);
        }

        public Astronauta(string nome, DateTime dataNascimento, string paisOrigem) {
            this.Id = Utils.CriarId();
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.PaisOrigem= paisOrigem;
            new AgenciaAeroespacial(this);
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
                for(int i = 0; i < _Paises.Length; i++) {
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

            AgenciaAeroespacial agencia = new AgenciaAeroespacial();
            agencia.Operacoes();
        }

        private string CriarId() {
            Random rand = new Random();
            return rand.Next(100000, 1000000).ToString();
        }

        public void EditarAstronauta() {
            Console.WriteLine("Editar dados cadastrais do Astrounauta: ");
            Astronauta selecionado;
            for (int i = 0; i < AgenciaAeroespacial.Astronautas.Count; i++) {
                Console.WriteLine($"# {i + 1} - {AgenciaAeroespacial.Astronautas[i].Nome}");
            }
            Console.Write("> ");
        }

        public void EditarAstronautaByMissao(string id) {
            Console.WriteLine("Astrounauta na Missão: ");
            Astronauta selecionado;
            for (int i = 0; i < AgenciaAeroespacial.Astronautas.Count; i++) {
                if (AgenciaAeroespacial.Astronautas[i].MissaoId == id) {
                    Console.WriteLine($"# {i + 1} - {AgenciaAeroespacial.Astronautas[i].Nome}");
                }
            }
        }

        public void AustronautasInfo() {
            Console.WriteLine("Astronautas cadastrados:");
            foreach (Astronauta tripulacao in AgenciaAeroespacial.Astronautas) {
                Console.WriteLine("------------------------------");
                Console.WriteLine($"Nome: {tripulacao.Nome}");
                Console.WriteLine($"Nascimento: {tripulacao.DataNascimento.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"País de Origem: {tripulacao.PaisOrigem}");
                Missao missoes = new Missao();
                if (missoes.ExibirMissaoAstronauta(tripulacao.Id) != null) {
                    Console.WriteLine("Missão:");
                    Console.WriteLine($"\tNome: {missoes.ExibirMissaoAstronauta(tripulacao.Id)?.NomeMissao}");
                    Console.WriteLine($"\tData de lançamento: {missoes.ExibirMissaoAstronauta(tripulacao.Id).DataLancamento.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"\tDuração: {missoes.ExibirMissaoAstronauta(tripulacao.Id).DiasDuracao} dias");
                }
                Console.WriteLine("------------------------------");
            }
        }
    }
}
