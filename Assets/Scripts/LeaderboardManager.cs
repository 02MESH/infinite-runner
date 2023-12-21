using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LeaderboardManager : MonoBehaviour
{
    public Text[] scoreTexts;

    void Start()
    {
        DisplayLeaderboard();
    }
    void SetNewHighScore(float newScore, string playerName)
    {
        // Set a new high score and update the PlayerPrefs
        for (int i = 1; i <= 10; i++)
        {
            float score = PlayerPrefs.GetFloat("HighScore" + i, 0f);
            
            if (newScore > score)
            {
                // Shift scores down to make room for the new high score
                for (int j = 10; j > i; j--)
                {
                    float tempScore = PlayerPrefs.GetFloat("HighScore" + (j - 1), 0f);
                    PlayerPrefs.SetFloat("HighScore" + j, tempScore);

                    string tempName = PlayerPrefs.GetString("NameForHighScore" + (j - 1), "");
                    PlayerPrefs.SetString("NameForHighScore" + j, tempName);
                }

                PlayerPrefs.SetFloat("HighScore" + i, newScore);
                PlayerPrefs.SetString("NameForHighScore" + i, playerName);
                break; // Exit the loop after updating the leaderboard
            }
        }
    }

    public void DisplayLeaderboard()
    {
        // Retrieve and display the top 10 scores
        List<float> highScores = new List<float>();
        List<string> playerNames = new List<string>();
        for (int i = 1; i <= 10; i++)
        {
            float score = PlayerPrefs.GetFloat("HighScore" + i, 0f);
            highScores.Add(score);
            //scoreTexts[i - 1].text = i + ". " + Mathf.Round(score);
            string name = PlayerPrefs.GetString("name", "none");
            //playerNames.Add(name);
            //string name = PlayerPrefs.GetString("NameForHighScore" + i, "");
            playerNames.Add(name);
        }

        FindObjectOfType<HighscoreTable>().UpdateTable(highScores, playerNames);
    }

 
}
