using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");

    }

    public void Shop() {
        SceneManager.LoadScene("Shop");
    }
    public void Menu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    
}
