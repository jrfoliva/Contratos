
namespace Contratos.Services
{
    internal class PayPalService : IPagamentosOnline
    {
        private const double Juros = 0.01; // 1%
        private const double Taxa = 0.02; // 2%

        public double AplicaJuros(double montante, int meses)
        {
            return montante * meses * Juros;
        }

        public double AplicaTaxa(double montante)
        {
            return montante * Taxa;
        }
    }
}
