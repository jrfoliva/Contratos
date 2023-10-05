using Contratos.Entities;
using System.Diagnostics.Contracts;

namespace Contratos.Services
{
    internal class ContratoService
    {
        private IPagamentosOnline _pagamentosOnline;

        public ContratoService(IPagamentosOnline pagamentosOnline)
        {
            _pagamentosOnline = pagamentosOnline;
        }

        public void ProcessarContrato(Contrato contrato, int meses)
        {
            double parcLiquida = contrato.ValorContrato / meses;
            for (int i = 1; i <= meses; i++)
            {
                DateTime date = contrato.DataContrato.AddMonths(i);
                double parcJuros = parcLiquida + _pagamentosOnline.AplicaJuros(parcLiquida, i);
                double parcTotal = parcJuros + _pagamentosOnline.AplicaTaxa(parcJuros);

                contrato.AddParcela(new Parcela(date, parcTotal)); //instanciando uma nova parcela e adicionando a lista
            }
        }
    }
}
