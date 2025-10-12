using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text;
public static class JsonTool
{
    public static T LoadJson<T>(string path)
    {
        byte[] bytes = File.ReadAllBytes(path);
        string json = Encoding.UTF8.GetString(bytes);
        var data = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { IncludeFields = true });
        return data;
    }

    public static void SaveJson<T>(string path, T data)
    {
        var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        string jsonString = JsonSerializer.Serialize(data, options);
        File.WriteAllBytes(path, Encoding.UTF8.GetBytes(jsonString));
    }
}
