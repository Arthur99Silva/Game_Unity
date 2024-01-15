using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryBar : MonoBehaviour
{
    [SerializeField] private GameObject[] itemSlots; // array of item slots
    private List<Item> inventoryList; // hold reference to the inventory list
    private Inventory inventoryScript; // hold reference to the inventory script

    private void Start()
    {
        itemSlots = new GameObject[3]; // create an empty array of 3 game objects
        inventoryList = new List<Item>();

        // the item slots will be children of the Inventory Bar
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = transform.GetChild(i).gameObject;
        }

        inventoryScript = FindObjectOfType<Inventory>();
    }

    private void OnEnable()
    {
        Inventory.OnInventoryChange += UpdateBar;
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChange -= UpdateBar;
    }

    private void UpdateBar()
    {
        inventoryList = inventoryScript.GetInventoryList();
        int itemCount = inventoryList.Count;

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < itemCount)
            {
                itemSlots[i].SetActive(true);
                UpdateItemSlotUI(itemSlots[i], inventoryList[i]);
            }
            else
            {
                itemSlots[i].SetActive(false);
            }
        }
    }

    private void UpdateItemSlotUI(GameObject slot, Item item)
    {
        Transform iconTransform = slot.transform.GetChild(2);
        Image iconImage = iconTransform.GetComponent<Image>();
        iconImage.sprite = item.itemIcon;

        Transform stackSizeTransform = slot.transform.GetChild(3).GetChild(0);
        TextMeshProUGUI stackSizeText = stackSizeTransform.GetComponent<TextMeshProUGUI>();
        stackSizeText.text = item.stackSize.ToString();
    }
}
