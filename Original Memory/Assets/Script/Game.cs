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
    public GameObject Text;
    [SerializeField] private AudioSource Carte;

    private void Awake()

    {
        Slot = GameObject.FindGameObjectsWithTag("Slot");
        
    }


    void Start()
    {
        Shuffle();
        Text.SetActive(false);
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
                    Carte.Play();
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
                    Carte.Play();
                

                if (TurnedCards.Count == 2)
                {
                    if (TurnedCards[0].sprite==TurnedCards[1].sprite)
                    {
                        TurnedCards[0].matched = true;
                        TurnedCards[1].matched = true;
                        TurnedCards.Clear();
                        StartCoroutine(Matched());
                        Carte.Play();                        
                    }
                     
                }
                
                   
                
            }


        }
         
    }
    IEnumerator Matched()
    {
        Text.SetActive(true);
        yield return new WaitForSeconds(1);
        Text.SetActive(false);
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

