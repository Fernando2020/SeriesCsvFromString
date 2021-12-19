using SeriesCsvFromString.Console.Models;
using System.Collections.Generic;

namespace SeriesCsvFromString.Service.Interfaces
{
    public interface IReadCsv
    {
        List<Candle> GetQuotesFromCsvMetaTrader(string path);
    }
}
