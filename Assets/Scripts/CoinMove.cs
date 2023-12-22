/*Script used to manage the magnet ability of jackie once it's activated*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    Coins coinScript; //The coin script to get the transform of the coin
    bool isMagnetActive = false; //check whether if magnet is active or not
    float magnetDuration = 15f; //duration of the magnet ability
    float magnetCooldown = 60f; //cannot use magnet again for this long
    float currentCooldown = 0f; //count the current cooldown of the magnet ability
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
        if (isMagnetActive) //check whether if magnet is active
        {
            if (coinScript != null && coinScript.playerTransform != null) //check whether if the coinScript is selected or not
            {
                //Move the coin towards the player
                transform.position = Vector3.MoveTowards(transform.position, coinScript.playerTransform.position, coinScript.moveSpeed * Time.deltaTime);
                magnetDuration -= Time.deltaTime;

                if (magnetDuration <= 0f) //calculate the current time i.e. 15s, deactivate it after
                {
                    DeactivateMagnet();
                }
            }

        }
        //check the current cooldown time
        else if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
        }
        //check if the current selected character is jackie
        else if (Input.GetKeyDown(KeyCode.W)) {
            if (GameObject.FindGameObjectWithTag("characterSelect").GetComponent<CharacterSelect>().verifyJackie()) {
                ActivateMagnet();
            }
        }
    }

    //script to activate the magnet
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

    //deactivate the magnet
    void DeactivateMagnet()
    {
        isMagnetActive = false;
        transform.position = originalPosition;  // Reset the position to the original position

    }
}
