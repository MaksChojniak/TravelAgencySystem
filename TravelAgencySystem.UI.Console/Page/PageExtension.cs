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

    public static string NormalizeTextSize(this string text, int size) => text + new string(' ', Math.Clamp(size-text.Length, 0, int.MaxValue));

    public static T SelectFromList<T>(this IReadOnlyList<T> list)
    {
        if(list.Count == 0)
            throw new Exception("List is Empty");

        Console.Write($"Select: ");
        string input = Console.ReadLine()??string.Empty;

        if(string.IsNullOrEmpty(input))
            throw new Exception("Invalid input");

        if(!int.TryParse(input, out var selectedIndex))
            throw new Exception("Not a number");
        
        selectedIndex -= 1;
        if(selectedIndex < 0 || selectedIndex >= list.Count)
            throw new Exception("Index out of range");

        T accomodation = list[selectedIndex];
        return accomodation;
    }

}