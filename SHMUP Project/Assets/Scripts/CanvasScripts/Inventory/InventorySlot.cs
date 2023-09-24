using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Item SlotItem;

    private Image Icon;
    private Button Button;

    public int index;
    
    private void Start()
    {
        Icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        Button = GetComponent<Button>();
        Button.onClick.AddListener(SlotClicked);
    }

    public void PutInSlot(Item item)
    {
        Icon.sprite = item.icon;
        SlotItem = item;
        Icon.enabled = true;
    }

    public void ClearSlot()
    {
        Icon.sprite = null;
        SlotItem = null;
        Icon.enabled = false;
    }

    public void SlotClicked()
    {
        if (SlotItem != null)
        {
            ItemInfo.Instance.UnEquip.gameObject.SetActive(false);
            ItemInfo.Instance.CloseButton.gameObject.SetActive(true);
            ItemInfo.Instance.UseButton.gameObject.SetActive(true);
            Inventory.Instance.indexForSwapItem = index;            
            ItemInfo.Instance.Open(SlotItem, this);
        }
    }
}
