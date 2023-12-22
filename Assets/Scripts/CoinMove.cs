using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    Coins coinScript;
    bool isMagnetActive = false;
    float magnetDuration = 15f;
    float magnetCooldown = 60f;
    float currentCooldown = 0f;
    Vector3 originalPosition;  // Store the original position of the coin

    // Start is called before the first frame update
    void Start()
    {
        coinScript = gameObject.GetComponent<Coins>();
        originalPosition = transform.position;  // Store the original position at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (isMagnetActive)
        {
            if (coinScript != null && coinScript.playerTransform != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, coinScript.playerTransform.position, coinScript.moveSpeed * Time.deltaTime);
                magnetDuration -= Time.deltaTime;

                if (magnetDuration <= 0f)
                {
                    DeactivateMagnet();
                }
            }

        }
        else if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            ActivateMagnet();
        }
    }

    void ActivateMagnet()
    {
        CoinMove coinMoveScript = gameObject.GetComponent<CoinMove>();
        if (coinMoveScript != null && !isMagnetActive && currentCooldown <= 0f)
        {
            isMagnetActive = true;
            magnetDuration = 15f;
            originalPosition = transform.position;  // Store the current position as the original position

            currentCooldown = magnetCooldown;
        }
    }

    void DeactivateMagnet()
    {
        isMagnetActive = false;
        transform.position = originalPosition;  // Reset the position to the original position

    }
}
