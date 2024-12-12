public class EternalGoal : Goal
{


    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override void RecordEvent()
    {}

    public override bool IsComplete()
    {
        return false; // Eternal goals never complete
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal - Goal name: {_shortName} | Description: {_description} | Points: {_points}";
    }

}
