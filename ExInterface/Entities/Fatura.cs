using System.Globalization;

namespace ExInterface.Entities
{
    internal class Fatura
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Fatura(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double TotalPayment
        {
            get { return BasicPayment + Tax; }
        }

        public override string ToString()
        {
            return "Basic payment: "
               + BasicPayment.ToString("F2", CultureInfo.InvariantCulture)
               + "\nTax: "
               + Tax.ToString("F2", CultureInfo.InvariantCulture)
               + "\nTotal payment: "
               + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
