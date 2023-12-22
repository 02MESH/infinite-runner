using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    /*Trigger function that will check whether if the truck has collided with the colliders,
    if it did, it will rotate the truck and will set it on the other lane for it to start 
    again.*/    
    void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;
        if(collidedObject.transform.parent != null && (other.gameObject.name == "rotateVehicleRight") || other.gameObject.name == "rotateVehicleLeft") { 
            Transform parentObject = collidedObject.transform.parent;
            Transform truckAndTrailer = parentObject.Find("truckAndTrailer");
            if(other.gameObject.name == "rotateVehicleRight") {
                leftToRight(truckAndTrailer);
            } else if(other.gameObject.name == "rotateVehicleLeft") {
                rightToLeft(truckAndTrailer);
            }
        }
    }

    //Left to right lane and rotation
    void leftToRight(Transform parentTransform) {
        float newXPosition = parentTransform.position.x + 3f;
        float currentYPosition = parentTransform.position.y;
        float currentZPosition = parentTransform.position.z - 4f;

        // Create a new Vector3 with the updated x position and the same y and z positions
        Vector3 newPosition = new Vector3(newXPosition, currentYPosition, currentZPosition);

        // Assign the new position to the Transform's position property
        parentTransform.position = newPosition;
        
        // parentTransform.position = new Vector3(17f,0f,18f);
        parentTransform.rotation = Quaternion.Euler(0f, -90f, 0f);
    }

    //Right to left lane and then rotation
    void rightToLeft(Transform parentTransform) {
        float newXPosition = parentTransform.position.x + 3f;
        float currentYPosition = parentTransform.position.y;
        float currentZPosition = parentTransform.position.z + 4f;

        // Create a new Vector3 with the updated x position and the same y and z positions
        Vector3 newPosition = new Vector3(newXPosition, currentYPosition, currentZPosition);

        // Assign the new position to the Transform's position property
        parentTransform.position = newPosition;

        parentTransform.rotation = Quaternion.Euler(0f, 90f, 0f);
    }
}