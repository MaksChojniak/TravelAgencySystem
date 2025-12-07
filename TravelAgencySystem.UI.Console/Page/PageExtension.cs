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

        T item = list[selectedIndex];
        return item;
    }

    public static List<T> SelectManyFromList<T>(this IReadOnlyList<T> list)
    {
        if(list.Count == 0)
            throw new Exception("List is Empty");

        Console.Write($"Select: ");
        string input = Console.ReadLine()??string.Empty;
        List<string> inputs = input.Split(',').Select(s => s.Trim()).ToList();

        if(inputs.Any(input => string.IsNullOrEmpty(input)))
            throw new Exception("Invalid input");

        List<int> selectedIndexes = new();
        if(inputs.Any(input =>
        {
            bool state = !int.TryParse(input, out var selectedIndex);
            selectedIndexes.Add(selectedIndex);
            return state;
        }))
            throw new Exception("Not a number");
        
        selectedIndexes = selectedIndexes.Select(i => i-1).ToList();
        if(selectedIndexes.Any(selectedIndex => selectedIndex < 0 || selectedIndex >= list.Count))
            throw new Exception("Index out of range");

        List<T> items = selectedIndexes.Select(index => list[index]).ToList();
        return items;
    }

}