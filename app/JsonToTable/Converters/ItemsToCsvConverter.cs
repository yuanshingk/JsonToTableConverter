using JsonToTable.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JsonToTable.Converters
{
    public class ItemsToCsvConverter : IConverter
    {
        private const string DELIMITER = ",";
        private readonly List<string> header = new List<string> { "Id", "Type", "Name", "Batter", "Topping" };

        public void Convert(Item[] items, string outputFilePath)
        {
            if (items == null || string.IsNullOrWhiteSpace(outputFilePath))
            {
                throw new ArgumentNullException("Arguments cannot be null or empty");
            }

            var flattenedItems = from i in items
                      from b in i.Batters.Batter
                      from t in i.Toppings
                      select new { Id = i.Id, Type = i.Type, Name = i.Name, Batter = b.Type, Topping = t.Type };

            List<List<string>> rows = new List<List<string>>();
            foreach (var flattenedItem in flattenedItems)
            {
                var columns = new List<string>
                {
                    flattenedItem.Id,
                    flattenedItem.Type,
                    flattenedItem.Name,
                    flattenedItem.Batter,
                    flattenedItem.Topping
                };

                rows.Add(columns);
            }

            var sb = new StringBuilder();
            sb.AppendLine(String.Join(DELIMITER, header));

            foreach (var row in rows)
            {
                sb.AppendLine(String.Join(DELIMITER, row));
            }

            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}
