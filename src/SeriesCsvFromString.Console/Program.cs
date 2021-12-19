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
                    System.Console.WriteLine($@"Informe o nome do arquivo '.csv' obtido exclusivamente do Meta Trader:");
                    string read = System.Console.ReadLine();
                    string nameCsv = string.IsNullOrEmpty(read) ? @$"ccm$_h1_2016_2021_2.csv" : read;

                    System.Console.WriteLine($@"Informe o caminho para salvar o arquivo '.txt':");
                    string pathTxt = System.Console.ReadLine();

                    var candles = readCsvService.GetQuotesFromCsvMetaTrader(nameCsv);

                    writeTxtService.WriteCommandInsertInInTxt(candles, pathTxt);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($@"Ocorreu um erro: {e.Message}");
                }
            }
        }
    }
}
