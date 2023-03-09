using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeMenu : MonoBehaviour
{

    public TextMeshProUGUI TextMeshPro;
    [SerializeField] private AudioSource MenuSound;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>() ;   //.color = Color.Lerp(Color.white, Color.green, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Return))
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        MenuSound.Play();
        DontDestroyOnLoad(MenuSound);
    }
}
