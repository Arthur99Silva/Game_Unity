using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemIcon;
    public int stackSize; // Adicione o campo stackSize

    public Item()
    {
        stackSize = 1; // Defina um valor padrão para stackSize
    }
}
