using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    private bool leftLane = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "rotateVehicleRight")
        {
            Debug.Log("Enter");
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
    }
}
