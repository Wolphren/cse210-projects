public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string name, string description, int points) : base(name, description, points){}
    public override int RecordEvent()
    {
        _isComplete = true;
        return GetPoints();
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetString()
    {
        return base.GetString();
    }
}