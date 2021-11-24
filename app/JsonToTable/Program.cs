using JsonToTable.Converters;
using JsonToTable.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace JsonToTable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (!ValidateArguments(args, out string errorMessage))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid Argument(s).{Environment.NewLine}{errorMessage}");
                Console.ResetColor();
                return;
            }

            Item[] items = null;
            using (StreamReader file = File.OpenText(args[0]))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                var inputJObject = (JObject)JToken.ReadFrom(reader);
                var itemsJToken = inputJObject["items"]["item"];
                items = itemsJToken.ToObject<Item[]>();
            }

            if (items != null)
            {
                var fileInfo = new FileInfo(args[1]);
                fileInfo.Directory.Create();

                IConverter converter = fileInfo.Extension == ".md" ?
                    new ItemsToMarkDownConverter() :
                    new ItemsToCsvConverter();

                converter.Convert(items, fileInfo.FullName);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Successfully output to {fileInfo.FullName}");
                Console.ResetColor();
                return;
            }
        }

        private static bool ValidateArguments(string[] args, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (args.Length != 2)
            {
                errorMessage = "Exected format: JsonToTable.exe [input file path] [output file path].";
                return false;
            }

            if (!File.Exists(args[0]))
            {
                errorMessage = "Input file not found: Please make sure that input file path is valid.";
                return false;
            }

            return true;
        }
    }
}
