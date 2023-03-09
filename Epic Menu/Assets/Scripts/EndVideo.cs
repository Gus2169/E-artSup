using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndVideo : MonoBehaviour
{

    public TMP_Text Skip;
    public GameObject Menu;
    public GameObject VideoPlayer;
    public bool SongIntro = true;
    public bool SongMenu = false;
    public bool intro = true;

    [SerializeField] private AudioSource Dragonborn;
    [SerializeField] private AudioSource Skyrim;
    void Start()
    {
        Skip.gameObject.SetActive(false);
    }

    
    void Update()
    {
        
        if(intro == false)
        {
            DebMenu();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            FinIntro();
            DebMenu();
        }

        if (Input.anyKey)
        {
            StartCoroutine(skip());
        }

    }

    private void Awake()
     {  
        StartCoroutine(waiter());
     }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(56.24f);
        VideoPlayer.gameObject.SetActive(false);
        DebMenu();
    }

    IEnumerator skip()
    {   
        Skip.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        Skip.gameObject.SetActive(false);
    }

    public void FinIntro()
    {
        intro = false;
        SongIntro = false;
        Skyrim.Stop();
        VideoPlayer.gameObject.SetActive(false);
    }

    public void DebMenu()
    {
        Menu.gameObject.SetActive(true);
        Dragonborn.Play();
    }
}
