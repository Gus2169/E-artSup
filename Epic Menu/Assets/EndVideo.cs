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
    public bool Menubool = true;

    [SerializeField] private AudioSource Dragonborn;
    [SerializeField] private AudioSource Skyrim;
    // Start is called before the first frame update
    void Start()
    {
        Skip.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SongIntro = false;
            VideoPlayer.gameObject.SetActive(false);
            Skyrim.Stop();
            Menu.gameObject.SetActive(true);
        }

        if (Input.anyKey)
        {
            StartCoroutine(skip());
        }

        if (SongIntro == false)
        {
            Dragonborn.Play();
        }

        if (VideoPlayer == false)
        {
            Dragonborn.Play();
            Menu.gameObject.SetActive(true);
        }
        


    }

    private void Awake()
     {  
        StartCoroutine(waiter());
     }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(56.25f);
        Object.Destroy(this.gameObject);
    }

    IEnumerator skip()
    {   
        Skip.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        Skip.gameObject.SetActive(false);
    }
    
    
}
