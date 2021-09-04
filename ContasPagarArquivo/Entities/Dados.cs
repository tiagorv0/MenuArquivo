using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace ContasPagarArquivo.Entities
{
    class Dados
    {
        public int Codigo {  get; set; }
        public DateTime DataVencimento { get; set; }
        public string TipoConta { get; set; }
        public string Observacao { get; set; }
        public double Valor { get; set; }
        public DateTime DataPagamento { get; set; }

        string path = @"C:\Users\Tiago Vazzoller\Desktop\contas.txt";

        List<Dados> list = new List<Dados>();

        public Dados()
        {

        }

        public Dados(DateTime dataVencimento, string tipoConta, string observacao, double valor, DateTime dataPagamento)
        {
            Codigo = list.Count() + 1;
            DataVencimento = dataVencimento;
            TipoConta = tipoConta;
            Observacao = observacao;
            Valor = valor;
            DataPagamento = dataPagamento;
        }

        public void AddConta()
        {
            
            Console.WriteLine("--- Leitura de Contas Pagas ---");
            Console.WriteLine("Quantas contas deseja adicionar: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write("Data de Vencimento: ");
                DateTime dv = DateTime.Parse(Console.ReadLine());
                Console.Write("Tipo de Conta(Ex: Água, Luz, Telefone): ");
                string tipo = Console.ReadLine();
                Console.Write("Observação: ");
                string obs = Console.ReadLine();
                Console.Write("Valor: ");
                double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Data do Pagamento: ");
                DateTime dp = DateTime.Parse(Console.ReadLine());

                list.Add(new Dados(dv, tipo, obs, valor, dp));

                Console.WriteLine();
            }


            try
            {

                using (StreamWriter sw = File.AppendText(path))
                {
                    foreach (Dados d in list)
                    {
                        sw.WriteLine(d);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void ImportarDados()
        {
            Console.WriteLine("--- Importar Contas Pagas ---");
            Console.WriteLine("Informe o arquivo a ser importado para as suas contas: ");
            string importedPath = Console.ReadLine();

            try
            {
                using(StreamWriter sw = File.AppendText(path))
                {
                    string[] line = File.ReadAllLines(importedPath);
                    foreach (string l in line)
                    {
                        string[] field = l.Split(',');
                        DateTime dv = DateTime.Parse(field[0]);
                        string tipo = field[1];
                        string obs = field[2];
                        double valor = double.Parse(field[3]);
                        DateTime dp = DateTime.Parse(field[4]);

                        list.Add(new Dados(dv, tipo, obs, valor, dp));
                    }

                    foreach (Dados d in list)
                    {
                        sw.WriteLine(d);
                    }

                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void ImprimirDados()
        {
            Console.WriteLine("--- Contas Pagas ---");

            list.Clear();
            string[] line = File.ReadAllLines(path);

            foreach (string l in line)
            {
                string[] field = l.Split(',');
                int codigo = int.Parse(field[0]);
                DateTime dv = DateTime.Parse(field[1]);
                string tipo = field[2];
                string obs = field[3];
                double valor = double.Parse(field[4]);
                DateTime dp = DateTime.Parse(field[5]);

                list.Add(new Dados(dv, tipo, obs, valor, dp));
            }

            foreach (Dados d in list)
            {
                Console.WriteLine(d);
            }
        }

        public override string ToString()
        {
            return Codigo + ", "
                + DataVencimento + ", "
                + TipoConta + ", "
                + Observacao + ", "
                + Valor.ToString("F2", CultureInfo.InvariantCulture) + ", "
                + DataPagamento;

            
        }

        
    }
}
