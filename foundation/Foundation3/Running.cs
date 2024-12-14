public class Running : Activity
{
    private double _distance;

    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / GetMinutes()) * 60;
    public override double GetPace() => GetMinutes() / _distance;

    public override string GetSummary()
    {
        string status = IsCompleted() ? "[X]" : "[ ]";
        return $"{status} {GetDate()} Running ({GetMinutes()} min) - Distance: {_distance:F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }

    public override void WriteToFile(StreamWriter writer)
    {
        writer.WriteLine("Running");
        writer.WriteLine(GetDate());
        writer.WriteLine(GetMinutes());
        writer.WriteLine(_distance);
    }
}