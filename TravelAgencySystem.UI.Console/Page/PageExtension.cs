public static class PageExtension
{
    public static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static void ConsoleError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}