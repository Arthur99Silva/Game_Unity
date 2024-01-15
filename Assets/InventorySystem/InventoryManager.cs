using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool isPaused = false;
    public ItemSlot[] itemSlot;

    void Start()
    {
    }

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

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite);
                return;
            }
        }
    }
}