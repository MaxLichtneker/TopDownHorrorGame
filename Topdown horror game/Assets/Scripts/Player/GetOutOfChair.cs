using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerBehaviour
{
    sitting,
    standing
}

public class GetOutOfChair : MonoBehaviour
{
    [Header("checks if the player is sitting down or not")]
    public PlayerBehaviour playerBehaviour;

    [Header("GameObject of the chair the player sits in")]
    [SerializeField] private GameObject chair;

    //checks if the player is colliding with the chair or not
    [SerializeField]private bool colliding;

    void Update()
    {
        //if the player presses space and the player is sitting then the player will get out of the chair
        if (Input.GetKeyDown(KeyCode.Space) && playerBehaviour == PlayerBehaviour.sitting)
        {
            Walk();
        }
        
        //if the player presses space while he is colliding with the chair he wil get back in the chair
        if (Input.GetKeyDown(KeyCode.Space) && colliding == true)
        {
            GetBackInChair();
        }
    }

    private void Walk()
    {
        chair.transform.parent = null;
        playerBehaviour = PlayerBehaviour.standing;
        colliding = false;
    }

    private void GetBackInChair()
    {
        gameObject.transform.position = chair.transform.position;
        chair.transform.SetParent(gameObject.transform);
        playerBehaviour = PlayerBehaviour.sitting;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("chair"))
        {
            colliding = true;
        }
        else
        {
            colliding = false;
        }
    }
}
