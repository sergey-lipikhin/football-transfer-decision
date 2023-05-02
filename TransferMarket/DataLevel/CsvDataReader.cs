using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using System.Linq;
using System.Globalization;

namespace DataLevel
{
    public static class CsvDataReader
    {
        private const string dataSet = @"..\..\..\..\DataLevel\Data\dataset.csv";
        private const string nationalities = @"..\..\..\..\DataLevel\Data\nationalities.csv";
        public static void GetUniqueSymbols(List<string> source_string)
        {
            List<char> all_symbols = new List<char>();
            source_string.ForEach(el => el.ToCharArray().ToList().ForEach(sy => all_symbols.Add(sy)));

            all_symbols.Distinct().Where(el => !Char.IsLetterOrDigit(el)).ToList().ForEach(el => Console.WriteLine(el));
        }

        private static List<string> ReadColumn(string filename, string columnName)
        {
            List<string> data = new List<string>();

            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(filename)), true))
            {
                csvTable.Load(csvReader);

                foreach (DataRow row in csvTable.Rows)
                {
                    data.Add(row[columnName].ToString());
                }
            }
            return data;
        }
        public static List<string> ReadClubs(string filename = dataSet) =>
            ReadColumn(filename, "Club").Distinct().ToList();
        public static List<string> ReadPositions(string filename = dataSet) =>
            ReadColumn(filename, "Position").Distinct().ToList();
        public static List<(string, string)> ReadNationalities(string filename = nationalities)
        {
            var names = ReadColumn(filename, "Nationality").Distinct().ToList();
            var images = ReadColumn(filename, "Image").Distinct().ToList();

            List<(string, string)> nationalities = new List<(string, string)>();
            for(int i = 0; i < names.Count; i++)
            {
                nationalities.Add((names[i], images[i]));
            }
            return nationalities;
        }

        public static List<(string, string, string, double)> ReadPlayers(string filename = dataSet)
        {
            List<(string, string, string, double)> player =
                new List<(string, string, string, double)>();

            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(filename)), true))
            {
                csvTable.Load(csvReader);

                foreach (DataRow row in csvTable.Rows)
                {
                    player.Add((
                        row["Name"].ToString(),
                        row["Club"].ToString(),
                        row["Position"].ToString(),
                        Convert.ToDouble(row["Price"], CultureInfo.InvariantCulture)
                        ));
                }
            }

            return player;
        }
    }
}
