using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 50;
    // Update is called once per frame
    void Update()
    {
        //rotates coins
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0); 
    }
}
