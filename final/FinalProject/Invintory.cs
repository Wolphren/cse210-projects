public class Inventory
{
    private List<Item> _items = new List<Item>();
    
    public void AddItem(Item item)
    {
        _items.Add(item);
        Console.WriteLine($"Added {item._name} to inventory");
    }
    
    public void RemoveItem(Item item)
    {
        if (_items.Remove(item))
        {
            Console.WriteLine($"Removed {item._name} from inventory.");
        }
        else
        {
            Console.WriteLine($"Item {item._name} not found in inventory");
        }
    }
    
    public int GetItemCount()
    {
        return _items.Count;
    }
    
    public Item GetFirstItem()
    {
        if (_items.Count > 0)
            return _items[0];
        return null;
    }
    
    public List<Item> GetAllItems()
    {
        return _items;
    }
    
    public void DisplayInventory()
    {
        Console.WriteLine("=== INVENTORY ===");
        if (_items.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }
        for (int i = 0; i < _items.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_items[i]._name}");
        }
    }
    
    public Item GetItemAt(int index)
    {
        if (index >= 0 && index < _items.Count)
        {
            return _items[index];
        }
        return null;
    }
}