public class ChecklistGoal : Goal
{



    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public int GetBonus() => _bonus;

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return IsComplete() ? $"[X] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}" : $"[ ] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal - Goal name: {_shortName} | Description: {_description} | Points: {_points} | Bonus: {_bonus} | Target: {_target} | Completed: {_amountCompleted}";
    }

}