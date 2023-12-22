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
    private float currentSuperJumpTime = 0f;

    private CharacterController characterController;
    private Vector3 originalPosition;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isSuperJumping)
        {
            StartSuperJump();
        }

        if (isSuperJumping)
        {
            SuperJump();

            currentSuperJumpTime += Time.deltaTime;

            if (currentSuperJumpTime >= superJumpDuration)
            {
                StopSuperJump();
            }
        }
    }

    private void StartSuperJump()
    {
        isSuperJumping = true;
        currentSuperJumpTime = 0f;
    }

    private void SuperJump()
    {
        // Elevate the character
        characterController.Move(Vector3.up * superJumpElevation * Time.deltaTime);

        // Move the character forward
        Vector3 moveDirection = transform.forward * superJumpSpeed;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void StopSuperJump()
    {
        isSuperJumping = false;

        // Reset the character's position to the original position
        transform.position = originalPosition;

        // Cooldown before the character can super jump again
        Invoke("ResetCooldown", cooldownDuration);
    }

    private void ResetCooldown()
    {
        // Allow the character to super jump again after cooldown
        currentSuperJumpTime = 0f;
    }
}
