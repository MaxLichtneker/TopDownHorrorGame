using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOutOfChair : MonoBehaviour
{
    [Header("GameObject of the chair the player sits in")]
    [SerializeField] private GameObject chair;

    public bool Sitting = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Sitting == true)
        {
            Walk();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Sitting == false)
        {
            GetBackInChair();
        }
    }
    
    private void Walk()
    {
        chair.transform.parent = null;
        Sitting = false;
    }

    private void GetBackInChair()
    {
        gameObject.transform.position = chair.transform.position;
        chair.transform.SetParent(gameObject.transform);
        Sitting = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("chair"))
        {

            if(Input.GetKeyDown(KeyCode.Space) && Sitting == false)
            {
                Sitting = true;
            }
            else
            {
                Sitting = false;
            }
        }           
    }
}
