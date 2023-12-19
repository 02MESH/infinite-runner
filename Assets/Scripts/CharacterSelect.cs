using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public int charIndex;
    public GameObject[] characters;


    void Start()
    {
        // gets the index of what character is selected 
        charIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        foreach (GameObject character in characters)
        {
            // hides characters that are not selected
            character.SetActive(false);
            // shows character what is selected
            characters[charIndex].SetActive(true);
        }
    }
}
