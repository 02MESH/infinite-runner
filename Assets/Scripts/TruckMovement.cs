using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    private bool leftLane = false;

    void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;
        if(collidedObject.transform.parent != null && (other.gameObject.name == "rotateVehicleRight") || other.gameObject.name == "rotateVehicleLeft") { 
            Transform parentObject = collidedObject.transform.parent;
            Transform truckAndTrailer = parentObject.Find("truckAndTrailer");
            //Debug.Log(collidedObject.transform.parent.gameObject.name);
            //Debug.Log(truckAndTrailer);
            if(other.gameObject.name == "rotateVehicleRight") {
                //Debug.Log("Right Switch");
                leftToRight(truckAndTrailer);
            } else if(other.gameObject.name == "rotateVehicleLeft") {
                //Debug.Log("Left switch");
                rightToLeft(truckAndTrailer);
            }
        }
    }

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
