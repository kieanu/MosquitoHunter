using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//씬불러오기

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    public void PauseButton()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        AudioListener.volume = 1f;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    void Pause()
    {
        AudioListener.volume = 0f;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        isPaused = false;
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");//메인메뉴로전환
    }

    
}
