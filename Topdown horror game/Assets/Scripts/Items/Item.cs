using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Name of the item")]
    public string itemName = null;

    [Header("descritption of what the item is")]
    public string itemDescription = null;

    [Header("amount you pick up")]
    public int itemAmount = 0;

    [Header("sprite of the item")]
    public Sprite itemSprite;

    [Header("make the item stackable or not")]
    public bool stackable;

    public Item (string name, string descritption, int amount, Sprite sprite)
    {
        itemName = name;
        itemDescription = descritption;
        itemAmount = amount;
        itemSprite = sprite;
    }
}
