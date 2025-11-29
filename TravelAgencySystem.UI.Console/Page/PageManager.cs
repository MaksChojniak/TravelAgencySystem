
public static class PageManager
{
    public static Dictionary<string, PageBase> Pages;
    static PageManager()
    {
        Pages = new();
    }

    public static void LoadPage(string? name = null)
    {
        if(name is null)
        {
            Console.Clear();
            return;
        }

        if(!Pages.ContainsKey(name))
            return;

        Pages[name]?.Show();
    }
}