using UnityEngine;
using UnityEngine.UI;
public class RocketSlot : MonoBehaviour
{
    public static RocketSlot Instance;

    public static bool isEquiped = false;

    public Item SlotItem;
    private Image Icon;
    private Button Button;

    public PlayerRocketExplosion rocketExplosion;

    public InventorySlot currentSlot;

    public GameObject parentObject;
    public GameObject[] gunsPrefabs;

    public void Start()
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
        isEquiped = true;

        AddRocket();
        ChangeRocket();
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

    public void ChangeRocketDamageForPlayer()
    {
        if (SlotItem != null)
        {
            for (int i = 0; i < gunsPrefabs.Length; i++)
            {
                if (gunsPrefabs[i].name == SlotItem.name)
                {
                    rocketExplosion.damage = SlotItem.damage;
                }
            }
        }
    }

    public void AddRocket()
    {
        if (isEquiped == false)
        {
            for (int i = 0; i < gunsPrefabs.Length; i++)
            {
                if (gunsPrefabs[i].name == SlotItem.name)
                {
                    Instantiate(gunsPrefabs[i], parentObject.transform.position + new Vector3(0, 0, 0), Quaternion.identity).transform.SetParent(parentObject.transform);
                    isEquiped = true;
                }
            }
            ChangeRocketDamageForPlayer();
        }
    }

    public void ChangeRocket()
    {
        if (isEquiped == true)
        {
            for (int i = 0; i < parentObject.transform.childCount; i++)
            {
                if (parentObject.transform.GetChild(i).gameObject.CompareTag("Rocket"))
                {
                    Destroy(parentObject.transform.GetChild(i).gameObject);
                }
            }
            for (int i = 0; i < gunsPrefabs.Length; i++)
            {
                if (gunsPrefabs[i].name == SlotItem.name)
                {
                    Instantiate(gunsPrefabs[i], parentObject.transform.position + new Vector3(0, 0, 0), Quaternion.identity).transform.SetParent(parentObject.transform);
                }
            }
            ChangeRocketDamageForPlayer();
            Debug.Log($"PlayerRoketDamage : {rocketExplosion.damage}");
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
            if (parentObject.transform.GetChild(i).gameObject.CompareTag("Rocket"))
            {
                Destroy(parentObject.transform.GetChild(i).gameObject);
            }
        }
    }
}

