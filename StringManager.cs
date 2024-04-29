using System.Text.Json;

namespace MyUtil;

public class StringManager
{
    public static string ToStringWithComma<T>(List<T> list)
    {
        return string.Join(",", list);
    }
    
    public static List<T> FromStringWithComma<T>(string str)
    {
        try
        {
            return str.Split(',').Select(x => (T)Convert.ChangeType(x, typeof(T))).ToList();
        }
        catch
        {
            Console.WriteLine("Failed to convert comma string to list");
            return new List<T>();
        }
    }
    
    public static string ToJson<T>(T obj)
    {
        return JsonSerializer.Serialize(obj);
    }
    
    public static T? FromJson<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json);
    }
}