using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 3f;

    [SerializeField] Text CountDownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime-= 1 * Time.deltaTime;
        CountDownText.text = currentTime.ToString ("0");

        if (currentTime <= 0 )
        {
            currentTime = 0;
        }
    }
}
