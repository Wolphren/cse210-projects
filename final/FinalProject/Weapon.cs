public class Weapon : Item
{
    private int _damage;
    private float _attackSpeed;

    public Weapon(string name, int damage, float attackSpeed)
    {
        _name = name;
        _damage = damage;
        _attackSpeed = attackSpeed;
    }
    
    public int GetDamage()
    {
        return _damage;
    }
    
    public override void Use(Character target)
    {
        if (target is Player player)
        {
            Console.WriteLine($"Equipping weapon {_name}, with {_damage} damage!");
            player.EquipWeapon(this);
        }
        else
        {
            Console.WriteLine($"Using weapon {_name}, dealing {_damage} damage!");
            target.TakeDamage(_damage);
        }
    }
}