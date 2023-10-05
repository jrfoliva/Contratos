namespace Contratos.Services
{
    internal interface IPagamentosOnline
    {
        double AplicaJuros(double montante, int meses);
        double AplicaTaxa(double montante);
    }
}
