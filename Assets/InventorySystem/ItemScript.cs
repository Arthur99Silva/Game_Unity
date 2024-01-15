using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public string itemName;
    public Sprite itemIcon;
    public Item item;

    private void Start()
    {
        // Crie um novo Item
        item = new Item();

        item.itemName = itemName;
        item.itemIcon = itemIcon;
    }

    // Retorna o Item
    public Item GetItem()
    {
        return item;
    }

    // Chamado quando o item é coletado
    public void CollectItem()
    {
        // Aqui, você precisa encontrar o ItemSlot relevante.
        // Pode ser através de um sistema centralizado de inventário ou outras maneiras.
        // Por agora, estou assumindo que você tem uma referência direta para o ItemSlot.

        ItemSlot itemSlot = GetComponent<ItemSlot>();

        if (itemSlot != null)
        {
            // Adiciona o item ao slot
            itemSlot.AddItem(itemName, 1, itemIcon);

            // Aqui você pode adicionar lógica adicional, como desativar o objeto coletado.
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Coleta o item quando o jogador entra no trigger do objeto
        CollectItem();
    }
}
