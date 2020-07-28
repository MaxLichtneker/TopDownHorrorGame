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

    public bool Sitting = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerBehaviour == PlayerBehaviour.sitting)
        {
            Walk();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && playerBehaviour == PlayerBehaviour.standing)
        {
            GetBackInChair();
        }
    }
    
    private void Walk()
    {
        chair.transform.parent = null;
        playerBehaviour = PlayerBehaviour.standing;
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

            if(Input.GetKeyDown(KeyCode.Space) && playerBehaviour == PlayerBehaviour.standing)
            {
                playerBehaviour = PlayerBehaviour.sitting;
            }
            else
            {
                playerBehaviour = PlayerBehaviour.standing;
            }
        }           
    }
}
