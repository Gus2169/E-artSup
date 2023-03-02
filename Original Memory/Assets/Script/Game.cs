using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    [SerializeField] List<Sprite> lstItem = new List<Sprite>();
    public List<Card> TurnedCards = new List<Card>();
    
    public GameObject[] Slot;
    public Card card;
    public Animator anim;
    public bool turnedInCode;

    private void Awake()

    {
        Slot = GameObject.FindGameObjectsWithTag("Slot");
        
    }


    void Start()
    {
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            if (TurnedCards.Count >= 2)
            {
             foreach (Card TurnedCard in TurnedCards)
                {
                    TurnedCard.GetComponent<Animator>().SetBool("turned", false);
                }

                TurnedCards.Clear();

            }
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Card card = hit.collider.GetComponent<Card>();
                if (card.matched)
                {
                    return;
                }
                    TurnedCards.Add(card);
                

                if (TurnedCards.Count == 2)
                {
                    if (TurnedCards[0].sprite==TurnedCards[1].sprite)
                    {
                        TurnedCards[0].matched = true;
                        TurnedCards[1].matched = true;
                        TurnedCards.Clear();
                    }
                     
                }
                
                   
                
            }


        }
         
    }

    private void Shuffle()
    {
        List<Sprite> lstTemp = lstItem;
        lstTemp.AddRange(lstItem);

        for (int i = 0; i < Slot.Length; i++)
        {
            int rnd = Random.Range(0, lstTemp.Count);
            SpriteRenderer target = Slot[i].transform.Find("Spooky front").GetComponent<SpriteRenderer>();
            target.sprite = lstTemp[rnd];
            lstTemp.RemoveAt(rnd);
            target.enabled = true;

            Slot[i].GetComponent<Card>().sprite=target.sprite;

        }
    }
  


}

