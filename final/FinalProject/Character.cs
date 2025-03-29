public abstract class Character
{
    public string _name { get; protected set; }
    private int _health;
    private int _maxHealth;
    private int _attackPower;
    private bool _isAlive;

    public Character(string name, int health, int attackPower)
    {
        _name = name;
        _maxHealth = health;
        _health = health;
        _attackPower = attackPower;
        _isAlive = true;
    }
    
    public int GetHealth()
    {
        return _health;
    }
    
    public int GetAttackPower()
    {
        return _attackPower;
    }
    
    public bool IsAlive()
    {
        return _isAlive;
    }
    
    public virtual void Attack(Character target)
    {
        Console.WriteLine($"{_name} attacks {target._name} for {_attackPower} damage!");
        target.TakeDamage(_attackPower);
    }
    
    public virtual void TakeDamage(int amount)
    {
        _health -= amount;
        Console.WriteLine($"{_name} takes {amount} damage. Health: {_health}");
        
        if (_health <= 0)
        {
            _health = 0;
            _isAlive = false;
            Console.WriteLine($"{_name} has been defeated!");
        }
    }
    
    public virtual void Heal(int amount)
    {
        int healAmount = Math.Min(amount, _maxHealth - _health);
        _health += healAmount;
        Console.WriteLine($"{_name} heals for {healAmount} HP. Health: {_health}");
    }
}