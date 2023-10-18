using System;
using System.Globalization;
using ExInterface.Entities;
using ExInterface.Services;

namespace ExInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os dados do aluguel: ");
            Console.Write("Modelo do carro: ");
            string model = Console.ReadLine();
            Console.Write("Retirada (dd/MM/yyyy hh:ss):");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Retorno (dd/MM/yyyy hh:ss):");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Coloque o preço por hora: ");
            double hora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            Console.Write("Coloque o preço por dia: ");
            double dia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            AluguelCarro aluguelCarro = new AluguelCarro(start, finish, new Veiculo(model));

            AluguelService aluguelService = new AluguelService(hora, dia, new TaxasBrasilService());
            aluguelService.ProcessInvoice(aluguelCarro);


            Console.WriteLine("Fatura: ");
            Console.WriteLine(aluguelCarro.Fatura);

        }
    }
}