using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // Item Data
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;

    // Item Slot UI
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    // Adiciona um item ao slot
    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;

        UpdateUI();
    }

    // Remove o item do slot
    public void RemoveItem()
    {
        itemName = "";
        quantity = 0;
        itemSprite = null;
        isFull = false;

        UpdateUI();
    }

    // Atualiza a interface do usuário com as informações do item
    private void UpdateUI()
    {
        if (isFull)
        {
            quantityText.text = quantity.ToString();
            quantityText.enabled = true;
            itemImage.sprite = itemSprite;
        }
        else
        {
            quantityText.text = "";
            quantityText.enabled = false;
            itemImage.sprite = null;
        }
    }
}
