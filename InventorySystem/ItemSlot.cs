using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // Item Data
    private Item item;
    private bool isFull;

    // Item Slot
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    public void AddItem(Item item)
    {
        this.item = item;
        isFull = true;

        quantityText.text = item.stackSize.ToString();
        quantityText.enabled = true;
        itemImage.sprite = item.itemIcon;
    }

    public bool IsFull()
    {
        return isFull;
    }
}
