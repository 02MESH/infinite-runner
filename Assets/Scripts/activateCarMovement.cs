using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateCarMovement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider's GameObject has a transform parent and a grandparent
        if (other.CompareTag("Player")) {
            
            if(other.transform.parent != null && other.transform.parent.parent != null) {
    
            // Access the grandmother GameObject
            GameObject grandmother = other.transform.parent.parent.gameObject;

            // Do something with the grandmother GameObject
            if (grandmother != null)
            {
                Debug.Log("Grandmother's name: " + grandmother.name);
                // You can perform operations on the grandmother GameObject here
            }
            else
            {
                Debug.LogWarning("Grandmother GameObject is null.");
            }
        }
        else
        {
            Debug.LogWarning("Collider's parent or grandparent is null or not available.");
        }
            }
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     // Check if the player collided with the Box Collider (or specific GameObject)
    //     if (other.CompareTag("Player")) {
    //         //Get the GameObject with the script you want to activate
    //         GameObject car = GameObject.FindWithTag("collisionCar");

    //         if (car != null)
    //         {
    //             // // Get the script attached to the specific GameObject
    //             CarMovement script = car.GetComponent<CarMovement>();

    //             if (script != null) {
    //                 // Activate or enable the script
    //                 Debug.Log("Sausage");
    //                 script.enabled = true;
    //                 Debug.Log("Activated Script");
    //             } else {
    //                 Debug.LogWarning("Script not found on the specific GameObject.");
    //             }
    //         }
    //         else {
    //             Debug.LogWarning("GameObject not found.");
    //         }
    //     }
    // }
}
