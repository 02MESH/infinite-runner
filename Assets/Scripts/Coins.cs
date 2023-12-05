using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectible
{

    // Number of coins to add when collected
    public int coinsToAdd = 1;

    public override void ApplyEffect(Transform playerTransform)
    {
        // Add coins to the player's inventory or score
        playerTransform.GetComponent<PlayerInventory>().AddCoins(coinsToAdd);

        // Deactivate the collectible
        gameObject.SetActive(false);
    }

}

