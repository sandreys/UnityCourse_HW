using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Item item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {        
            Inventory.Instance.PutInEmptySlot(item);
            Destroy(gameObject);
            
        }
    }
}
