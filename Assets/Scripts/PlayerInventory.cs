using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //player starts with 0 coins
    private int coins = 0;

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);
        // You can also update a UI element to display the current number of coins
    }
}
