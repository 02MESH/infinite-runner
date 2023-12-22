/*Base class for car movement*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    private float speed = 5.0f;

    void Start() {    

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
