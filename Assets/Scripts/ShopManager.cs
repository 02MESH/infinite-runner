using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopManager : MonoBehaviour
{

    public int charIndex;
    public GameObject[] characterModels;

    public CharacterBp[] charsBp;
    public Button buyButton;

    void Start()
    {
        foreach(CharacterBp character in charsBp){
            if (character.price == 0)
            {
                character.isUnlocked = true;
            }
            else {
                int isUnlockedValue = PlayerPrefs.GetInt(character.name, 0);
                character.isUnlocked = isUnlockedValue == 1; // Assuming 1 means unlocked, 0 means locked
            }

        }
        charIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        foreach (GameObject character in characterModels) {
            character.SetActive(false);

            characterModels[charIndex].SetActive(true);
        }

        PlayerInventory.Instance.LoadCoins();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void nextChar() {
        characterModels[charIndex].SetActive(false);

        charIndex++;
        if (charIndex == characterModels.Length)
        {
            charIndex = 0;
        }

        characterModels[charIndex].SetActive(true);
        CharacterBp ch = charsBp[charIndex];
        if (!ch.isUnlocked) {
            return;
            
        }
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
        CharacterBp ch = charsBp[charIndex];
        if (!ch.isUnlocked)
        {
            return;
            
        }
        PlayerPrefs.SetInt("SelectedChar", charIndex);
    }

    private void UpdateUI() {
        CharacterBp ch = charsBp[charIndex];

        if (ch.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy -" + ch.price;

            // Use PlayerInventory to check coins
            if (ch.price < PlayerInventory.Instance.GetCoins())  // Corrected method name
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }
    }

    public void unlockCharacter() {
          CharacterBp ch = charsBp[charIndex];

    // Use PlayerInventory to deduct coins
    PlayerInventory.Instance.RemoveCoins(ch.price);

    PlayerPrefs.SetInt(ch.name, 1);
    PlayerPrefs.SetInt("SelectedChar", charIndex);
    ch.isUnlocked = true;
    }
}
