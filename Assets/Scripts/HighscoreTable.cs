using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighscoreTable : MonoBehaviour
{
    private Transform entContainer;
    private Transform entTemplate;

    private void Awake()
    {
        //finds both container and template in scene
        entContainer = transform.Find("Container");
        entTemplate = entContainer.Find("EntryTemplate");

        entTemplate.gameObject.SetActive(false);
        
    }

    public void UpdateTable(List<float> highScores)
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            //instantiate template and container for leaderboard 
            Transform entryTransform = Instantiate(entTemplate, entContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -20f * i);

            entryTransform.gameObject.SetActive(true);

            // rank is index + 1 
            int rank = i + 1;
            // gets the rank sting and displays it in the position text
            string rankString = GetRankString(rank);
            entryTransform.Find("PositionText").GetComponent<Text>().text = rankString;
            
            // gets the score and displays it in the score text
            float score = highScores[i];
            entryTransform.Find("ScoreText").GetComponent<Text>().text = Mathf.Round(score).ToString();

            // change this to take player prefs of name
            string name = PlayerPrefs.GetString("HighScoreName" + (i + 1), "");
            entryTransform.Find("NameText").GetComponent<Text>().text = name;
        }
    }

    private string GetRankString(int rank)
    {
        //for 1,2,3 it will return a unique pos name with the rest it takes the rank and adds th 
        switch (rank)
        {
            default:
                return rank + "TH";
            case 1: return "1ST";
            case 2: return "2ND";
            case 3: return "3RD";
        }
    }

}


