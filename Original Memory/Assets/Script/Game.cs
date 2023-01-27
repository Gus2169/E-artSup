using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    [SerializeField] List<Sprite> lstItem = new List<Sprite>();
    public List<Card> TurnedCards = new List<Card>();
    
    public GameObject[] Slot;
    public Card card;
    public Animator anim;
    public bool turnedInCode;
    public GameObject Text;
    public GameObject Gridboard;
    int paire  = 0;
    public static bool GameISFinish = false;
    public GameObject Finish;
    [SerializeField] private AudioSource Carte;
    [SerializeField] private AudioSource Paire;
    [SerializeField] private AudioSource Win;

    private void Awake()

    {
        Slot = GameObject.FindGameObjectsWithTag("Slot");
        
    }


    void Start()
    {
        Time.timeScale = 1f;
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
                        paire ++;
                        Debug.Log(paire); 
                        Paire.Play();
                        Carte.Play();                        
                    }
                    if (SceneManager.GetActiveScene().name == "Easy" && paire == 8)
                    {
                        Destroy(Gridboard);
                        Text.SetActive(false);
                        Finish.SetActive(true);
                        Win.Play();
                    }
                    if (SceneManager.GetActiveScene().name == "Medium" && paire == 12)
                    {
                        Destroy(Gridboard);
                        Text.SetActive(false);
                        Finish.SetActive(true);
                        Win.Play();
                    }
                    if (SceneManager.GetActiveScene().name == "Hard" && paire == 16)
                    {
                        Destroy(Gridboard);
                        Text.SetActive(false);
                        Finish.SetActive(true);
                        Win.Play();
                    }
                     
                }
                
                
            }
            

        }
         
    }

    IEnumerator Check()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator Matched()
    {
        Text.SetActive(true);
        yield return new WaitForSeconds(1.5f);
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

