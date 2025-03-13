public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;
    public ChecklistGoal(string name, string description, int points, int targetCount, int currentCount, int bonusPoints) : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonusPoints = bonusPoints;
    }
    public override int RecordEvent()
    {
        _currentCount ++;
        if (_currentCount == _targetCount)
        {
            return GetPoints() + _bonusPoints;
        }
        else
        {
            return GetPoints();
        }
    }
    public override string GetString()
    {
        return $"{base.GetString()} Completed {_currentCount}/{_targetCount} times";
    }
}