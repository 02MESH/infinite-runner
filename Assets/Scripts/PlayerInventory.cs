using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    private const string TotalCoinsPrefsKey = "TotalPlayerCoins";

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
    public Text coinsText;

    private void Awake()
    {
        LoadCoins();
    }

    public void RemoveCoins(int amount)
    {
        totalCoins -= amount;
        SaveCoins();
        UpdateCoinsUI();
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        SaveCoins();
        UpdateCoinsUI();
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt(TotalCoinsPrefsKey, totalCoins);
        PlayerPrefs.Save();  
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }

    public void LoadCoins()
    {
        totalCoins = PlayerPrefs.GetInt(TotalCoinsPrefsKey, 0);
        UpdateCoinsUI();
    }

    public void UpdateCoinsUI()
    {
        coinsText.text = "Coins: " + totalCoins;
    }
}
