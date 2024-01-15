using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script de teste p/add item no inventario completo = ItemScript
public class ItemTeste : MonoBehaviour
{
    public string itemName;
    public Sprite itemIcon;
    public Item item;

    void Start()
    {
        item = new Item();
        item.itemName = itemName;
        item.itemIcon = itemIcon;
    }

    public void CollectItem()
    {
        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager != null)
        {
            inventoryManager.AddItem(item);
            gameObject.SetActive(false);
        }
    }
}
