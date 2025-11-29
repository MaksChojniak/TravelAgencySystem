public sealed class TextLabel : ElementBase
{
    readonly string _text;
    public TextLabel(string? text = null)
    {
        _text = text??string.Empty;
    }

    public override void Show()
    {
        Console.WriteLine(_text);
    }
}