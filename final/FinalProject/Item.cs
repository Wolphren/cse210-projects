public abstract class Item
{
    public string _name 
    {
        get;
        protected set;
    }

    public abstract void Use(Character target);
}