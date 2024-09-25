using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Configuração inicial:");
                  
//precoInicial = Convert.ToDecimal(Console.ReadLine());
while (true)
{
    Console.Write("Digite o preço inicial (use vírgula como separador decimal): ");
    string entrada = Console.ReadLine();

    if (decimal.TryParse(entrada, out precoInicial))
    {
        // A conversão foi bem-sucedida, você pode usar o valor de precoInicial
        Console.WriteLine("O preço inicial é: " + precoInicial);
        break; // Sai do loop
    }
    else
    {
        Console.WriteLine("Entrada inválida. Por favor, digite um número decimal.");
    }
}

//Console.WriteLine("Agora digite o preço por hora:");
//precoPorHora = Convert.ToDecimal(Console.ReadLine());
while (true)
{
    Console.Write("Agora digite o preço por hora (use vírgula como separador decimal): ");
    string entrada = Console.ReadLine();

    if (decimal.TryParse(entrada, out precoPorHora))
    {
        // A conversão foi bem-sucedida, você pode usar o valor de precoPorHora
        Console.WriteLine("O preço inicial é: " + precoPorHora);
        break; // Sai do loop
    }
    else
    {
        Console.WriteLine("Entrada inválida. Por favor, digite um número decimal.");
    }
}

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos estacionados");
    Console.WriteLine("4 - Listar veículos removidos");
    Console.WriteLine("5 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            es.ListarRemovidos();
            break;

        //Implementação nova 
        case "5":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
