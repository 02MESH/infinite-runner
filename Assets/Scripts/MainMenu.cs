using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //Scene loader
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
    public void ChangeName()
    {
        SceneManager.LoadScene("PlayerName");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    
}
