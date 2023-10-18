using System;
using ExInterface.Entities;

namespace ExInterface.Services
{
    internal class AluguelService
    {
        public double PrecoPorHora { get; private set; }
        public double PrecoPorDia { get; private set; }

        private ITaxService _taxService;

        public AluguelService(double precoPorHora, double precoPorDia, ITaxService taxService)
        {
            PrecoPorHora = precoPorHora;
            PrecoPorDia = precoPorDia;
            _taxService = taxService;
        }

        public void ProcessInvoice(AluguelCarro aluguelCarro)
        {
            TimeSpan duracao = aluguelCarro.Finish.Subtract(aluguelCarro.Start);

            double pagBasico = 0.0;
            if (duracao.TotalHours <= 12.0)
            {
                pagBasico = PrecoPorHora * Math.Ceiling(duracao.TotalHours);
            }
            else
            {
                pagBasico = PrecoPorDia * Math.Ceiling(duracao.TotalDays);
            }

            double tax = _taxService.Tax(pagBasico);

            aluguelCarro.Fatura = new Fatura(pagBasico, tax); 
        }
    }
}
