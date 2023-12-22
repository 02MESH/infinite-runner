using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJumpCharacter : MonoBehaviour
{
 public float superJumpSpeed = 20f;
    public float superJumpElevation = 30f;
    public float superJumpDuration = 3f;
    public float cooldownDuration = 60f;

    private bool isSuperJumping = false;
    private float lastSuperJumpTime;

    private CharacterController characterController;
    private Vector3 originalPosition;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalPosition = transform.position;
        lastSuperJumpTime = -cooldownDuration;
    }

    private void Update()
    {
        // button to activate ability and checks if cooldown is up
        if (Input.GetKeyDown(KeyCode.W) && !isSuperJumping && Time.time - lastSuperJumpTime >= cooldownDuration)
        {
            // calls method
            StartSuperJump();
        }
        // checks to see if super jump is true
        if (isSuperJumping)
        {
            // call method
            SuperJump();
            //if time - last super jumptime is greater or equal to duration it stops the ability
            if (Time.time - lastSuperJumpTime >= superJumpDuration)
            {
                StopSuperJump();
            }
        }
    }

    private void StartSuperJump()
    {
        //jump is true and counts the last super jump time 
        isSuperJumping = true;
        lastSuperJumpTime = Time.time;
    }

    private void SuperJump()
    {
        // changes character vectors to make character jump 
        characterController.Move(Vector3.up * superJumpElevation * Time.deltaTime);
        Vector3 moveDirection = transform.forward * superJumpSpeed;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void StopSuperJump()
    {
        //chages character position to original position 
        isSuperJumping = false;
        transform.position = originalPosition;
    }
}
