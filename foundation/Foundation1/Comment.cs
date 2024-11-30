public class Comment
{
    public string _name;
    // { get; set; }
    public string _text;
    // { get; set; }

    public Comment(string commentName, string text)
    {
        _name = commentName;
        _text = text;
    }
}
