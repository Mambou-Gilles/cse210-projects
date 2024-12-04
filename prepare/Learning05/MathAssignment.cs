public class MathAssignment : Assignment
{
    private string _textBookSection = "";
    private string _problems = "";

    public MathAssignment(string name, string topic, string text, string problems) : base(name, topic)
    {
        _textBookSection = text;
        _problems = problems;
    }

    // public string GetSummary(){
    //     return $"{_studentName}, the topic is {_topic}";
    // }

    public string GetHomeworkList(){
        return $"Section {_textBookSection} Problems {_problems}";
    }
}