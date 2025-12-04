public sealed class ListView<T> : ElementBase where T : ElementBase
{
    readonly IList<T> _items;
    public ListView(IList<T> items)
    {
        _items = items;
    }

    public override void Show()
    {
        if(_items.Count == 0)
        {
            Console.WriteLine("-- No items to display --");
            return;
        }
        foreach(var item in _items)
            item.Show();
    }
}