using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 5;
        private decimal precoPorHora = 5;
        private List<string> veiculos = new List<string>();
        private string padraoPlaca = @"^[A-Z]{3}[0-9][A-Z][0-9]{2}$";  

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Contains(placa))
            {
                Console.WriteLine($"Erro: Placa {placa} já cadastrada.");
            }
            else if (!Regex.IsMatch(placa, padraoPlaca, RegexOptions.IgnoreCase))
            {
                Console.WriteLine($"Erro: Placa {placa} inválida, coloque no formato Mercosul 'ABC1D23'.");
            }
            else
            {
                veiculos.Add(placa);
                Console.WriteLine($"Placa {placa} cadastrada com sucesso.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 0)
                {
                    Console.WriteLine("Inválido. Digite apenas números positivos.");
                    return;
                }

                decimal valorTotal = precoInicial + (precoPorHora * horas);
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}