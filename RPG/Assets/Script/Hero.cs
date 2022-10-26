using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public int healthPlayer;
    public int healthEnnemy;
    public string characterName;
    public GameObject ennemy;
    public GameObject objectToInstanttiate;
    public GameObject player;

    public void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            healthEnnemy --;

            if(healthEnnemy == 0)
            {
                Debug.Log("Ennemi est mort");
                Destroy(ennemy);
            }
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(objectToInstanttiate, player.transform.position, Quaternion.identity);
        }

    }

}
