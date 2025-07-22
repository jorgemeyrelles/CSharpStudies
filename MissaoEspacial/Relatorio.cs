using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissaoEspacial {
    public class Relatorio {
        private Utils Utils = new Utils();
        public string Id {  get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }
        public string MissaoId { get; set; }
        public string AstronautaId { get; set; }

        public Relatorio(string mensagem, DateTime data, string missaoId, string astronautaId) {
            this.Mensagem = mensagem;
            this.Data = data;
            this.MissaoId = missaoId;
            this.AstronautaId = astronautaId;
            this.Id = Utils.CriarId();
            AgenciaAeroespacial._Relatorios.Add(this);
        }

        public void ExibirRelatorioByMissao(string id) {
            Console.WriteLine("Relatório da Missão:");
            Console.WriteLine();
            for (int i = 0; i < AgenciaAeroespacial.Relatorios.Count; i++) {
                if (AgenciaAeroespacial.Relatorios[i].MissaoId == id) {
                    Console.WriteLine($"- {AgenciaAeroespacial.Relatorios[i].Data.ToString("dd/MM/yyyy")} : {AgenciaAeroespacial.Relatorios[i].Mensagem}");
                }
            }
            Console.WriteLine("------------------------------------");
        }

        public void RelatorioMissao() {
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
            if (!int.TryParse(Console.ReadLine(), out int trip)) {
                this.RelatorioMissao();
            };

            string astronautaId = AgenciaAeroespacial.Astronautas[trip == 0 ? 0 : trip - 1].Id;
            do {
                Console.WriteLine("Digite a Data do relatório: ");
                Console.WriteLine("Dia: ");
                int.TryParse(Console.ReadLine(), out int dia);
                Console.Clear();
                Console.WriteLine("Digite a Data do relatório: ");
                Console.Write($"Mês: {dia}/");
                int.TryParse(Console.ReadLine(), out int mes);
                Console.Clear();
                Console.WriteLine("Digite a Data do relatório: ");
                Console.Write($"Ano: {dia}/{mes}/");
                int.TryParse(Console.ReadLine(), out int ano);
                Console.Clear();
                DateTime.TryParse($"{dia}/{mes}/{ano}", out DateTime lancamento);
                Console.Write($"Data: {dia}/{mes}/{ano}");
                Console.WriteLine("Registre seu relatório:");
                Console.WriteLine("Obs: Para salva, aperte Enter");
                string mensagem = Console.ReadLine();
                new Relatorio(mensagem, lancamento, missaoId, astronautaId);


            } while (continuar != "sair");
        }
    }
}
