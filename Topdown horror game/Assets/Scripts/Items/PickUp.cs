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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {

                if (inventory.isFull[i] == true && inventory.counters[i].activeSelf == true && inventory.slots[i].GetComponent<Image>().sprite == item.itemSprite)
                {
                    inventory.itemCounter[i]++;
                    inventory.slots[i].GetComponentInChildren<TextMeshProUGUI>().text = inventory.itemCounter[i].ToString();
                    Destroy(gameObject);

                    break;

                }
                else if (inventory.isFull[i] == false)
                {
                    if (inventory.slots[i].GetComponent<Image>().sprite != item.itemSprite)
                    {
                        if (inventory.itemCounter[i] <= 1)
                        {
                            inventory.counters[i].SetActive(true);

                            inventory.itemCounter[i] = item.itemAmount;

                            inventory.slots[i].GetComponent<Image>().sprite = item.itemSprite;
                            inventory.slots[i].GetComponentInChildren<TextMeshProUGUI>().text = inventory.itemCounter[i].ToString();
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
