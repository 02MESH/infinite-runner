using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float[] xPos;
    int xPosIndex = 1;
    public float speed = 5f;
    public float floorHeight;

    private Rigidbody rb;

    public Vector3 jump;
    public float jumpForce = 2.8f;
    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    //when trigger collision happens
    void OnTriggerEnter(Collider other)
    {
        //if the other object entering our trigger zone
        //has a tag called "Pick Up"
        //if (other.gameObject.CompareTag("Pick Up"))
        //{
        //deactivat the other object
        //other.gameObject.SetActive(false);
        //}
        
        //calls the collectible script
        Collectible collectible = other.GetComponent<Collectible>();

            if (collectible != null)
            {
                // Call the ApplyEffect method for the specific collectible
                collectible.ApplyEffect(transform);
            }
       
    }

    // Actually applying jumpboost to the player from the method in the jumpboost collectible script
    public void ApplyJumpBoost(float multiplier, float duration)
    {
        StartCoroutine(JumpBoostCoroutine(multiplier, duration));
    }

    // after applying the boost it waits 10s and returns back to original jump force
    IEnumerator JumpBoostCoroutine(float multiplier, float duration)
    {
        float originalJumpForce = jumpForce;

        // Apply the jump boost
        jumpForce *= multiplier;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Reset the jump force to its original value
        jumpForce = originalJumpForce;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
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
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
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
