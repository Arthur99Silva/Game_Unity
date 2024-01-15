using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    private List<Item> inventoryList;

    // delegate event for inventory updates
    public delegate void InventoryChangeEvent();
    public static event InventoryChangeEvent OnInventoryChange;

    private AbilitySizeShift sizeShiftScript;

    private void Start()
    {
        inventoryList = new List<Item>();
        sizeShiftScript = GetComponent<AbilitySizeShift>();
    }

    public List<Item> GetInventoryList()
    {
        return inventoryList;
    }

    public void AddItem(Item item)
    {
        if (inventoryList.Count == 0 || !TryStackItem(item))
        {
            inventoryList.Add(item);
            EnableAbilityScripts(item);
        }

        OnInventoryChange?.Invoke();
    }

    private bool TryStackItem(Item newItem)
    {
        foreach (Item existingItem in inventoryList)
        {
            if (newItem.itemName == existingItem.itemName)
            {
                existingItem.stackSize++;
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            ItemScript otherItemScript = other.GetComponent<ItemScript>();
            Item otherItem = otherItemScript.GetItem();

            AddItem(otherItem);

            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
        }
    }

    private void EnableAbilityScripts(Item item)
    {
        if (item.itemName == "Potion" || item.itemName == "BluePotion" || item.itemName == "GreenPotion")
        {
            sizeShiftScript.enabled = true;
        }
    }

    private void DisableAbilityScripts(Item item)
    {
        if (item.itemName == "Potion" || item.itemName == "BluePotion" || item.itemName == "GreenPotion")
        {
            sizeShiftScript.enabled = false;
        }
    }

    public static bool AbilityIsActive = false;

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame && inventoryList.Count > 0 && !AbilityIsActive)
        {
            ActivateAbility(0);
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame && inventoryList.Count > 1 && !AbilityIsActive)
        {
            ActivateAbility(1);
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame && inventoryList.Count > 2 && !AbilityIsActive)
        {
            ActivateAbility(2);
        }
    }

    private void ActivateAbility(int index)
    {
        AbilityIsActive = true;
        CheckWhichAbilityToActivate(index);
        RemoveItem(index);
    }

    private void CheckWhichAbilityToActivate(int index)
    {
        Item itemToCheck = inventoryList[index];

        if (itemToCheck.itemName == "Potion" || itemToCheck.itemName == "Potion2")
        {
            sizeShiftScript.ActivateSizeShift();
        }
    }

    private void RemoveItem(int index)
    {
        Item itemToRemove = inventoryList[index];

        if (itemToRemove.stackSize == 1)
        {
            inventoryList.Remove(itemToRemove);
            DisableAbilityScripts(itemToRemove);
        }
        else if (itemToRemove.stackSize > 1)
        {
            itemToRemove.stackSize--;
        }

        OnInventoryChange?.Invoke();
    }
}
