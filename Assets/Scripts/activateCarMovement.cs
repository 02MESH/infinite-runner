/*Used to activate the carMovement script which is a child of vehicleMovement
that activates it when the character reaches to the junction.*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateCarMovement : MonoBehaviour {

    //Once the player object interacts with the box collider, do this.
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
                    Debug.Log("Activated Script");
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
