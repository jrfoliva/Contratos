using System.Globalization;
namespace Contratos.Entities
{
    internal class Parcela
    {
        public DateTime Vencimento { get; set; }
        public double Valor { get; set; }

        public Parcela(DateTime vencimento, double valor)
        {
            Vencimento = vencimento;
            Valor = valor;
        }

        public override string ToString()
        {
            return Vencimento.ToString("dd/MM/yyyy")
                 + " - "
                 + Valor.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
