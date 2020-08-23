using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspect : MonoBehaviour
{
    [Header("popup text to inspects")]
    [SerializeField] private GameObject popUpText;

    [Header("doorImage GameObject")]
    [SerializeField] private GameObject doorImage;

    [SerializeField] private bool buttonPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && buttonPressed)
        {
            doorImage.SetActive(true);
        }
        else if(buttonPressed == false)
        {
            doorImage.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("door"))
        {
            popUpText.SetActive(true);
            buttonPressed = true;
        }
        else if(collision && buttonPressed == true)
        {
            popUpText.SetActive(false);
            buttonPressed = false;
        }
    }

}
