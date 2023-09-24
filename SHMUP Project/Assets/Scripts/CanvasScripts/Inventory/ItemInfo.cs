using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public static ItemInfo Instance;

    private Image BackGround;
    private TextMeshProUGUI Title;
    private TextMeshProUGUI Description;
    private Image Icon;
    private Button ExitButton;
    
    public Button UseButton;
    public Button CloseButton;
    public Button UnEquip;

    public InventorySlot currenSlot;

    public Item infoItem;
    public void Start()
    {
        Instance = this;

        BackGround = GetComponent<Image>();
        Title = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Description = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        Icon = transform.GetChild(2).GetComponent<Image>();
        ExitButton = transform.GetChild(3).GetComponent<Button>();
        UseButton = transform.GetChild(4).GetComponent<Button>();
        CloseButton = transform.GetChild(5).GetComponent<Button>();
        UnEquip = transform.GetChild(6).GetComponent<Button>();

        ExitButton.onClick.AddListener(Close);
        UseButton.onClick.AddListener(Use);
        CloseButton.onClick.AddListener(Delete);
        UnEquip.onClick.AddListener(UnEquipGun);
    }

    public void ChangeInfo(Item item)
    {
        Title.text = item.name;
        Description.text = item.description;
        Icon.sprite = item.icon;
    }

    public void Use()
    {
        if (infoItem.type == Item.TypeGuns.Gun)
        {
            Inventory.Instance.PutInEmptySlotGun(infoItem);
        }

        if (infoItem.type == Item.TypeGuns.Rocket)
        {
            Inventory.Instance.PutInEmptySlotRocket(infoItem);
        }
    }

    public void Open(Item item, InventorySlot currentSlot)
    {
        ChangeInfo(item);
        infoItem = item;
        gameObject.transform.localScale = Vector3.one;
        currenSlot = currentSlot;
    }

    public void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
    }

    public void Delete()
    {
        currenSlot.ClearSlot();
    }

    public void UnEquipGun()
    {
        Inventory.Instance.UnEquipWeapon(infoItem);
    }
}
