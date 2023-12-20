using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectible
{

    // Number of coins to add when collected
    public int coinsToAdd = 1;
    public AudioClip coinCollectSound;
    public override void ApplyEffect(Transform playerTransform)
    {
        // Add coins to the player's inventory or score
        playerTransform.GetComponent<PlayerInventory>().AddCoins(coinsToAdd);
        AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
        //PlayerInventory.Instance.SaveCoins();
        // Deactivate the collectible
        gameObject.SetActive(false);
    }
    void Update() {
        transform.Rotate(100 * Time.deltaTime, 0, 0);
    }
}

