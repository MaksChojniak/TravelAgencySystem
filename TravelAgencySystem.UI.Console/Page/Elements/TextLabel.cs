public sealed class TextLabel : ElementBase
{
    readonly string _text;
    readonly ConsoleColor? _color;
    public TextLabel(string? text = null)
    {
        _text = text??string.Empty;
        _color = null;
    }
    public TextLabel(string text, ConsoleColor color)
    {
        _text = text??string.Empty;
        _color = color;
    }

    public override void Show()
    {
        if(_color is not null)
            Console.ForegroundColor = _color.Value;
        Console.WriteLine(_text);
        Console.ResetColor();
    }
}