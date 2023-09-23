using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/CreateNewItem")]
public class Item : ScriptableObject
{
    public int Id;
    public string Name;
    public Sprite Icon;
}
