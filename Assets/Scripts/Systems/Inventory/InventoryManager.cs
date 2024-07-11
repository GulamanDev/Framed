using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //For now, this will store information of the Items that can be added to the inventory
    public List<ItemData> itemDatabase;

    //Store all the inventory slots in the scene here
    public List<InventorySlot> inventorySlots;

    //Store all the equipment slots in the scene here
    public List<EquipmentSlot> equipmentSlots;

    //Singleton implementation. Do not change anything within this region.
    #region SingletonImplementation
    private static InventoryManager instance = null;
    public static InventoryManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "Inventory";
                    instance = go.AddComponent<InventoryManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public void UseItem(ItemData data)
    {
        // TODO
        // If the item is a consumable, simply add the attributes of the item to the player.
        // If it is equippable, get the equipment slot that matches the item's slot.
        // Set the equipment slot's item as that of the used item
        if(data.type == ItemType.Consumable)
        {
            
        }
        if(data.type == ItemType.Equipabble)
        {

            equipmentSlots[GetEquipmentSlot(data.slotType)].SetItem(data);
        }
    }

   
    public void AddItem(string itemID)
    {
        // Debug.Log("Hi");
        // foreach(ItemData item in itemDatabase)
        // {
        //     if(itemID == item.id)
        //     {
        //         int i = GetEmptyInventorySlot();
        //         inventorySlots[i].SetItem(item);
        //     }
        // }
        //TODO
        //1. Cycle through every item in the database until you find the item with the same id.
        //2. Get the index of the InventorySlot that does not have any Item and set its Item to the Item found
    }

    public int GetEmptyInventorySlot()
    {
        // //TODO
        // //Check which inventory slot doesn't have an Item and return its index
        // for (int i = 0; i< inventorySlots.Count; i++)
        // {
        //     InventorySlot slot = inventorySlots[i];
        //     if(slot.HasItem() == false)
        //     {
        //         return i;
        //     }
        // }
        return -1;
    }

    public int GetEquipmentSlot(EquipmentSlotType type)
    {
        for (int i = 0; i< equipmentSlots.Count; i++)
        {
            if(equipmentSlots[i].type == type)
            {
                if(!equipmentSlots[i].HasItem())
                {
                    return i;
                }
            }

        }
        //TODO
        //Check which equipment slot matches the slot type and return its index
        return -1;
    }

    // public bool KeyCheck()
    // {
    //     for (int i = 0; i< inventorySlots.Count; i++)
    //     {
    //         InventorySlot slot = inventorySlots[i];
    //         if(slot.HasItem())
    //         {
    //             if(slot.hasKey())
    //             {
    //                 return true;
    //             }
    //         }
    //     }
    //     return false;
    // }

    // public void RemoveKey()
    // {
    //     for (int i = 0; i< inventorySlots.Count; i++)
    //     {
    //         InventorySlot slot = inventorySlots[i];
    //         if(slot.HasItem())
    //         {
    //             if(slot.hasKey())
    //             {
    //                 slot.DeleteKey();
    //             }
    //         }
    //     }
    // }

}