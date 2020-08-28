using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillCircle : MonoBehaviour
{
    private Inventory inventory;

    [Header("image of the circle")]
    public Image fillImage;

    [Header("speed the circle gets filled")]
    public float fillSpeed = 1.0f;

    [Header("all of the screws to the door")]
    [SerializeField] private GameObject[] screws;

    private Stack<GameObject> screwStack = new Stack<GameObject>();

    private bool inventoryHasScrewdriver = false;

    private float value = 0.0f;

    //amount of turns you are allowed to do
    private int amountOfTurns = 4;
    //keeps track of the amount of numbers that are in the stack to be used as string 
    private int stringNumbers = 0;
    //when value = 1 the player has enough screws to screw on the handel
    private int hasScrews = 0;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        screwStack.Push(screws[0]);
        screwStack.Push(screws[1]);
        screwStack.Push(screws[2]);
        screwStack.Push(screws[3]);
    }

    void Update()
    {
        CheckAmountOfScrews();

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.names[i] == "screw" && hasScrews == 1)
            {
                screws[0].SetActive(true);
                ActivateScrew();
            }

            if (inventory.names[i] == "screwdriver")
            {
                inventoryHasScrewdriver = true;
            }
        }

        if (inventoryHasScrewdriver && hasScrews == 1)
        {
            FillCircles();
        }
    }

    //fills the circle in when the player holds down the E button
    private void FillCircles()
    {
        if(value < 100.0f)
        {
            if (Input.GetKey(KeyCode.E) && amountOfTurns > 0)
            {
                value += fillSpeed * Time.deltaTime;
                TurnScrew();
            }
            else
            {
                value -= fillSpeed * Time.deltaTime;
                if (value <= 0)
                {
                    value = 0.0f;
                }
            }

           fillImage.fillAmount = value / 100;
        }
    }

    //activates the screw for the next hole
    private void ActivateScrew()
    {
        if(fillImage.fillAmount >= 1.0f)
        {
            if(screwStack != null)
            {
                screwStack.Pop().SetActive(true);

                inventory.DeleteItem("screw");

                stringNumbers = screwStack.Count;
                
                amountOfTurns--;

                fillImage.fillAmount = 0.0f;
                value = 0.0f;
            }
        }
    }

    //turns the screw that is active
    private void TurnScrew()
    {
        for (int i = 0; i < screws.Length; i++)
        {
            if(screws[i].name == "screw"+ stringNumbers.ToString())
            {
                screws[i].transform.Rotate(0, 0, -120 * Time.deltaTime);
            }
        }
    }

    //checks if the player has picked up all the screws and if so will change the value to 1
    private void CheckAmountOfScrews()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.names[i] == "screw" && inventory.itemCounter[i] == 4)
            {
                hasScrews = 1;
            }
        }
    }
}
