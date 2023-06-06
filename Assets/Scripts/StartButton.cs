using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
     
    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void HowTo()
    {
        SceneManager.LoadScene("HowTo");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
