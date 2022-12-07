using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameISPaused = false;
    public GameObject pauseMenuUI;
    public CameraShake cameraShake;

    public GameManager gameManager;
    
    [SerializeField] private AudioSource JB_Hard;
    [SerializeField] private AudioSource BGM;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        { 
            if (GameISPaused)
            {
                Resume();
            }  else
            {
                Pause();
            }
        }
    }
    public void Resume ()
    {
        JB_Hard.UnPause();
        BGM.UnPause();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameISPaused = false;

    }

    void Pause ()
    {   
        
        JB_Hard.Pause();
        BGM.Pause();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameISPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

