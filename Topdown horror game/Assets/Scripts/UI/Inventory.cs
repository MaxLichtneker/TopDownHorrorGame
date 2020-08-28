using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Inventory : MonoBehaviour
{
    public bool[] isFull;

    [Header("the amount of slots the inventory has")]
    public GameObject[] slots;

    [Header("Amount of counters in the inventory")]
    public GameObject[] counters;

    [Header("names of the pickedUp objects")]
    public string[] names;

    [Header("keeps track of how many items are in each slot")]
    public int[] itemCounter;


    public void DeleteItem(string itemName)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (isFull[i])
            {
                if(itemName == names[i] && itemCounter[i] <= 1)
                {
                    slots[i].gameObject.GetComponent<Image>().sprite = null;

                    slots[i].GetComponentInChildren<TextMeshProUGUI>().text = null;
                    itemCounter[i]--;
                    
                    names[i] = null;
                    isFull[i] = false;

                }
                else if(itemName == names[i] && itemCounter[i] > 1)
                {
                    itemCounter[i]--;
                    slots[i].GetComponentInChildren<TextMeshProUGUI>().text = itemCounter[i].ToString();

                }
            }
        }
    }

}


