namespace SeriesCsvFromString.Console.Models
{
    public class Candle
    {
        public long Time { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public int TickVolume { get; set; }
        public int Spread { get; set; }
        public int RealVolume { get; set; }
    }
}
