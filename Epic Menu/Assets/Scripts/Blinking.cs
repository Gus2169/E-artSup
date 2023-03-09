using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

 
public class Blinking : MonoBehaviour
{
    TextMeshProUGUI flashingText;
    string textToBlink;
    public float BlinkTime;
 
     void Start()
    {
        flashingText = GetComponent<TextMeshProUGUI>();
        textToBlink = flashingText.text;
        BlinkTime = 0.7f;
        StartCoroutine(BlinkText());
    }
 
 
 
 
    IEnumerator BlinkText()
    {
        while (true)
        {
            flashingText.text = textToBlink;
            yield return new WaitForSeconds(BlinkTime);
            flashingText.text = string.Empty;
            yield return new WaitForSeconds(BlinkTime);
        }
    }
}