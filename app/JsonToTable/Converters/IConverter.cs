using JsonToTable.Models;

namespace JsonToTable.Converters
{
    public interface IConverter
    {
        void Convert(Item[] items, string outputFilePaht);
    }
}
