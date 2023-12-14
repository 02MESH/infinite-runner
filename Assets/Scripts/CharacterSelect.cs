using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public int charIndex;
    public GameObject[] characters;


    void Start()
    {
        charIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
            characters[charIndex].SetActive(true);
        }
    }
}
