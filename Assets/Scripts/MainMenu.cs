using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //Scene loader
    public void PlayGame()
    {
        SceneManager.LoadScene("Game"); //load game scene 
    }
    public void Shop() {
        SceneManager.LoadScene("Shop"); //load shop scene 
    }
    public void Menu(){
        SceneManager.LoadScene("MainMenu"); //load main menu scene 
    }
    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard"); //load leaderboard scene 
    }
    public void ChangeName()
    {
        SceneManager.LoadScene("PlayerName"); //load player name scene 
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls"); //load controls name scene 
    }
    public void QuitGame()
    {
        Application.Quit(); //exit out of game
    }
    
    
}
