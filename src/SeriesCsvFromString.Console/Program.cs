using System;

namespace SeriesCsvFromString.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    System.Console.WriteLine($@"Informe o caminho e nome do arquivo '.csv' obtido exclusivamente do Meta Trader:");
                    string pathCsv = System.Console.ReadLine();
                    System.Console.WriteLine($@"Informe o caminho para salvar o arquivo '.txt'");
                    string pathTxt = System.Console.ReadLine();

                }
                catch (Exception e)
                {
                    System.Console.WriteLine($@"O arquivo informado não foi encontrado!");
                }
            }
        }
    }
}
