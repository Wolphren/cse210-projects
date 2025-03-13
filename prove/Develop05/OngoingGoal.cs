public class OngoingGoal : Goal
{
    public OngoingGoal(string name, string description, int points) : base(name, description, points){}
    override public int RecordEvent()
    {
        return GetPoints();
    }
    public override bool IsComplete()
    {
        return base.IsComplete();
    }
    public override string GetString()
    {
        return base.GetString();
    }
}