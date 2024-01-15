using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenu : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("CanvaInventoryTotal").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerArmature")
        {
            Item newItem = new Item
            {
                itemName = itemName,
                stackSize = quantity,
                itemIcon = sprite
            };

            inventoryManager.AddItem(newItem);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
