
public class Video
{
    public string _title;
    //  { get; set; }
    public string _author;
    //  { get; set; }
    public int _lengthInSeconds; 
    // { get; set; }
    public List<Comment> _comments;
    //  { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
}
