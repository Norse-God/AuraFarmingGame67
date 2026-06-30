using UnityEngine;

public abstract class InventorySlot
{
    private bool edibility;
    private bool CanBeUsed;
    private bool HasStrength;

    public InventorySlot(bool edibility, bool CanBeUsed, bool HasStrength)
    {
        this.edibility = edibility;
        this.CanBeUsed = CanBeUsed;
        this.HasStrength = HasStrength;
    }

}

public class Item_Eat : InventorySlot
{
    private string eat_name;
    private int count_type_eat;
    private int strength;
    bool depravity;

    public Item_Eat(string name, int count_type_name, int strength, bool depravity, bool edibility = true, bool CanBeUsed = true, bool HasStrength = false) : base(edibility, CanBeUsed, HasStrength)
    {
        this.eat_name = name;
        this.count_type_eat = count_type_name;
        this.strength = strength;
        this.depravity = depravity;
    }

}

public class Item_tools : InventorySlot
{
    private string tool_name;
    private int strength;

    public Item_tools(string tool_name, int strength, bool edibility = false, bool CanBeUsed = true, bool HasStrength = true) : base(edibility, CanBeUsed, HasStrength)
    {
        this.tool_name = tool_name;
        this.strength = strength;
    }
}



