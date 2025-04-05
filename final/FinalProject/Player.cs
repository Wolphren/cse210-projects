public class Player : Character
{
    private int _level;
    private int _experience;
    private int _experienceToNextLevel;
    private Inventory _inventory;
    private Weapon _equippedWeapon;
    private Armor _equippedArmor;

    public Player(string name, int health, int attackPower, int level) : base(name, health, attackPower)
    {
        _level = level;
        _experience = 0;
        _experienceToNextLevel = level * 100;
        _inventory = new Inventory();
        _equippedWeapon = null;
        _equippedArmor = null;
    }
    
    // Add getter for level
    public int GetLevel()
    {
        return _level;
    }
    
    public Inventory GetInventory()
    {
        return _inventory;
    }
    
    public void UseItem(Item item)
    {
        Console.WriteLine($"{_name} uses {item._name}");
        item.Use(this);
    }
    
    public void EquipWeapon(Weapon weapon)
    {
        _equippedWeapon = weapon;
        Console.WriteLine($"{_name} equipped {weapon._name}");
    }
    
    public void EquipArmor(Armor armor)
    {
        _equippedArmor = armor;
        Console.WriteLine($"{_name} equipped {armor._name}");
    }
    
    public override void Attack(Character target)
    {
        int damage = GetAttackPower();  
        if (_equippedWeapon != null)
        {
            damage += _equippedWeapon.GetDamage();
        }
        Console.WriteLine($"{_name} attacks {target._name} for {damage} damage!");
        target.TakeDamage(damage);
    }
    
    public override void TakeDamage(int amount)
    {
        int damageReduction = 0;
        if (_equippedArmor != null)
        {
            damageReduction = _equippedArmor.GetDefense();
        }
        int actualDamage = Math.Max(1, amount - damageReduction);
        Console.WriteLine($"{_name}'s armor absorbs {damageReduction} damage!");
        base.TakeDamage(actualDamage);
    }
    
    public void GainExperience(int exp)
    {
        _experience += exp;
        Console.WriteLine($"{_name} gains {exp} experience points. (Total: {_experience})");
        if (_experience >= _experienceToNextLevel)
        {
            LevelUp();
        }
    }
    
    private void LevelUp()
    {
        _level++;
        _experience -= _experienceToNextLevel;
        _experienceToNextLevel = _level * 100;
        Console.WriteLine($"LEVEL UP! {_name} is now level {_level}!");
    }
}