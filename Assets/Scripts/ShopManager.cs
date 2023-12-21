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
        //get instance of player inventory
        PlayerInventory playerInventory = PlayerInventory.Instance;
        //load coins from player inventory 
        playerInventory.LoadCoins();
        //update ui for coins from player inventory 
        playerInventory.UpdateCoinsUI();

        // looks at all the variables in characterBp 
        foreach (CharacterBp character in charsBp){
            if (character.price == 0) //if price is 0 
            {
                character.isUnlocked = true; //character is unlocked
            }
            else {
                int isUnlockedValue = PlayerPrefs.GetInt(character.name, 0); 
                character.isUnlocked = isUnlockedValue == 1; // Assuming 1 means unlocked, 0 means locked
            }

        }
        charIndex = PlayerPrefs.GetInt("SelectedChar", 0); // gets index of selected character from array
        //sets playable character to whats selected in the shop menu and keeps the others hidden
        foreach (GameObject character in characterModels) {
            character.SetActive(false);

            characterModels[charIndex].SetActive(true); // sets character model at charindex that is selected as active 
        }       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void nextChar() {
        //sets character models inactive if if its not in view e.g scroll to second character the 1st and 3rd one wont be displayed
        characterModels[charIndex].SetActive(false);
        // move along the array
        charIndex++;
        // if the scroll reaches the end make index go to 0 to see first character again
        if (charIndex == characterModels.Length)
        {
            charIndex = 0;
        }
        //display the character when player clicks arrow in shop 
        characterModels[charIndex].SetActive(true);
        CharacterBp ch = charsBp[charIndex];
        //if character is not unlocked do nothing 
        if (!ch.isUnlocked) {
            return;
            
        }
        //set the selected character to the one thats visible when exiting the shop
        PlayerPrefs.SetInt("SelectedChar", charIndex);
    }

    public void prevChar()
    {
        //sets character models inactive if if its not in view e.g scroll to second character the 1st and 3rd one wont be displayed
        characterModels[charIndex].SetActive(false);
        // move along the array backwards 
        charIndex--;
        //will go to the end character in the array 
        if (charIndex == -1)
        {
            charIndex = characterModels.Length -1;
        }
        //display the character when player clicks arrow in shop 
        characterModels[charIndex].SetActive(true);
        CharacterBp ch = charsBp[charIndex];
        //if character is not unlocked do nothing 
        if (!ch.isUnlocked)
        {
            return;
            
        }
        //set the selected character to the one thats visible when exiting the shop
        PlayerPrefs.SetInt("SelectedChar", charIndex);
    }

    private void UpdateUI() {
        CharacterBp ch = charsBp[charIndex];
        // if character is unlocked it gets rid of the buy button
        if (ch.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            //buy button can be seen and displays the price thats grabbed from the values set in charsBp
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy -" + ch.price;

            // Use PlayerInventory to check coins if enough coins player can buy if not then the player cant  buy it 
            if (ch.price < PlayerInventory.Instance.GetTotalCoins())  
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
        //when character is unlocked it removes the cost of the character from player inventory coins
        PlayerInventory.Instance.RemoveCoins(ch.price);
        //saves the new amount of coins
        PlayerInventory.Instance.SaveCoins();
        // sets integer of what the selected character is in the array 
        PlayerPrefs.SetInt(ch.name, 1);
        PlayerPrefs.SetInt("SelectedChar", charIndex);
        //once brought it sets unlocked to true
        ch.isUnlocked = true;
    }
}