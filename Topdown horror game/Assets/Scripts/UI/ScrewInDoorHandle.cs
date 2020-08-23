using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HandleState
{
    handleOff,
    handleOn,
}


public class ScrewInDoorHandle : MonoBehaviour
{
    private Inventory inventory;

    [Header("state of the handle")]
    private HandleState handleState;

    [Header("GameObject of the doorHandle Image")]
    [SerializeField] private GameObject doorHandle;



    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        CheckNames();

        InsertScrews();   
    }

    private void CheckNames()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(inventory.names[i] == "doorHandel")
                {
                    doorHandle.SetActive(true);
                    handleState = HandleState.handleOn;

                }
            }
        }
    }

    private void InsertScrews()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if(handleState == HandleState.handleOn && inventory.names[i] == "screwDriver")
            {
                if(inventory.itemCounter[i] > 0 && inventory.names[i] == "screw")
                {

                }
            }
        }
    }

}
