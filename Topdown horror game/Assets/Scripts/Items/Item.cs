using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Name of the item")]
    public string name;

    [Header("descritption of what the item is")]
    public string description;

    [Header("amount you pick up")]
    public int amount = 0;

    [Header("sprite of the item")]
    public Sprite Sprite;

    public void Items(string itemName, string itemDescritption, int itemAmount, Sprite itemSprite)
    {
        itemName = name;

        itemDescritption = description;

        itemAmount = amount;

        itemSprite = Sprite;
    }

}
