using SeriesCsvFromString.Console.Models;
using System.Collections.Generic;

namespace SeriesCsvFromString.Service.Interfaces
{
    public interface IWriteTxtService
    {
        void WriteCommandInsertInInTxt(List<Candle> candles, string path);
    }
}
