using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PickUp : MonoBehaviour
{
    private Inventory inventory;

    private Item item;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        item = this.gameObject.GetComponent<Item>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == true && inventory.slots[i].GetComponent<Image>().sprite == item.Sprite)
                {
                    inventory.itemCounter++;
                    inventory.slots[i].GetComponentInChildren<TextMeshProUGUI>().text = inventory.itemCounter.ToString();
                    Destroy(gameObject);
                }
                else if(inventory.isFull[i] == false)
                {
                    if(inventory.slots[i].GetComponent<Image>().sprite != item.Sprite)
                    {
                        if(inventory.itemCounter <= 1)
                        {
                            inventory.slots[i].GetComponent<Image>().sprite = item.Sprite;
                            inventory.slots[i].GetComponentInChildren<TextMeshProUGUI>().text = item.amount.ToString();
                            inventory.isFull[i] = true;
                            Destroy(gameObject);
                        }
                        break;
                    }
                }
            }
        }
    }
}
