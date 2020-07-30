using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PullOutInventory : MonoBehaviour
{
    [Header("the UI panel for the inventory")]
    [SerializeField] private GameObject inventoryPanel;

    private bool invetoryOpen = false;

    void Update()
    {
        //open and close the inventory
        if(Input.GetKeyDown(KeyCode.I) && invetoryOpen == false)
        {
            OpenInventory();
        }
        else if(Input.GetKeyDown(KeyCode.I) && invetoryOpen == true)
        {
            CloseInventory();
        }
    }

    //opens the inventory
    private void OpenInventory()
    {
        if (inventoryPanel.active)
        {
            inventoryPanel.transform.DOMoveX(1840f, 1f);
            invetoryOpen = true;
        }
    }

    //closes the inventory
    private void CloseInventory()
    {
        inventoryPanel.transform.DOMoveX(2000f, 1f);
        invetoryOpen = false;
    } 
      
}
