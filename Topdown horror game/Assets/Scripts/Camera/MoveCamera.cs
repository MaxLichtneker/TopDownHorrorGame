using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public enum ActiveRoom
{
    kitchen,
    diningroom,
    livingroom,
    bedroom
}

public class MoveCamera : MonoBehaviour
{
    [Header("Which room the camera is currently in")]
    public ActiveRoom activeRoom;

    [Header("Camera GameObject")]
    [SerializeField] private GameObject camera;
    private Vector3 cameraStartPos;

    [Header("amount of units the camera has to move")]
    [SerializeField] private float addAmountRight;
    [SerializeField] private float addAmountUp;

    [Header("Fade image")]
    [SerializeField] Image image;

    private void Start()
    {
        cameraStartPos = camera.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Right"))
        {
            StartCoroutine(Fade());
            cameraStartPos = new Vector3(cameraStartPos.x + addAmountRight, cameraStartPos.y, cameraStartPos.z);
            camera.transform.position = cameraStartPos;
        }

        if (collision.CompareTag("Up"))
        {
            StartCoroutine(Fade());
            cameraStartPos = new Vector3(cameraStartPos.x, cameraStartPos.y + addAmountUp, cameraStartPos.z);
            camera.transform.position = cameraStartPos;
        }

        if (collision.CompareTag("Down"))
        {
            StartCoroutine(Fade());
            cameraStartPos = new Vector3(cameraStartPos.x, cameraStartPos.y - addAmountUp, cameraStartPos.z);
            camera.transform.position = cameraStartPos;
        }

        if (collision.CompareTag("Left"))
        {
            StartCoroutine(Fade());
            cameraStartPos = new Vector3(cameraStartPos.x - addAmountRight, cameraStartPos.y, cameraStartPos.z);
            camera.transform.position = cameraStartPos;
        }
    }

    private IEnumerator Fade()
    {
        image.DOFade(1.0f, 0.1f);

        yield return new WaitForSeconds(2f);

        image.DOFade(0.0f, 1f);
    }

}
