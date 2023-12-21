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
        // car.transform.position = Vector.MoveTowards(car.transform.position, )
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //AudioSource.PlayClipAtPoint(carSound, transform.position);
    }
}
