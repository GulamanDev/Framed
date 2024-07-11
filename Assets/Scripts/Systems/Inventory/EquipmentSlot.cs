using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] private Image defaultIcon;
    [SerializeField] private Image itemIcon;
    public EquipmentSlotType type;

    private ItemData itemData;
    InventoryManager inventoryManager;

    private void Start() {
        inventoryManager = InventoryManager.Instance;
    }
    public void SetItem(ItemData data)
    {
        // TODO
        // Set the item data the and icons here
        // Make sure to apply the attributes once an item is equipped
        itemIcon.enabled = true;
        itemIcon.gameObject.SetActive(true);
        itemIcon.sprite = data.icon;
        defaultIcon.gameObject.SetActive(false);
        itemData = data;
        //itemIcon.enabled = true;
    }

    public void Unequip()
    {

        // TODO
        // Check if there is an available inventory slot before removing the item.
        // Make sure to return the equipment to the inventory when there is an available slot.
        // Reset the item data and icons here
        if(inventoryManager.GetEmptyInventorySlot()!=-1)
        {
            inventoryManager.AddItem(itemData.id);
            itemIcon.enabled = false;
            itemIcon.gameObject.SetActive(false);
            itemIcon.sprite = null;
            defaultIcon.gameObject.SetActive(true);
            itemData = null;
        }
    }

    public bool HasItem()
    {
        return itemData != null;
    }
}