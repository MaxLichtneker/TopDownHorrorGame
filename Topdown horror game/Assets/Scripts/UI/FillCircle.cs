using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillCircle : MonoBehaviour
{
    [Header("image of the circle")]
    public Image fillImage;

    [Header("speed the circle gets filled")]
    public float fillSpeed = 1.0f;

    private float value = 0.0f;

    void Update()
    {
        FillCircles();
    }

    //fills the circle in when the player holds down the E button
    private void FillCircles()
    {
        if(value < 100.0f)
        {
            if (Input.GetKey(KeyCode.E))
            {
                value += fillSpeed * Time.deltaTime;
            }
            else
            {
                value -= fillSpeed * Time.deltaTime;

                if(value <= 0)
                {
                    value = 0.0f;
                }
            }

            fillImage.fillAmount = value / 100;
        }
    }
}
