public class Enemy : Character
{
    private string _enemyType;
    private Item _loot;

    public Enemy(string name, int health, int attackPower, string enemyType, Item loot) : base(name, health, attackPower)
    {
        _enemyType = enemyType;
        _loot = loot;
    }
    public Item DropLoot()
    {
        Console.WriteLine($"{_name} drops {_loot._name}!");
        return _loot;
    }
}