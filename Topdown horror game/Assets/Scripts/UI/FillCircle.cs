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

    [Header("all of the screws to the door")]
    [SerializeField] private GameObject[] screws;

    private Stack<GameObject> screwStack = new Stack<GameObject>();

    private float value = 0.0f;

    private int amountOfTurns = 4;
    private int stringNumbers = 0;

    private void Start()
    {
        screwStack.Push(screws[0]);
        screwStack.Push(screws[1]);
        screwStack.Push(screws[2]);
        screwStack.Push(screws[3]);
    }

    void Update()
    {
        FillCircles();

        ActivateScrew();
    }

    //fills the circle in when the player holds down the E button
    private void FillCircles()
    {
        if(value < 100.0f)
        {
            if (Input.GetKey(KeyCode.E) && amountOfTurns > 0)
            {
                value += fillSpeed * Time.deltaTime;
                TurnScrew();
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

    //activates the screw for the next hole
    private void ActivateScrew()
    {
        if(fillImage.fillAmount >= 1.0f)
        {
            if(screwStack != null)
            {
                screwStack.Pop().SetActive(true);
                stringNumbers = screwStack.Count;
                amountOfTurns--;
                fillImage.fillAmount = 0.0f;
                value = 0.0f;
            }
        }
    }

    //turns the screw that is active
    private void TurnScrew()
    {
        for (int i = 0; i < screws.Length; i++)
        {
            if(screws[i].name == "screw"+ stringNumbers.ToString())
            {
                screws[i].transform.Rotate(0, 0, -120 * Time.deltaTime);
            }
        }
    }

}
