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
        entContainer = transform.Find("Container");
        entTemplate = entContainer.Find("EntryTemplate");

        entTemplate.gameObject.SetActive(false);
        // Remove the initialization code from the Awake method
    }

    public void UpdateTable(List<float> highScores)
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            Transform entryTransform = Instantiate(entTemplate, entContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -20f * i);

            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString = GetRankString(rank);
            entryTransform.Find("PositionText").GetComponent<Text>().text = rankString;

            float score = highScores[i];
            entryTransform.Find("ScoreText").GetComponent<Text>().text = Mathf.Round(score).ToString();

            // You may want to fetch player names from PlayerPrefs or some other source
            string name = "AAA";
            entryTransform.Find("NameText").GetComponent<Text>().text = name;
        }
    }

    private string GetRankString(int rank)
    {
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


