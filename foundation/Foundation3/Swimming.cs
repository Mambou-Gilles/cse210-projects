public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0 * 0.62;
    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;
    public override double GetPace() => GetMinutes() / GetDistance();

    public override string GetSummary()
    {
        string status = IsCompleted() ? "[X]" : "[ ]";
        return $"{status} {GetDate()} Swimming ({GetMinutes()} min) - Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }

    public override void WriteToFile(StreamWriter writer)
    {
        writer.WriteLine("Swimming");
        writer.WriteLine(GetDate());
        writer.WriteLine(GetMinutes());
        writer.WriteLine(_laps);
    }
}