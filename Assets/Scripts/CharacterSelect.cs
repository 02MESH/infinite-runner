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
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        charIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
            characters[charIndex].SetActive(true);
        }
        newFollowTarget = characters[charIndex].transform;
        virtualCamera.Follow = newFollowTarget;
    }
}
