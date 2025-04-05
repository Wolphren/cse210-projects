public class Game
{
    private Player _player;
    private List<Enemy> _enemies;
    private bool _gameOver = false;
    
    public void Start()
    {
        Console.WriteLine("=== Game Started! ===");

        _player = new Player("Hero", 100, 10, 1);

        Weapon startingWeapon = new Weapon("Rusty Sword", 5, 1.0f);
        Armor startingArmor = new Armor("Leather Vest", 3, 50);
        Potion healthPotion = new Potion("Health Potion", 30);
        
        _player.GetInventory().AddItem(startingWeapon);
        _player.GetInventory().AddItem(startingArmor);
        _player.GetInventory().AddItem(healthPotion);
        
        _player.UseItem(startingWeapon);
        _player.UseItem(startingArmor);
        
        while (!_gameOver)
        {
            DisplayMainMenu();
            int choice = GetPlayerChoice(1, 3);
            
            switch (choice)
            {
                case 1:
                    Explore();
                    break;
                case 2:
                    ManageInventory();
                    break;
                case 3:
                    _gameOver = true;
                    break;
            }
        }
        
        End();
    }
    
    private void DisplayMainMenu()
    {
        Console.WriteLine("\n=== MAIN MENU ===");
        Console.WriteLine($"Player: {_player._name} (Level {_player.GetLevel()})");
        Console.WriteLine($"Health: {_player.GetHealth()}");
        Console.WriteLine("1. Explore");
        Console.WriteLine("2. Inventory");
        Console.WriteLine("3. Quit");
        Console.WriteLine("Enter your choice (1-3):");
    }
    
    private int GetPlayerChoice(int min, int max)
    {
        int choice;
        bool validInput = false;
        
        do
        {
            string input = Console.ReadLine();
            validInput = int.TryParse(input, out choice) && choice >= min && choice <= max;
            
            if (!validInput)
            {
                Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}:");
            }
        } while (!validInput);
        
        return choice;
    }
    
    private void ManageInventory()
    {
        bool exitInventory = false;
        
        while (!exitInventory)
        {
            _player.GetInventory().DisplayInventory();
            
            Console.WriteLine("\n=== INVENTORY OPTIONS ===");
            Console.WriteLine("1. Use Item");
            Console.WriteLine("2. Return to Main Menu");
            Console.WriteLine("Enter your choice (1-2):");
            
            int choice = GetPlayerChoice(1, 2);
            
            switch (choice)
            {
                case 1:
                    if (_player.GetInventory().GetItemCount() > 0)
                    {
                        Console.WriteLine("Enter the item number to use:");
                        int itemIndex = GetPlayerChoice(1, _player.GetInventory().GetItemCount()) - 1;
                        Item selectedItem = _player.GetInventory().GetItemAt(itemIndex);
                        
                        if (selectedItem != null)
                        {
                            _player.UseItem(selectedItem);
                            if (selectedItem is Potion)
                            {
                                _player.GetInventory().RemoveItem(selectedItem);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your inventory is empty!");
                    }
                    break;
                case 2:
                    exitInventory = true;
                    break;
            }
        }
    }
    
    private void Explore()
    {
        Console.WriteLine("\nExploring the world...");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        
        Random random = new Random();
        if (random.Next(100) < 70) 
        {
            InitiateBattle();
        }
        else
        {
            Console.WriteLine("Nothing interesting found.");
            if (random.Next(100) < 30)
            {
                FindRandomItem();
            }
        }
    }
    
    private void FindRandomItem()
    {
        Item foundItem = GenerateRandomLoot();
        Console.WriteLine($"You found a {foundItem._name}!");
        _player.GetInventory().AddItem(foundItem);
    }
    
    private void InitiateBattle()
    {
        _enemies = GenerateEnemies();
        Battle battle = new Battle(_player, _enemies);
        battle.StartBattle();
        if (!_player.IsAlive())
        {
            _gameOver = true;
        }
    }
    
    private List<Enemy> GenerateEnemies()
    {
        List<Enemy> enemies = new List<Enemy>();
        Random random = new Random();
        int enemyCount = random.Next(1, 4);
        
        for (int i = 0; i < enemyCount; i++)
        {
            string name = GetRandomEnemyName();
            int health = random.Next(20, 51);
            int attack = random.Next(5, 16);
            string type = GetRandomEnemyType();
            Item loot = GenerateRandomLoot();
            
            Enemy enemy = new Enemy(name, health, attack, type, loot);
            enemies.Add(enemy);
        }
        
        return enemies;
    }
    
    private string GetRandomEnemyName()
    {
        string[] names = { "Goblin", "Orc", "Skeleton", "Wolf", "Bandit", "Troll" };
        Random random = new Random();
        return names[random.Next(names.Length)];
    }
    
    private string GetRandomEnemyType()
    {
        string[] types = { "Normal", "Elite", "Boss" };
        Random random = new Random();
        return types[random.Next(types.Length)];
    }
    
    private Item GenerateRandomLoot()
    {
        Random random = new Random();
        int itemType = random.Next(100);
        
        if (itemType < 40)
        {
            string[] weaponNames = { "Dagger", "Sword", "Axe", "Mace", "Bow" };
            string prefix = GetRandomPrefix();
            return new Weapon
            (
                $"{prefix} {weaponNames[random.Next(weaponNames.Length)]}",
                random.Next(3, 11),
                0.8f + (random.Next(6) * 0.1f)
            );
        }
        else if (itemType < 80)
        {
            string[] armorNames = { "Helmet", "Chestplate", "Gauntlets", "Boots", "Shield" };
            string prefix = GetRandomPrefix();
            return new Armor
            (
                $"{prefix} {armorNames[random.Next(armorNames.Length)]}",
                random.Next(2, 8),
                random.Next(40, 101) 
            );
        }
        else
        {
            string[] potionTypes = { "Minor", "Regular", "Greater" };
            int healAmount = potionTypes[random.Next(potionTypes.Length)] switch
            {
                "Minor" => 20,
                "Regular" => 40,
                "Greater" => 80,
                _ => 30
            };
            
            return new Potion($"{potionTypes[random.Next(potionTypes.Length)]} Health Potion", healAmount);
        }
    }
    
    private string GetRandomPrefix()
    {
        string[] prefixes = { "Rusty", "Shiny", "Powerful", "Ancient", "Broken", "Sturdy", "Magical", "Enchanted" };
        Random random = new Random();
        return prefixes[random.Next(prefixes.Length)];
    }
    
    public void RunTurn()
    {
        Console.WriteLine("Running a game turn...");
    }
    
    public void End()
    {
        Console.WriteLine("\n=== Game Over ===");
        Console.WriteLine($"Thanks for playing, {_player._name}!");
    }
}