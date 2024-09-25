using System.Globalization;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        // Preços definidos (ajuste conforme necessário)
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        private List<string> removidos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
          
            while (true)
            {
                Console.Write("Digite a placa do veículo para estacionar (ou 'sair' para encerrar): ");
                string placa = Console.ReadLine();

                if (placa.ToLower() == "sair")
                    break;

                // Expressões regulares para validar os padrões de placa
                string pattern1 = @"^[A-Z]{3}\d{4}$"; // Valida placas no formato XXX9999.
                string pattern2 = @"^[A-Z]{3}\d[A-Z]\d{2}$"; // Valida placas no formato XXX9X99.

                if (Regex.IsMatch(placa, pattern1) || Regex.IsMatch(placa, pattern2))
                {
                    string horaEntrada = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    veiculos.Add($"{placa}; {horaEntrada}");
                    Console.WriteLine("Placa válida! Adicionada à lista.");
                }
                else
                {
                    Console.WriteLine("Placa inválida. Por favor, verifique o formato.");
                }
            }
        }

        public void RemoverVeiculo()
        {
            
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            
            while (true)
            {            
                Console.Write("Digite a placa do veículo (ou 'sair' para encerrar): ");
                string placa = Console.ReadLine();

                if (placa.ToLower() == "sair")
                {
                    break;
                }
                
                // Validação da placa
                if (Regex.IsMatch(placa, @"^[A-Z]{3}\d{4}$") || Regex.IsMatch(placa, @"^[A-Z]{3}\d[A-Z]\d{2}$"))
                {

                    // Verifica se o veículo está estacionado
                    string v = veiculos.FirstOrDefault(x => x.Split(';')[0].ToUpper() == placa.ToUpper());
                    var veiculo = v;
                    if (veiculo != null)
                    {
                        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                        // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                        // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                        int horas = 0;
                        decimal valorTotal = 0; 
                        decimal valorTotalCalc = 0;
                        
                        // TODO: Remover a placa digitada da lista de veículos

                        if (int.TryParse(Console.ReadLine(), out horas))
                        {

                            // Obtém o índice do registro de veículos para obter a data de entrada e em seguida remover o registro 
                            int indice = veiculos.IndexOf(veiculo);
                            string registoVeiculo = veiculos.ElementAtOrDefault(indice);
                            string horaEntrada = registoVeiculo.Split(';')[1];

                            // Cálculo do valor total com horas informadas
                            valorTotal = precoInicial + precoPorHora * horas;
                            string horaSaida = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                            // Cálculo do valor total com horas calculadas
                            // Convertendo as strings para DateTime
                            DateTime horaEntradaDt = DateTime.ParseExact(horaEntrada.Trim(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            DateTime horaSaidaDt = DateTime.ParseExact(horaSaida.Trim(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                            // Calculando a diferença
                            TimeSpan diferenca = horaSaidaDt - horaEntradaDt;

                            // Obtendo a diferença em horas (arredondando para cima)
                            int horasCalc = (int)Math.Ceiling(diferenca.TotalHours);
                            Console.WriteLine($"A diferença em horas é: {horasCalc}");
                            valorTotalCalc = precoInicial + precoPorHora * horasCalc;


                            // Adiciona em lista de veículos removidos
                            removidos.Add($"{placa}; {horas} horas informadas; R$ {valorTotal:F2} total informado; {horasCalc} horas calculadas; {valorTotalCalc} total calculado; {horaEntrada} entrada; {horaSaida} saída");
                            Console.WriteLine("Registro adicionado na lista de Removidos com sucesso!");

                            // Remove o veículo da lista
                            veiculos.RemoveAt(indice);
                            Console.WriteLine($"O veículo {placa} foi removido. @\n O preço total INFORMADO foi de: R$ {valorTotal} \n O preço total CALCULADO foi de: R$ {valorTotalCalc}. \n Preço Incial: {precoInicial} \n Preço Por Hora: {precoPorHora}");
                            
                            
                        }
                        else
                        {
                            Console.WriteLine("Quantidade de horas inválida. Por favor, digite um número.");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                    }
                }
                else
                {
                    Console.WriteLine("Placa inválida. Por favor, verifique o formato.");
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // Exibir as placas válidas e suas respectivas datas de inclusão
                foreach (string entrada in veiculos)
                {
                    Console.WriteLine(entrada);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        //Implementação Nova
         public void ListarRemovidos()
        {
            // Verifica se há veículos removidos
            if (removidos.Any())
            {
                Console.WriteLine("Os veículos removidos são:");
                // Exibir veículos removidos e respectivas informações
                foreach (string saida in removidos)
                {
                    Console.WriteLine(saida);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos removidos.");
            }
        }
    }
}
