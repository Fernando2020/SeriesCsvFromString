using SeriesCsvFromString.Console.Models;
using SeriesCsvFromString.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SeriesCsvFromString.Console.Services
{
    public class WriteTxtService : IWriteTxtService
    {
        /*
            SELECT * FROM ASSETS
            SELECT * FROM SERIES
            SELECT * FROM CANDLES

            INSERT INTO ASSETS(ID, SYMBOL, DESCRIPTION, CHANGE_DATE, CREATION_DATE)
            VALUES(uuid_generate_v4() ,'CCM$', 'COTAÇÕES DO MILHO', current_timestamp, current_timestamp)

            INSERT INTO SERIES(ID, TIMEFRAME, ASSET_ID, CHANGE_DATE, CREATION_DATE)
            VALUES(uuid_generate_v4() , 12, '{5ff43220-c095-490f-aa19-18d941c9615a}', current_timestamp, current_timestamp)

            INSERT INTO CANDLES (ID, TIME, OPEN, HIGH, LOW, CLOSE, TICK_VOLUME, SPREAD, REAL_VOLUME, SERIE_ID, CHANGE_DATE, CREATION_DATE)
            VALUES(uuid_generate_v4(), , , , , , , , , '{a2679342-932c-4502-8139-00b63989666e}', current_timestamp, current_timestamp)
         */

        public void WriteCommandInsertInInTxt(List<Candle> candles, string path)
        {
            var command = new StringBuilder();

            command.AppendLine($@"DELETE FROM CANDLES;");
            command.AppendLine($@"DELETE FROM SERIES;");
            command.AppendLine($@"DELETE FROM ASSETS;");
            command.AppendLine($@"INSERT INTO ASSETS(ID, SYMBOL, DESCRIPTION, CHANGE_DATE, CREATION_DATE)
            VALUES(uuid_generate_v4() ,'CCM', 'COTAÇÕES DO MILHO', current_timestamp, current_timestamp);");
            command.AppendLine($@"INSERT INTO SERIES(ID, TIMEFRAME, ASSET_ID, CHANGE_DATE, CREATION_DATE)
            VALUES(uuid_generate_v4() , 12, (SELECT ID FROM ASSETS ORDER BY CREATION_DATE DESC LIMIT 1), current_timestamp, current_timestamp);");
            
            foreach (var candle in candles)
            {
                command.AppendLine($@"INSERT INTO CANDLES (ID, TIME, OPEN, HIGH, LOW, CLOSE, TICK_VOLUME, SPREAD, REAL_VOLUME, SERIE_ID, CHANGE_DATE, CREATION_DATE)
                    VALUES(uuid_generate_v4(),{candle.Time}, {candle.Open.ToString(CultureInfo.InvariantCulture)}, {candle.High.ToString(CultureInfo.InvariantCulture)}, 
                    {candle.Low.ToString(CultureInfo.InvariantCulture)}, {candle.Close.ToString(CultureInfo.InvariantCulture)}, 
                    {candle.TickVolume}, {candle.Spread}, {candle.RealVolume}, (SELECT ID FROM SERIES ORDER BY CREATION_DATE DESC LIMIT 1), current_timestamp, current_timestamp);
                    {Environment.NewLine}");
            }

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(command.ToString());
            sw.Close();
        }
    }
}
