using System.Text.Json;

namespace LearnHistoricalNet7n8Features.Tools
{
    /// <summary>
    /// Dumps the object as a json string
    /// Can be used for logging object contents.
    /// </summary>
    /// <typeparam name="T">Type of the object.</typeparam>
    /// <param name="obj">The object to dump. Can be null</param>
    /// <param name="indent">To indent the result or not</param>
    /// <returns>the a string representing the object content</returns>
    /// 
    public static class ExtensionDump
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
        {
            IncludeFields = true,
            WriteIndented = true
        };

        public static void Dump<T>(this T obj, bool indent = false)
        {
            var stringified = JsonSerializer.Serialize(obj, jsonSerializerOptions);
            Console.WriteLine(stringified);
        }

        public static void Dump<T>(this T obj, string title, bool indent = false)
        {
            Console.WriteLine(title);
            obj.Dump();
        }
    }
}
