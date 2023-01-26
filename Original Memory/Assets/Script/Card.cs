using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Animator anim;
    public bool turnedInCode;
    public Sprite sprite;
    public bool matched;

    

    // Quand on clique
    public void OnMouseDown()
    {

        // On inverse la valeur de turned
        if (turnedInCode == false)
        {
            turnedInCode = true;
        }
      

        // On donne turned au bool de l'animator
        anim.SetBool("turned", turnedInCode);

        //Autre mani�re de l'�crire
        //turned = !turned;
        //anim.SetBool("turned", turned);
    }
}
