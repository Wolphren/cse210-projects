public class Battle
{
    private Player _player;
    private List<Enemy> _enemies;
    private bool _isPlayerTurn = true;
    private bool _battleOver = false;
    
    public Battle(Player player, List<Enemy> enemies)
    {
        _player = player;
        _enemies = enemies;
        Console.WriteLine($"Battle started! {player._name} vs {enemies.Count} enemies!");
    }
    
    public void StartBattle()
    {
        Console.WriteLine("=== BATTLE BEGINS ===");
        while (!_battleOver)
        {
            ProcessTurn();
        }
    }
    
    private void ProcessTurn()
    {
        if (_isPlayerTurn)
        {
            PlayerTurn();
        }
        else
        {
            EnemyTurn();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        CheckBattleStatus();
        if (!_battleOver)
        {
            _isPlayerTurn = !_isPlayerTurn;
        }
    }
    
    private void PlayerTurn()
    {
        Console.WriteLine($"\n=== {_player._name}'s Turn ===");
        DisplayBattleStatus();
        
        Console.WriteLine("Choose an action:");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Use Item");
        
        int choice = GetPlayerChoice(1, 2);
        
        if (choice == 1)
        {
            if (_enemies.Count(e => e.IsAlive()) > 1)
            {
                Console.WriteLine("Choose a target to attack:");
                int index = 1;
                Dictionary<int, Enemy> enemyOptions = new Dictionary<int, Enemy>();
                foreach (Enemy enemy in _enemies)
                {
                    if (enemy.IsAlive())
                    {
                        Console.WriteLine($"{index}. {enemy._name} (HP: {enemy.GetHealth()})");
                        enemyOptions[index] = enemy;
                        index++;
                    }
                }
                int targetChoice = GetPlayerChoice(1, enemyOptions.Count);
                Enemy target = enemyOptions[targetChoice];
                _player.Attack(target);
            }
            else
            {
                Enemy target = _enemies.Find(e => e.IsAlive());
                if (target != null)
                {
                    _player.Attack(target);
                }
            }
        }
        else if (choice == 2)
        {
            if (_player.GetInventory().GetItemCount() > 0)
            {
                _player.GetInventory().DisplayInventory();
                Console.WriteLine("Choose item to use (0 to cancel):");
                int itemChoice = GetPlayerChoice(0, _player.GetInventory().GetItemCount());
                if (itemChoice > 0)
                {
                    Item selectedItem = _player.GetInventory().GetItemAt(itemChoice - 1);
                    _player.UseItem(selectedItem);
                }
                else
                {
                    PlayerTurn();
                    return;
                }
            }
            else
            {
                Console.WriteLine("No items in inventory!");
                PlayerTurn();
                return;
            }
        }
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
    
    private void EnemyTurn()
    {
        Console.WriteLine("\n=== Enemy Turn ===");
        foreach (Enemy enemy in _enemies)
        {
            if (enemy.IsAlive())
            {
                Console.WriteLine($"{enemy._name}'s turn!");
                enemy.Attack(_player);
                if (!_player.IsAlive())
                {
                    break;
                }
            }
        }
    }
    
    private void CheckBattleStatus()
    {
        if (!_player.IsAlive())
        {
            _battleOver = true;
            Console.WriteLine("\n=== DEFEAT ===");
            Console.WriteLine($"{_player._name} has been defeated!");
            return;
        }
        bool allEnemiesDefeated = true;
        foreach (Enemy enemy in _enemies)
        {
            if (enemy.IsAlive())
            {
                allEnemiesDefeated = false;
                break;
            }
        }
        
        if (allEnemiesDefeated)
        {
            _battleOver = true;
            Console.WriteLine("\n=== VICTORY ===");
            Console.WriteLine("All enemies have been defeated!");
            int totalExp = 0;
            foreach (Enemy enemy in _enemies)
            {
                Item loot = enemy.DropLoot();
                _player.GetInventory().AddItem(loot);
                totalExp += 50;
            }
            
            _player.GainExperience(totalExp);
        }
    }
    
    private void DisplayBattleStatus()
    {
        Console.WriteLine($"\n{_player._name}: HP {_player.GetHealth()}");
        Console.WriteLine("Enemies:");
        foreach (Enemy enemy in _enemies)
        {
            if (enemy.IsAlive())
            {
                Console.WriteLine($"- {enemy._name}: HP {enemy.GetHealth()}");
            }
        }
        Console.WriteLine();
    }
}