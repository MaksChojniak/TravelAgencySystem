public abstract class PageBase
{
    protected virtual string Title { get; }
    protected virtual IEnumerable<ElementBase> Elements { get; }
    protected virtual Dictionary<char, Action?> Actions { get; } 

    public void Load()
    {
        try
        {
            Show();
        }
        catch(Exception ex)
        {
            Console.WriteLine();
            PageExtension.ConsoleError($"{ex.Message}");
            PageExtension.Pause();
        }
        catch
        {
            Console.WriteLine();
            PageExtension.ConsoleError("An unknown error occurred.");
            PageExtension.Pause();
        }
        finally
        {
            Load();
        }
    }

    protected virtual void Show()
    {
        do
        {
            Console.Clear();
            
            Console.WriteLine($"==== {Title} ====");
            
            foreach(var element in Elements)
            {
                element.Show();
            }

            if(Actions.Count > 0)
            {
                Console.WriteLine();
                Console.Write("Select Operation: ");

                var key = Console.ReadKey();
                if(Actions.ContainsKey(key.KeyChar))
                {
                    Actions[key.KeyChar]?.Invoke();
                    break;
                }
                else
                    throw new InvalidOperationException("Invalid action selected.");
            }
            
        }while(Actions.Count > 0);
    }
}