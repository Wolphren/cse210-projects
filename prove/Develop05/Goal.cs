public class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }
    public string GetName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public int GetPoints()
    {
        return _points;
    }
    virtual public int RecordEvent(){return 0;}
    virtual public bool IsComplete(){return false;}
    virtual public string GetString()
    {
        return $"{_name}: {_description}. {_points}pts";
    }

}