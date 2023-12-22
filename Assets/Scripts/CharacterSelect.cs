/*Script that sets the characters for the game in the shop, also sets the
cinmachine virtual camera object that will follow the player object.*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSelect : MonoBehaviour
{
    public int charIndex; //0 - Michelle, 1 - Jackie, 2 - Zomboy
    public GameObject[] characters; //Array of character gameobjects
    public CinemachineVirtualCamera virtualCamera; // Reference to the Cinemachine Virtual Camera
    public Transform newFollowTarget; //Transform position of the character to the virtual camera

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

    //Get the transform of the current character
    public Transform getTransform() {
        int characterIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        return characters[characterIndex].transform;
    }

    //Get the verification whether if Jackie is selected or not
    public bool verifyJackie() {
        int characterIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        return characterIndex == 1;
    }
}
