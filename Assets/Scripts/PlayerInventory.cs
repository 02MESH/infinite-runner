using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    //this is the key for the player pref 
    private const string TotalCoinsPrefsKey = "TotalPlayerCoins";


    // only want one instance of player inventory to share with all characters
    // makes sure only one instance is made if an instance exists is retrieves it 
    private static PlayerInventory _instance;

    public static PlayerInventory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerInventory>();
            }
            return _instance;
        }
    }

    private int totalCoins = 0;  // Total coins across all characters
    public Text coinsText;    //coins text on the screen

    private void Awake()
    {
        //loads all coins
        LoadCoins();
    }

    public void RemoveCoins(int amount)
    {
        //removes amount from total coins
        totalCoins -= amount;
        //saves coins 
        SaveCoins();
        //updates ui
        UpdateCoinsUI();
    }

    public void AddCoins(int amount)
    {
        //adds amount to total coins
        totalCoins += amount;
        //saves coins
        SaveCoins();
        //updates ui
        UpdateCoinsUI();
    }

    public void SaveCoins()
    {
        //sets  number of total coins 
        PlayerPrefs.SetInt(TotalCoinsPrefsKey, totalCoins);
        //saves amount of coins 
        PlayerPrefs.Save();  
    }

    public int GetTotalCoins()
    {
        //returns the number of coins
        return totalCoins;
    }

    public void LoadCoins()
    {
        //loads coins stored in the player pref key 
        totalCoins = PlayerPrefs.GetInt(TotalCoinsPrefsKey, 0);
        // update coins ui 
        UpdateCoinsUI();
    }

    public void UpdateCoinsUI()
    {
        //updates ui on players screen
        coinsText.text = "Coins: " + totalCoins;
    }
}
