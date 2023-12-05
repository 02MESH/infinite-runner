using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    //player starts with 0 coins
    private int coins = 0;
    public Text coinsText;
    public void AddCoins(int amount)
    {
        coins += amount;
        //Debug.Log("Coins: " + coins);
        //update coins UI 
        coinsText.text = "Coins: " + coins;
    }
}
