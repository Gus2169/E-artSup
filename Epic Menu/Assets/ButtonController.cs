using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color active;
    public Color normal;
    public ButtonType type;
    public GameObject Fleche1;
    public GameObject Fleche2;
    public AudioSource newGameSound;
    public TextMeshProUGUI TextMeshPro;
      
    public enum ButtonType
    {
        NOUVEAU, CHARGER, CREDITS, QUITTER
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Fleche1.gameObject.SetActive(true);
        Fleche2.gameObject.SetActive(true);
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color=active;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Fleche1.gameObject.SetActive(false);
        Fleche2.gameObject.SetActive(false);
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color=normal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (type)
        {
            case ButtonType.NOUVEAU:
                newGameSound.Play();
                break;
            case ButtonType.CHARGER:
                Debug.Log("Charger");
                break;
            case ButtonType.CREDITS:
                Debug.Log("Credits");
                break;
            case ButtonType.QUITTER:
                Application.Quit();
                break;
        }
    }
    
}
