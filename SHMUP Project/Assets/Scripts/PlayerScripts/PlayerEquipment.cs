using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public GameObject gun;

    public void Update()
    {
        GunIsEquipment();
        RocketIsEquipment();
    }

    public void GunIsEquipment()
    {
        if (GunSlot.isEquiped)
        {
            gun.GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
    }

    public void RocketIsEquipment()
    {
        if (RocketSlot.isEquiped)
        {
            gun.GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
    }
}
