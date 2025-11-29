public abstract class PageBase
{
    protected virtual string Title { get; }
    protected virtual IEnumerable<ElementBase> Elements { get; }
    protected virtual Dictionary<char, Action?> Actions { get; } 

    public virtual void Show()
    {
        do
        {
            Console.Clear();
            
            Console.WriteLine($"---- {Title} ----");
            
            foreach(var element in Elements)
            {
                element.Show();
            }

            if(Actions.Count > 0)
            {
                var key = Console.ReadKey();
                if(Actions.ContainsKey(key.KeyChar))
                {
                    Actions[key.KeyChar]?.Invoke();
                    break;
                }
            }
            
        }while(Actions.Count > 0);
    }
}