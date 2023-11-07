using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; //the moving speed
    //this holds the rigidbody component of the object
    private Rigidbody rb;

    public Vector3 jump;
    public float jumpForce = 2.8f;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //get horizontal movement, left = -1, right = 1
        float moveHorizontal = Input.GetAxis("Horizontal");
        //get horizontal movement, down = -1, up = 1
        float moveVertical = Input.GetAxis("Vertical");

        //create a vector3 variable to store the x,y,z movement values
        Vector3 movement = new  Vector3(moveHorizontal, 0.0f, moveVertical);

        //add the movement values to the rigidbody
        rb.AddForce(movement *speed);
    }

    //when trigger collision happens
    void OnTriggerEnter(Collider other)
    {
        //if the other object entering our trigger zone
        //has a tag called "Pick Up"
        if (other.gameObject.CompareTag ("Pick Up"))
        {
        //deactivat the other object
            other.gameObject.SetActive (false);
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "ground") {
            isGrounded = true;
        }
    }

    //Update is called once per frame
    void Update() {
        if (isGrounded) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }
}
