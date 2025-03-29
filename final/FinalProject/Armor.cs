public class Armor : Item
{
    private int _defense;
    private int _durability;
    private int _maxDurability;

    public Armor(string name, int defense, int durability)
    {
        _name = name;
        _defense = defense;
        _durability = durability;
        _maxDurability = durability;
    }
    
    public int GetDefense()
    {
        return _defense;
    }
    
    public int GetDurability()
    {
        return _durability;
    }
    
    public override void Use(Character target)
    {
        if (target is Player player)
        {
            Console.WriteLine($"Equipping armor {_name} with {_defense} defense!");
            player.EquipArmor(this);
        }
        else
        {
            Console.WriteLine("Can't use armor on this target!");
        }
    }
    
    public void TakeDamage(int amount)
    {
        _durability -= amount;
        if (_durability <= 0)
        {
            _durability = 0;
            _defense = _defense / 2;
            Console.WriteLine($"{_name} is damaged and provides reduced protection!");
        }
    }
}