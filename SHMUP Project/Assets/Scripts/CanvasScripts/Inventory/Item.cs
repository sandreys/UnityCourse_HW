using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string name;
    public string description;
    public Sprite icon;
    public int damage;
    public TypeGuns type;
    public enum TypeGuns
    {
        Gun,
        Rocket
    }

    

}

