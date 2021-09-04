using System;
using System.Collections.Generic;
using ContasPagarArquivo.Entities;
using System.IO;

namespace ContasPagarArquivo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dados dados = new Dados();

            bool menu = true;
            while(menu == true)
            {
                Console.WriteLine("--- Menu ---\n1 - Adicionar Contas Pagas\n2 - Importar Contas\n3 - Editar Contas\n4 - Imprimir Contas\n5 - Sair");
                int index = int.Parse(Console.ReadLine());
                switch (index)
                {
                    case 1:
                        dados.AddConta();
                        break;
                    case 2:
                        dados.ImportarDados();
                        break;
                    case 3:
                        break;
                    case 4:
                        dados.ImprimirDados();
                        break;
                    case 5:
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Error! Código informado não existe!");
                        break;
                }
            }
        }
    }
}
