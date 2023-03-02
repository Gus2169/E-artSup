using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color active;
    public Color normal;
    public ButtonType type;
    public AudioSource newGameSound;

    public enum ButtonType
    {
        NEW, LOAD, CREDITS, QUIT
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Text>().color = active;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Text>().color = normal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (type)
        {
            case ButtonType.NEW:
                newGameSound.Play();
                break;
            case ButtonType.LOAD:
                Debug.Log("load scene");
                break;
            case ButtonType.CREDITS:
                Debug.Log("go to credits");
                break;
            case ButtonType.QUIT:
                Application.Quit();
                break;
        }
    }
    
}
