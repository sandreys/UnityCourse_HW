using UnityEngine;
using UnityEngine.UI;
public class GunSlot : MonoBehaviour
{
    public static GunSlot Instance;

    public static bool isEquiped = false;

    public Item SlotItem;

    private Image Icon;
    private Button Button;

    public InventorySlot currentSlot;

    public PlayerBullet bullet;

    public GameObject parentObject;
    public GameObject[] gunsPrefabs;

    void Start()
    {
        Instance = this;
        Icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        Button = GetComponent<Button>();

        Button.onClick.AddListener(SlotClicked);
    }

    public void PutInSlot(Item item)
    {
        Icon.sprite = item.icon;
        SlotItem = item;
        Icon.enabled = true;

        AddGun();
        ChangeGun();
    }

    public void SlotClicked()
    {
        if (SlotItem != null)
        {
            ItemInfo.Instance.UnEquip.gameObject.SetActive(true);
            ItemInfo.Instance.CloseButton.gameObject.SetActive(false);
            ItemInfo.Instance.UseButton.gameObject.SetActive(false);
            ItemInfo.Instance.Open(SlotItem, currentSlot);
            ItemInfo.Instance.infoItem = SlotItem;
            
        }
    }
    public void ChangeDamageForPlayer()
    {
        if (SlotItem != null)
        {
            for (int i = 0; i < gunsPrefabs.Length; i++)
            {
                if (gunsPrefabs[i].name == SlotItem.name)
                { 
                    bullet.damage = SlotItem.damage;                
                }            
            }
            
        }
    }

    public void AddGun()
    {
        if (isEquiped == false)
        {
            for (int i = 0; i < gunsPrefabs.Length; i++)
            {
                if (gunsPrefabs[i].name == SlotItem.name)
                {
                    Instantiate(gunsPrefabs[i], parentObject.transform.position + new Vector3(0.01f, 0.5f, 0), Quaternion.identity).transform.SetParent(parentObject.transform);
                    isEquiped = true;
                }
            }

            ChangeDamageForPlayer();
        }
    }

    public void ChangeGun()
    {
        if (isEquiped == true)
        {
            for (int i = 0; i < parentObject.transform.childCount; i++)
            {
                if (parentObject.transform.GetChild(i).gameObject.CompareTag("Gun"))
                {
                    Destroy(parentObject.transform.GetChild(i).gameObject);
                }
            }
            for (int i = 0; i < gunsPrefabs.Length; i++)
            {
                if (gunsPrefabs[i].name == SlotItem.name)
                {
                    Instantiate(gunsPrefabs[i], parentObject.transform.position + new Vector3(0.01f, 0.5f, 0), Quaternion.identity).transform.SetParent(parentObject.transform);
                }
            }
            ChangeDamageForPlayer();
            Debug.Log($"PlayerGunDamage : {bullet.damage}");
        }
    }

    public void ClearSlot()
    {
        Icon.sprite = null;
        SlotItem = null;
        Icon.enabled = false;
        isEquiped = false;

        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            if (parentObject.transform.GetChild(i).gameObject.CompareTag("Gun"))
            {
                Destroy(parentObject.transform.GetChild(i).gameObject);
            }
        }
    }

}
