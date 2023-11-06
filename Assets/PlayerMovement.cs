using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float[] xPos;
    int xPosIndex = 1;
    public float speed = 5f;
    public float floorHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        //+= transform.forward * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPos[xPosIndex], floorHeight, transform.position.z + 1), Time.deltaTime * speed);
    }

    void MoveLeft() {
        xPosIndex--;
        if (xPosIndex < 0) {
            xPosIndex = 0;
        }
    }
    void MoveRight()
    {
        xPosIndex++;
        if (xPosIndex > xPos.Length - 1)
        {
            xPosIndex = xPos.Length - 1;
        }
    }
}
