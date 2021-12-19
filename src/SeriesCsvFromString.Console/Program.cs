using Microsoft.Extensions.DependencyInjection;
using SeriesCsvFromString.Service;
using SeriesCsvFromString.Service.Interfaces;
using System;

namespace SeriesCsvFromString.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureService(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var readCsvService = serviceProvider.GetService<IReadCsvService>();
            var writetxtService = serviceProvider.GetService<IWriteTxtService>();

            Initialize(readCsvService, writetxtService);
        }

        public static void ConfigureService(IServiceCollection services)
        {
            services.AddServices();
        }

        public static void Initialize(IReadCsvService readCsvService, IWriteTxtService writeTxtService)
        {
            while (true)
            {
                try
                {
                    System.Console.WriteLine($@"Informe o caminho do arquivo '.csv' obtido exclusivamente do Meta Trader.");
                    System.Console.WriteLine($@"Ex: C:\Temp\SeriesCsvFromString\ccm$_h1_2016_2021_2.csv");
                    string pathCsv = System.Console.ReadLine();

                    System.Console.WriteLine($@"Informe o caminho e nome para salvar o arquivo '.txt'.");
                    System.Console.WriteLine($@"Ex: C:\Temp\SeriesCsvFromString\archiveName.txt");
                    string pathTxt = System.Console.ReadLine();

                    var candles = readCsvService.GetQuotesFromCsvMetaTrader(pathCsv);

                    writeTxtService.WriteCommandInsertInInTxt(candles, pathTxt);

                    System.Console.WriteLine($@"Operação realizada com sucesso!");
                    System.Console.WriteLine($@"Acesse seu arquivo em: {pathTxt}");
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($@"Ocorreu um erro: {e.Message}");
                }
            }
        }
    }
}
