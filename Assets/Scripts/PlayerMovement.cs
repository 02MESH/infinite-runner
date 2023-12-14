using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //array for player movement
    public float[] xPos;
    int xPosIndex = 1;
    public float speed = 5f;
    public float floorHeight;
    public float maxSpeed;

    //private Rigidbody rb; //trying to remove this 
    private CharacterController controller;

    //jump variables
    public Vector3 direction;
    public float jumpForce = 10f;
    public float Gravity = -20;
    //bool isGrounded = true;

    //player inventory
    private PlayerInventory playerInventory;

    //score variables 
    private float score = 0f;
    //how much score increases each second
    float scoreIncreaseRate = 10f; // Adjust as needed
    private float highScore = 0f;

    private Animator animator;

    public Text scoreText;
    public Text highScoreText;
    // Start is called before the first frame update
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // rb = GetComponent<Rigidbody>(); //trying to remove this 
        //direction = new Vector3(0.0f, 2.0f, 0.0f);
        animator = GetComponent<Animator>(); //not initialised properly
        // Get the PlayerInventory component when the game starts
        playerInventory = GetComponent<PlayerInventory>();
        playerInventory = PlayerInventory.Instance;

        playerInventory.LoadCoins();

        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
    }

    //when trigger collision happens
    void OnTriggerEnter(Collider other)
    {
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
            //isGrounded = true;
            animator.SetBool("isJumping", false); //causing error cannot find Animator
        }
    }

    // bool isGrounded() {

    // }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("isGrounded: " + controller.isGrounded);
        direction.y += Gravity * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A)) {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
            Debug.Log("Moving Right");
        }
     // if (controller.isGrounded)
     //   {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(jump * jumpForce, ForceMode.Impulse); //trying to remove this 
            Jump();
            // StartCoroutine(Jumps());
            //isGrounded = false;
        }
       //}
        //else{

        //}
        if (Input.GetKeyDown(KeyCode.S)) {
                    animator.SetTrigger("slide");

            // StartCoroutine(Slide());
        }
        //animator.SetBool("isRunning", xPosIndex != 1);
        //+= transform.forward * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPos[xPosIndex], floorHeight, transform.position.z + 1), Time.deltaTime * speed);
        
        // Move the character using the controller
        controller.Move(direction * Time.deltaTime);
        controller.Move(new Vector3(xPos[xPosIndex] - transform.position.x, 0, 1) * speed * Time.deltaTime);

        // increment speed each second
        if (speed < maxSpeed)
        {
            speed += 0.1f * Time.deltaTime;
        }
        UpdateScore();
    }

    private void Jump() {
        direction.y = jumpForce;
        animator.SetTrigger("jump");
    }
    
    void UpdateScore() {
        // Increase the score over time
        score += Time.deltaTime * scoreIncreaseRate;

        // Optionally, you can display or use the score in other ways
        //Debug.Log("Score: " + Mathf.Round(score));
        scoreText.text = "Score: " + Mathf.Round(score);

        if (score > highScore)
        {
            highScore = score;
            if (highScoreText != null)
            {
                highScoreText.text = "HighScore: " + Mathf.Round(highScore);
            }
        }
    }

    void SaveHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", highScore);
        PlayerPrefs.Save();
    }

    public void GameOver()
    {
        
        SaveHighScore();
        playerInventory.SaveCoins();
        SceneManager.LoadScene("MainMenu");
    }

    public void ApplyScoreMultiplier(float multiplier, float duration)
    {
        StartCoroutine(ScoreMultiplierCoroutine(multiplier, duration));
    }

    // Coroutine to handle the score multiplier effect
    IEnumerator ScoreMultiplierCoroutine(float multiplier, float duration)
    {
        float originalScoreIncreaseRate = scoreIncreaseRate;

        // Multiply the score increase rate by the multiplier
        scoreIncreaseRate *= multiplier;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Reset the score increase rate to its original value
        scoreIncreaseRate = originalScoreIncreaseRate;
    }

    // IEnumerator Slide() {
    //     animator.SetTrigger("slide");
    //     // animator.SetBool("isSliding", true);
    //     // //changes height and center of collider to slide under objects
    //     // controller.center = new Vector3(0, 0.5f, 0);
    //     // controller.height = 0.1f;
    //     // yield return new WaitForSeconds(1.3f);

    //     // //changes back to original height and centre of collider
    //     // controller.center = new Vector3(0, 1f, 0);
    //     // controller.height = 2;
    //     // animator.SetBool("isSliding", false);
    // }

    IEnumerator Jumps()
    {
        animator.SetBool("isJumping", true);
        yield return new WaitForSeconds(1.3f);

        animator.SetBool("isJumping", false);
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