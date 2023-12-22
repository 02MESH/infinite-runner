using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateCarMovement : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with the Box Collider (or specific GameObject)
        if (other.CompareTag("Player")) {
            //Get the GameObject with the script you want to activate
            GameObject car = GameObject.FindWithTag("collisionCar");

            if (car != null)
            {
                // // Get the script attached to the specific GameObject
                CarMovement script = car.GetComponent<CarMovement>();

                if (script != null) {
                    // Activate or enable the script
                    Debug.Log("Sausage");
                    script.enabled = true;
                } else {
                    Debug.LogWarning("Script not found on the specific GameObject.");
                }
            }
            else {
                Debug.LogWarning("GameObject not found.");
            }
        }
    }
}
