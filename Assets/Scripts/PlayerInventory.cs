using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    //player starts with 0 coins
    private int coins = 0;
    public Text coinsText;

    private const string CoinsPrefsKey = "PlayerCoins";

    private static PlayerInventory _instance;

    public static PlayerInventory Instance
    {
        get
        {
            // Lazy initialization of the instance
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerInventory>();
            }
            return _instance;
        }
    }

    public void RemoveCoins(int amount)
    {
        coins -= amount;
        SaveCoins();
        UpdateCoinsUI();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        SaveCoins();
        UpdateCoinsUI();
    }

    private void SaveCoins()
    {
        // Save the current coins value to PlayerPrefs
        PlayerPrefs.SetInt(CoinsPrefsKey, coins);
    }

    public int GetCoins()  // Corrected method name
    {
        return coins;
    }

    public void LoadCoins()
    {
        // Load coins from PlayerPrefs
        coins = PlayerPrefs.GetInt(CoinsPrefsKey, 0);
    }

    private void UpdateCoinsUI()
    {
        //Debug.Log("Coins: " + coins);
        //update coins UI 
        coinsText.text = "Coins: " + coins;
    }
}
