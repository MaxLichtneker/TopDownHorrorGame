using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasementMovement : MonoBehaviour
{
    public float xAxis;
    public float yAxis;

    private Vector3 speed;

    [Header("Speed the player will go at")]
    [SerializeField] private float tileSpeed;

    [Header("Animator Controller of the player")]
    [SerializeField] private Animator animator;

    private void FixedUpdate()
    {
        GetAxis();
        speed = new Vector3(xAxis * tileSpeed, yAxis * tileSpeed);
        StartCoroutine(Delay());
        gameObject.GetComponent<Rigidbody2D>().velocity = speed;
    }

    public void GetAxis()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
    }

}
