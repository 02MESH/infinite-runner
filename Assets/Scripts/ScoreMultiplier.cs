using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : Collectible
{
    //how much score is multiplied by
    public float ScoreMultiplierValue = 2.0f;
    // duration of the collectible
    public float duration = 10.0f;

    public AudioClip collectSound;

    public override void ApplyEffect(Transform playerTransform)
    {
        // Get the PlayerMovement component from the player
        PlayerMovement playerMovement = playerTransform.GetComponent<PlayerMovement>();

        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        if (playerMovement != null)
        {
            // Apply the score multiplier to the player's score increase rate
            playerMovement.ApplyScoreMultiplier(ScoreMultiplierValue, duration);
        }

        // Deactivate the collectible
        gameObject.SetActive(false);
    }
}
