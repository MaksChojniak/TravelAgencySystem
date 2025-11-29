public sealed class ListView<T> : ElementBase where T : ElementBase
{
    readonly IList<T> _items;
    public ListView(IList<T> items)
    {
        _items = items;
    }

    public override void Show()
    {
        foreach(var item in _items)
            item.Show();
    }
}