using System.IO;
using Newtonsoft.Json;

namespace Utils
{
    public static class JsonStorageHelper<T> where T : class
    {
        public static void SaveToFile(T data, string filePath, bool append = false)
        {
            var jset = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            using (var writer = new StreamWriter(filePath, append))
            {
                var serializedData = JsonConvert.SerializeObject(data, Formatting.Indented, jset);
                writer.Write(serializedData);
            }
        }

        public static T LoadFromFile(string filePath)
        {
            var jset = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            using (var reader = new StreamReader(filePath))
            {
                var serializedData = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(serializedData, jset);
            }
        }
    }
}
