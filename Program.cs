using Contratos.Entities;
using Contratos.Services;
using System.Globalization;
namespace Contratos
{
    internal class Program
    {
        /*
           Uma empresa deseja automatizar o processamento de seus contratos. O processamento de
           UM CONTRATO CONSISTE EM GERAR AS PARCELAS A SEREM PAGAS PARA AQUELE CONTRATO, COM BASE NO
           NÚMERO DE MESES DESEJADO.
           A EMPRESA UTILIZA UM SERVIÇO DE PAGAMENTO ONLINE PARA REALIZAR O PAGAMENTO DAS PARCELAS.
           OS SERVIÇOS DE PAGAMENTO ONLINE TIPICAMENTE COBRAM UM JURO MENSAL, BEM COMO UMA TAXA
           POR PAGAMENTO. POR ENQUANTO, O SERVIÇO CONTRATADO PELA EMPRESA É O DO PAYPAL, QUE APLICA
           JUROS SIMPLES DE 1% A CADA PARCELA, MAIS UMA TAXA DE PAGAMENTO DE 2%.
           FAZER UM PROGRAMA PARA LER OS DADOS DE UM CONTRATO (NÚMERO DO CONTRATO, DATA DO CONTRATO,
           E VALOR TOTAL DO CONTRATO). EM SEGUIDA, O PROGRAMA DEVE LER O NÚMERO DE MESES PARA
           PARCELAMENTO DO CONTRATO, E DAÍ GERAR OS REGISTROS DE PARCELAS A SEREM PAGAS (DATA E VALOR),
           SENDO A PRIMEIRA PARCELA A SER PAGA UM MÊS APÓS A DATA DO CONTRATO, A SEGUNDA PARCELA DOIS
           MESES APÓS O CONTRATO E ASSIM POR DIANTE. MOSTRAR OS DADOS DAS PARCELAS NA TELA.
        */
        static void Main(string[] args)
        {
            Console.WriteLine("Informações do Contrato");
            Console.Write("Número do Contrato: ");
            int numero = Convert.ToUInt16(Console.ReadLine());
            Console.Write("Data do Contrato (dd/MM/yyyy): ");
            DateTime dataContrato = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Valor do Contrato: ");
            double valorContrato = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Número de parcelas: ");
            int meses = Convert.ToUInt16(Console.ReadLine());

            // Instanciação e Processamento 
            Console.WriteLine("Parcelas calculadas:");
            Contrato contrato = new Contrato(numero, dataContrato, valorContrato);
            ContratoService cs = new ContratoService(new PayPalService());
            cs.ProcessarContrato(contrato, meses);
            foreach (Parcela parcela in contrato.Parcelas)
            {
                Console.WriteLine(parcela);
            }
        }
    }
}