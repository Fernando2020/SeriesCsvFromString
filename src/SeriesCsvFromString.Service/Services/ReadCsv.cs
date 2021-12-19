using SeriesCsvFromString.Console.Models;
using SeriesCsvFromString.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SeriesCsvFromString.Console.Services
{
    public class ReadCsv : IReadCsv
    {
        public List<Candle> GetQuotesFromCsvMetaTrader(string pathAndFileName)
        {
            return File.ReadAllLines(pathAndFileName)
                        .Skip(1)
                        .Select(v => FromCsv(v))
                        .ToList();
        }
        private static Candle FromCsv(string csvLine)
        {
            string[] values = csvLine.Split('\t');
            Candle candle = new Candle();
            candle.Time = Convert.ToInt64(new DateTimeOffset(Convert.ToDateTime(values[0] + " " + values[1]).AddHours(-3)).ToUnixTimeSeconds());
            candle.Open = Convert.ToDouble(values[2].Replace(".", ","));
            candle.High = Convert.ToDouble(values[3].Replace(".", ","));
            candle.Low = Convert.ToDouble(values[4].Replace(".", ","));
            candle.Close = Convert.ToDouble(values[5].Replace(".", ","));
            candle.TickVolume = Convert.ToInt32(values[6]);
            candle.RealVolume = Convert.ToInt32(values[7]);
            candle.Spread = Convert.ToInt32(values[8]);
            return candle;
        }
    }
}
