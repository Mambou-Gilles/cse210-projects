public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * GetMinutes()) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed;

    public override string GetSummary()
    {
        string status = IsCompleted() ? "[X]" : "[ ]";
        return $"{status} {GetDate()} Cycling ({GetMinutes()} min) - Distance: {GetDistance():F2} miles, Speed: {_speed:F2} mph, Pace: {GetPace():F2} min per mile";
    }

    public override void WriteToFile(StreamWriter writer)
    {
        writer.WriteLine("Cycling");
        writer.WriteLine(GetDate());
        writer.WriteLine(GetMinutes());
        writer.WriteLine(_speed);
    }
}