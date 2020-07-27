using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToRoom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Right"))
        {
            StartCoroutine(DelayRight());
        }
        if (collision.CompareTag("Left"))
        {
            StartCoroutine(DelayLeft());
        }
        if (collision.CompareTag("Up"))
        {
            StartCoroutine(DelayUp());
        }
        if (collision.CompareTag("Down"))
        {
            StartCoroutine(DelayDown());
        }
    }

    private IEnumerator DelayRight()
    {
        yield return new WaitForSeconds(2f);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + 13f, gameObject.transform.position.y);
    }
    private IEnumerator DelayLeft()
    {
        yield return new WaitForSeconds(2f);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - 13f, gameObject.transform.position.y);
    }

    private IEnumerator DelayUp()
    {
        yield return new WaitForSeconds(2f);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 7f);
    }

    private IEnumerator DelayDown()
    {
        yield return new WaitForSeconds(2f);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 7f);
    }
}
