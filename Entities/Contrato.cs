
namespace Contratos.Entities
{
    internal class Contrato
    {
        public int Numero { get; set; }
        public DateTime DataContrato { get; set; }
        public double ValorContrato { get; set; }
        public List<Parcela> Parcelas { get; private set; }

        public Contrato(int numero, DateTime dataContrato, double valorContrato)
        {
            Numero = numero;
            DataContrato = dataContrato;
            ValorContrato = valorContrato;
            Parcelas = new List<Parcela>();
        }

        public void AddParcela(Parcela parcela)
        {
            Parcelas.Add(parcela);
        }
    }
}
