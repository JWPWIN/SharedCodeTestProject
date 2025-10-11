using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Unicode;
using System.Text.Encodings.Web;
public static class JsonTool
{
    public static T LoadJson<T>(string path)
    {
        string info = File.ReadAllText(path);
        var data = JsonSerializer.Deserialize<T>(info, new JsonSerializerOptions { IncludeFields = true });
        return data;
    }

    public static void SaveJson<T>(string path, T data)
    {
        var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        string jsonString = JsonSerializer.Serialize(data, options);
        File.WriteAllText(path, jsonString);
    }
}
