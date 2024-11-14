public class Entry {
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string promptText, string entryText){
        _date = DateTime.Now.ToShortDateString();
        _promptText = promptText;
        _entryText = entryText;

    }

    public void Display(){
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText} - Response: {_entryText}");
    }

    public string ToFileString(){
        return $"{_date}~|~{_promptText}~|~{_entryText}";
    }

    public static Entry FromFileString(string fileString){
        string[] parts = fileString.Split("~|~");
        return new Entry(parts[1], parts[2]){_date=parts[0]};
    }

}