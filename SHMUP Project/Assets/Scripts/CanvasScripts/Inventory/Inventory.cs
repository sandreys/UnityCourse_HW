using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public Transform SlotsParent;
    public Transform SlotsParentPlayer;

    public Item additionalItem;

    private InventorySlot[] inventorySlots = new InventorySlot[42];
    private GunSlot[] GunSlot = new GunSlot[1];
    private RocketSlot[] RocketSlot = new RocketSlot[1];

    public bool isOpened;
    public int indexForSwapItem;
    private void Start()
    {
        Instance = this;
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i] = SlotsParent.GetChild(i).GetComponent<InventorySlot>();
            inventorySlots[i].index = i;
        }
        GunSlot[0] = SlotsParentPlayer.GetChild(0).GetComponent<GunSlot>();
        RocketSlot[0] = SlotsParentPlayer.GetChild(1).GetComponent<RocketSlot>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpened)
            {              
                Close();
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0f;
                Open();
            }
        }
    }
    public void Open()
    {
        gameObject.transform.localScale = Vector3.one;
        isOpened = true;
    }
    public void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
        isOpened = false;
    }
    public void PutInEmptySlot(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].SlotItem == null)
            {
                inventorySlots[i].PutInSlot(item);

                return;
            }
        }
    }

    public void UnEquipWeapon(Item item)
    {
        if (item != null)
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].SlotItem == null)
                {
                    inventorySlots[i].PutInSlot(item);
                    if (item.type == Item.TypeGuns.Gun)
                    {
                        GunSlot[0].ClearSlot();
                    }
                    if (item.type == Item.TypeGuns.Rocket)
                    {
                        RocketSlot[0].ClearSlot();
                    }

                    return;
                }
            }
        }
    }

    public void PutInEmptySlotGun(Item item)
    {       
        if (GunSlot[0].SlotItem == null)
        {
            GunSlot[0].PutInSlot(item);
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].index == indexForSwapItem)
                {
                    inventorySlots[i].ClearSlot();
                    return;
                }
            }
            return;
        }

        else
        {
            additionalItem = GunSlot[0].SlotItem;
            GunSlot[0].PutInSlot(item);
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].index == indexForSwapItem)
                {
                    inventorySlots[i].PutInSlot(additionalItem);
                    return;
                }
            }
            return;
        }
    }

    public void PutInEmptySlotRocket(Item item)
    {
        if (RocketSlot[0].SlotItem == null)
        {
            RocketSlot[0].PutInSlot(item);

            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].index == indexForSwapItem)
                {
                    inventorySlots[i].ClearSlot();
                    return;
                }
            }
            return;
        }
        if (RocketSlot[0].SlotItem != null)
        {
            additionalItem = RocketSlot[0].SlotItem;         
            RocketSlot[0].PutInSlot(item);
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                Debug.Log($"{inventorySlots[i].SlotItem}");
                if (inventorySlots[i].index == indexForSwapItem)
                {
                    inventorySlots[i].PutInSlot(additionalItem);
                    return;
                }
            }
            return;
        }
    }

   
}
