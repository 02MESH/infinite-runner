using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public int charIndex;
    public GameObject[] characterModels;


    void Start()
    {
        charIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        foreach (GameObject character in characterModels) {
            character.SetActive(false);

            characterModels[charIndex].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextChar() {
        characterModels[charIndex].SetActive(false);

        charIndex++;
        if (charIndex == characterModels.Length)
        {
            charIndex = 0;
        }

        characterModels[charIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedChar", charIndex);
    }

    public void prevChar()
    {
        characterModels[charIndex].SetActive(false);

        charIndex--;
        if (charIndex == -1)
        {
            charIndex = characterModels.Length -1;
        }

        characterModels[charIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedChar", charIndex);
    }
}
