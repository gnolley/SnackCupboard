using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationTablet : MonoBehaviour
{

    public GameObject[] screens;
    public float transitionTime;
    public float amountToMove;
    public float speed;
    public GameObject leftA;
    public GameObject rightA;

    int currentScreen;
    bool moving;
    Vector3 startPos;
    Vector3 newPos;
    float accumulationTime = 0;


    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if (moving)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, Time.deltaTime * speed);
            if (Vector3.Distance(transform.localPosition, newPos) < .1)
            {
                transform.localPosition = newPos;
                moving = false;
                for (int i = 0; i < screens.Length; i++)
                {
                    if (i != currentScreen)
                    {
                        screens[i].SetActive(false);
                    }
                }
            }
        }
    }

    public void MoveLeft()
    {
        if (currentScreen < screens.Length - 1)
        {
            currentScreen += 1;
            screens[currentScreen].SetActive(true);
            moving = true;
            newPos = new Vector3(amountToMove * currentScreen, 0, 0);
        }

        if (currentScreen == screens.Length - 1)
        {
            rightA.SetActive(false);
            leftA.SetActive(true);
        }
        else
        {
            rightA.SetActive(true);
            leftA.SetActive(true);
        }
    }

    public void MoveRight()
    {

        if (currentScreen > 0)
        {
            currentScreen -= 1;
            screens[currentScreen].SetActive(true);
            moving = true;
            newPos = new Vector3(amountToMove * currentScreen, 0, 0);
        }

        if (currentScreen == 0)
        {
            leftA.SetActive(false);
            rightA.SetActive(true);
        }
        else
        {
            leftA.SetActive(true);
            rightA.SetActive(true);
        }
    }

}
