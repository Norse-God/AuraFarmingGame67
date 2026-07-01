using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Scriptable Objects/item")]
public class item : ScriptableObject
{
    public string itemName;
    public int MaxAmount;
    public Sprite icon;
}
