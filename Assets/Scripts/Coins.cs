using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectible
{
    public Transform playerTransform;
    public float moveSpeed = 10f;
    // Number of coins to add when collected
    public int coinsToAdd = 1;
    public AudioClip coinCollectSound;
    CoinMove coinMoveScript;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("characterSelect").GetComponent<CharacterSelect>().getTransform();
        coinMoveScript = gameObject.GetComponent<CoinMove>();
    }

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

