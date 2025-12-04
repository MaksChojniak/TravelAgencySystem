public sealed class TextInputLabel : ElementBase
{
    readonly string _text;
    readonly Action<string> _onTextEntered;

    public TextInputLabel(string? text, Action<string> onTextEntered)
    {
        _text = text??string.Empty;
        _onTextEntered = onTextEntered;
    }

    public override void Show()
    {
        Console.Write(_text);
        string input = Console.ReadLine() ?? string.Empty;
        Console.WriteLine();
        _onTextEntered.Invoke(input);
    }
}