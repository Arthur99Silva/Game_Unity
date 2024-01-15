using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool isPaused = false;
    public ItemSlot[] itemSlots;

    void Update()
    {
        // Verifica se a tecla "I" foi pressionada
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Inverte o estado do pause
            isPaused = !isPaused;

            // Ativa/desativa o menu de inventário conforme necessário
            InventoryMenu.SetActive(isPaused);

            // Pausa ou retoma o jogo alterando a escala de tempo
            Time.timeScale = isPaused ? 0f : 1f;
        }
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].IsFull())
            {
                itemSlots[i].AddItem(item);
                return true; // Retorna verdadeiro se o item foi adicionado com sucesso
            }
        }
        
        return false; // Retorna falso se não houver espaço disponível nos slots
    }
}
