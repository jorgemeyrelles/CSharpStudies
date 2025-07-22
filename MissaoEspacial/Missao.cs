using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MissaoEspacial {
    public class Missao {
        private static List<Missao> _MissaoCriada = new List<Missao>();
        private Utils Utils = new Utils();

        public string Id { get; set; }
        public string NomeMissao { get; set; }
        public DateTime DataLancamento { get; set; }
        public int DiasDuracao { get; set; }
        private List<string> _Relatorio { get; set; }

        public Missao() { }

        public Missao(string nomeMissao, DateTime dataLancamento, int diasDuracao) {
            this.Id = Utils.CriarId();
            this.NomeMissao = nomeMissao;
            this.DataLancamento = dataLancamento;
            this.DiasDuracao = diasDuracao;
            new AgenciaAeroespacial(this);
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
                new Missao(nome, dataLancamento, diasDuracao);
                Console.Clear();
                Console.WriteLine("Informe os dados para cadastrar uma missão:");
                Console.WriteLine($"Nome da missão: {nome}");
                Console.WriteLine($"Data de lançamento: {dataLancamento.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Duração da missão: {diasDuracao} dias");
                Console.WriteLine("---------------------------------");
                // this.SelecionarTripulacao();

                Console.WriteLine("Para continuar cadastrando aperte Enter e para finalizar digite 'sair'");
                continuar = Console.ReadLine();
            } while (continuar.ToLower() != "sair");

            AgenciaAeroespacial agencia = new AgenciaAeroespacial();
            agencia.Operacoes();
        }

        public void SelecionarTripulacao(Missao missao) {
            string continuar = "sim";
            List<string> selecionados = new List<string>();
            Console.WriteLine("Selecione os astronautas para a missão:");
            do {
                for (int i = 0; i < AgenciaAeroespacial.Astronautas.Count; i++) {
                    if (!selecionados.Contains(AgenciaAeroespacial.Astronautas[i].Id)) {
                        Console.WriteLine($"\t# {i + 1}) {AgenciaAeroespacial.Astronautas[i].Nome}");
                    }
                }
                int.TryParse(Console.ReadLine(), out int num);

                selecionados.Add(AgenciaAeroespacial.Astronautas[num - 1].Id);
                AgenciaAeroespacial.Astronautas[num - 1].MissaoId = missao.Id;

                Console.WriteLine("Para continuar seleção de astronauta aperte Enter e para finalizar digite 'sair'");
                continuar = Console.ReadLine();

            } while (continuar != "sair" || selecionados.Count == AgenciaAeroespacial.Astronautas.Count);
        }

        public Missao ExibirMissaoAstronauta(string id) {
            Missao missao = null;
            foreach (Missao mis in AgenciaAeroespacial.Missoes) {
                if (mis.Id == id) {
                    missao = new Missao();
                    missao = mis;
                }
            }
            return missao;
        }

        public void ExibirMissoes() {
            Astronauta astronauta = new Astronauta();
            Console.WriteLine("Exibindo missões:");
            foreach (Missao missao in AgenciaAeroespacial.Missoes) {
                Console.WriteLine();
                Console.WriteLine($"Nome: {missao.NomeMissao}");
                Console.WriteLine($"Data lançamento: {missao.DataLancamento.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Duração: {missao.DiasDuracao} dias");
                astronauta.EditarAstronautaByMissao(missao.Id);
                Console.WriteLine("----------------------------------------------------------");
            }
        }
    }
}
