using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickUp : MonoBehaviour
{
    private Inventory inventory;

    private Item item;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        item = GameObject.FindGameObjectWithTag("item").GetComponent<Item>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                    inventory.slots[i].GetComponent<Image>().sprite = item.Sprite;
                    item.amount++;
                    inventory.isFull[i] = true;
                    Destroy(gameObject);

                    break;
                }
            }
        }
    }

}
