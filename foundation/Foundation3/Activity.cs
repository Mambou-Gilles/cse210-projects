public abstract class Activity
{
    private string date;
    private int minutes;
    private bool completed;

    protected Activity(string date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
        this.completed = false;
    }

    public string GetDate() => date;
    public int GetMinutes() => minutes;
    public bool IsCompleted() => completed;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public void MarkAsCompleted()
    {
        completed = true;
    }

    public virtual string GetSummary()
    {
        string status = completed ? "[X]" : "[ ]";
        return $"{date} {status}: {minutes} min";
    }

    public abstract void WriteToFile(StreamWriter writer);
}