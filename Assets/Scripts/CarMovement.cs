using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // public GameObject car;
    private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // car.transform.position = Vector.MoveTowards(car.transform.position, )
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
