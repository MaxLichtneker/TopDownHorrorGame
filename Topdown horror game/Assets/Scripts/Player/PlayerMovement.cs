using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    idle = 0,
    moving = 1
}

public enum PlayerDirection
{
    up,
    down,
    left,
    right
}

public class PlayerMovement : MonoBehaviour
{
    [Header("direction the player is walking in")]
    public PlayerDirection playerDirection;

    public float xAxis;
    public float yAxis;

    private Vector3 speed;

    private GetOutOfChair getOutOfChair;

    [Header("Speed the player will go at")]
    [SerializeField] private float tileSpeed;

    [Header("Animator Controller of the player")]
    [SerializeField] private Animator animator;

    private void Start()
    {
        getOutOfChair = FindObjectOfType<GetOutOfChair>();
    }

    private void FixedUpdate()
    {
        GetAxis();

        if(SceneManager.sceneCount == 1)
        {
            SetSpeed();
        }

        speed = new Vector3(xAxis * tileSpeed, yAxis * tileSpeed);

        gameObject.GetComponent<Rigidbody2D>().velocity = speed;
    }

    public void GetAxis()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
    }

    private void SetSpeed()
    {
        if(getOutOfChair.playerBehaviour == PlayerBehaviour.sitting)
        {
            tileSpeed = 1.0f;
        }
        if(getOutOfChair.playerBehaviour == PlayerBehaviour.standing)
        {
            tileSpeed = 5.0f;
        }
    }

    private void SetAnimatorValues()
    {

    }

    private void SetAnimations()
    {

    }

}
