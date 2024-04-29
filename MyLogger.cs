namespace MyUtil;

public class MyLogger
{
    private static DateTime now = DateTime.Now;
    public static void WriteLineInfo(string str)
    {
        now = DateTime.Now;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Info    | {now.ToString("yyyy-MM-dd HH:mm:ss")} | {str}");
        Console.ResetColor();
    }
    
    public static void WriteInfo(string str)
    {
        now = DateTime.Now;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"Info | {now.ToString("yyyy-MM-dd HH:mm:ss")} | {str}");
        Console.ResetColor();
    }
    
    public static void WriteLineError(string str)
    {
        now = DateTime.Now;
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error   | {now.ToString("yyyy-MM-dd HH:mm:ss")} | {str}");
        Console.ResetColor();
    }
    
    public static void WriteError(string str)
    {
        now = DateTime.Now;
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"Error | {now.ToString("yyyy-MM-dd HH:mm:ss")} | {str}");
        Console.ResetColor();
    }
    
    public static void WriteLineWarning(string str)
    {
        now = DateTime.Now;
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Warning | {now.ToString("yyyy-MM-dd HH:mm:ss")} | {str}");
        Console.ResetColor();
    }
    
    public static void WriteWarning(string str)
    {
        now = DateTime.Now;
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"Warning | {now.ToString("yyyy-MM-dd HH:mm:ss")} | {str}");
        Console.ResetColor();
    }
}