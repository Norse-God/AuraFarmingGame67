using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public string Name;
    public Sprite icon;
    public GameObject prefab;
    public int stackMax;
}
