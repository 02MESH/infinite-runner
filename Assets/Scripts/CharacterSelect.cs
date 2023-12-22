using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSelect : MonoBehaviour
{
    public int charIndex;
    public GameObject[] characters;
    public CinemachineVirtualCamera virtualCamera; // Reference to your Cinemachine Virtual Camera
    public Transform newFollowTarget;

    void Start()
    {
        //finds virtual camera 
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        //retrieves character at index in player prefs 
        charIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        //iterate through each character in the array 
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
            characters[charIndex].SetActive(true); //activates selected character
        }
        newFollowTarget = characters[charIndex].transform; // assigns the follow target 
        virtualCamera.Follow = newFollowTarget; //makes camera follow selected character
    }

    public Transform getTransform() {
        int characterIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        return characters[characterIndex].transform;
    }
}
