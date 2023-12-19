using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            Debug.Log("Player touched collider");
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();

                if (playerInventory != null)
                {
                    playerInventory.SaveCoins();  // Call SaveCoins from PlayerInventory
                }
                
                // Call the GameOver method on the PlayerMovement script
                player.GameOver();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
