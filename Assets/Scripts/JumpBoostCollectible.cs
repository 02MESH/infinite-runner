using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostCollectible : Collectible
{
    //how much jump is multiplied by
    public float jumpBoostMultiplier = 2.0f;
    // duration of the collectible
    public float duration = 10.0f;
    public AudioClip collectSound; //audio clip
    public override void ApplyEffect(Transform playerTransform)
    {
        //play audio clip 
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        // Apply the jump boost effect to the player
        playerTransform.GetComponent<PlayerMovement>().ApplyJumpBoost(jumpBoostMultiplier, duration);

        // Deactivate the collectible
        gameObject.SetActive(false);
    }
}
