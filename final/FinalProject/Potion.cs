public class Potion : Item
{
    private int _healAmount;
    private bool _isUsed;
    
    public Potion(string name, int healAmount)
    {
        _name = name;
        _healAmount = healAmount;
        _isUsed = false;
    }
    
    public override void Use(Character target)
    {
        if (_isUsed)
        {
            Console.WriteLine($"The {_name} has already been used!");
            return;
        }
        Console.WriteLine($"Using {_name} to heal for {_healAmount} HP!");
        target.Heal(_healAmount);
        _isUsed = true;
    }
}