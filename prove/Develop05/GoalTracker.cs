public class GoalTracker 
{
    private List<Goal> _goals = new List<Goal>();
    private int _totalScore;
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }
    public void RecordGoalEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int pointsEarned = _goals[goalIndex].RecordEvent();
            _totalScore += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_totalScore} points.");
        }
    }
    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
            return;
        }
        
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            string completionStatus = _goals[i].IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {completionStatus} {_goals[i].GetString()}");
        }
    }
    public int GetTotalScore()
    {
        return _totalScore;
    }
    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {

            outputFile.WriteLine(_totalScore);
            

            foreach (Goal goal in _goals)
            {
                string goalType = goal.GetType().Name;
                string goalData = "";
                
                if (goalType == "SimpleGoal")
                {
                    SimpleGoal simpleGoal = (SimpleGoal)goal;
                    goalData = $"{goalType}:{goal.GetName()},{goal.GetDescription()},{goal.GetPoints()},{simpleGoal.IsComplete()}";
                }
                else if (goalType == "OngoingGoal")
                {
                    goalData = $"{goalType}:{goal.GetName()},{goal.GetDescription()},{goal.GetPoints()}";
                }
                else if (goalType == "ChecklistGoal")
                {
                    ChecklistGoal checklistGoal = (ChecklistGoal)goal;

                    string[] parts = checklistGoal.GetString().Split(" ");
                    string currentCount = parts[parts.Length - 2].Split("/")[0];
                    string targetCount = parts[parts.Length - 2].Split("/")[1];

                    int bonusPoints = 500;
                    
                    goalData = $"{goalType}:{goal.GetName()},{goal.GetDescription()},{goal.GetPoints()},{targetCount},{currentCount},{bonusPoints}";
                }
                
                outputFile.WriteLine(goalData);
            }
        }
    }
    public void LoadGoals(string filename)
    {
        _goals.Clear();
    
        string[] lines = System.IO.File.ReadAllLines(filename);
        
        _totalScore = int.Parse(lines[0]);
        
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string goalType = parts[0];
            string[] goalData = parts[1].Split(",");
            
            if (goalType == "SimpleGoal")
            {
                string name = goalData[0];
                string description = goalData[1];
                int points = int.Parse(goalData[2]);
                bool isComplete = bool.Parse(goalData[3]);
                
                SimpleGoal goal = new SimpleGoal(name, description, points);
                if (isComplete)
                {
                    goal.RecordEvent();
                }
                _goals.Add(goal);
            }
            else if (goalType == "OngoingGoal")
            {
                string name = goalData[0];
                string description = goalData[1];
                int points = int.Parse(goalData[2]);
                
                OngoingGoal goal = new OngoingGoal(name, description, points);
                _goals.Add(goal);
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = goalData[0];
                string description = goalData[1];
                int points = int.Parse(goalData[2]);
                int targetCount = int.Parse(goalData[3]);
                int currentCount = int.Parse(goalData[4]);
                int bonusPoints = int.Parse(goalData[5]);
                
                ChecklistGoal goal = new ChecklistGoal(name, description, points, targetCount, currentCount, bonusPoints);
                _goals.Add(goal);
            }
        }
    }
}