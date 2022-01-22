using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public void M_Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void G_PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
    public void G_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void M_Quit()
    {
        Application.Quit();
    }
}
