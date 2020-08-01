using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;

    [Header("the amount of slots the inventory has")]
    public GameObject[] slots;

    [Header("keeps track of how many items are in each slot")]
    public int itemCounter;

}
