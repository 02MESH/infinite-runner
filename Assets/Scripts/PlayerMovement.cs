using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //array for player movement
    public float[] xPos;
    int xPosIndex = 2;
    public float speed = 5f;
    public float floorHeight;
    public float maxSpeed;

    //private Rigidbody rb; //trying to remove this 
    private CharacterController controller;

    //jump variables
    public Vector3 direction;
    public float jumpForce = 10f;
    public float Gravity = -20;
    bool isGrounded = true;

    //player inventory
    private PlayerInventory playerInventory;

    //score variables 
    private float score = 0f;
    //how much score increases each second
    float scoreIncreaseRate = 10f; // Adjust as needed
    private float highScore = 0f;  //highscore

    private Animator animator; //player animator

    public Text scoreText;
    //public Text highScoreText;
    // Start is called before the first frame update

    //audio clips
    public AudioClip jumpSound;
    public AudioClip slideSound;
    public AudioClip deathSound;

    void Start()
    {
        //gets character contorller 
        controller = GetComponent<CharacterController>();
        // rb = GetComponent<Rigidbody>(); //trying to remove this 
        //direction = new Vector3(0.0f, 2.0f, 0.0f);
        //animations 
        animator = GetComponent<Animator>(); 
        // Get the PlayerInventory component when the game starts
        playerInventory = GetComponent<PlayerInventory>();
        playerInventory = PlayerInventory.Instance;
        // loads the coins from the inventory 
        playerInventory.LoadCoins();
        //get highscore from player prefs
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

    // Update is called once per frame
    void Update()
    {
        isGrounded = IsGroundedRaycast();
        //Debug.Log("isGrounded is: " + isGrounded);

        if (controller.isGrounded)
        {
            isGrounded = true;
        }

        if (isGrounded) {
            direction.y = 0f;
            //button to jump
            if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
            //button to slide
            if (Input.GetKeyDown(KeyCode.S)) {
                animator.SetTrigger("slide");
                //plays audio clip 
                AudioSource.PlayClipAtPoint(slideSound, transform.position);
                StartCoroutine(Slide());
            }
        } else {
            // If the player is not grounded, apply gravity
            direction.y += Gravity * Time.deltaTime;
        }
        //button to move left 
        if (Input.GetKeyDown(KeyCode.A)) {
            //calls move left method
            MoveLeft();
        }
        //button to move right
        if (Input.GetKeyDown(KeyCode.D))
        {
            //calls move right method
            MoveRight();
        }
        
        //Debug.Log("isGrounded: " + controller.isGrounded);
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

    bool IsGroundedRaycast()
    {
        float raycastDistance = 0.1f; // Adjust the distance as needed
        Vector3 raycastOrigin = transform.position + Vector3.up * 0.1f; // Offset slightly above the player's position

        if (Physics.Raycast(raycastOrigin, Vector3.down, raycastDistance))
        {
            return true;
        }
        return false;
    }

    private void Jump() {
        //sets  direction of the jump so it goes up in the correct axis
        direction.y = jumpForce;
        //sets animator so animations gets triggered
        animator.SetTrigger("jump");
        //applies the jump sound 
        AudioSource.PlayClipAtPoint(jumpSound, transform.position);
    }
    
    void UpdateScore() {
        // Increase the score over time
        score += Time.deltaTime * scoreIncreaseRate;
        //Debug.Log("Score: " + Mathf.Round(score));
        //updates the score text in the ui so player can see score as they play
        scoreText.text = "Score: " + Mathf.Round(score);
        
        // checks to see if score is higher than the highscore if so it becomes the new highscore 
        if (score > highScore)
        {
            highScore = score;  
        }
        //highScoreText.text = "HighScore: " + Mathf.Round(highScore);
    }

    //saves highscore to player prefs 
    void SaveHighScore()
    {
        // loops through existing top 10 highscores 
        for (int i = 1; i <= 10; i++)
        {
            // retrieves current highscore 
            float existingScore = PlayerPrefs.GetFloat("HighScore" + i, 0f);
            if (highScore > existingScore)
            {
                //if highscore is bigger than existing score it stores the existing score in a temp value and swapped
                float tempScore = existingScore;
                PlayerPrefs.SetFloat("HighScore" + i, highScore);
                highScore = tempScore;
            }
        }
        //saved to player prefs
        PlayerPrefs.Save();
    }

    public void GameOver()
    {
        //play audio clip
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        //call save highscore method
        SaveHighScore();
        //load leaderboard
        SceneManager.LoadScene("Leaderboard");
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

    IEnumerator Slide() {
        float originalHeight = controller.height;
        float reducedHeight = 0.5f;
        
        //reduces height of controller collider(player sliding)
        controller.height = reducedHeight;
        controller.center = new Vector3(controller.center.x, reducedHeight / 2f, controller.center.z);
        
        // amount of time the height of collider is changed 
        yield return new WaitForSeconds(1.3f);
        
        //change back to original height (player standing)
        controller.height = originalHeight;
        controller.center = new Vector3(controller.center.x, originalHeight / 2f, controller.center.z);
    }

    IEnumerator Jumps()
    {
        //animation for jump happens
        animator.SetBool("isJumping", true);
        //lasts a certian amount of time before animation stops
        yield return new WaitForSeconds(1.3f);
        // animations stopped
        animator.SetBool("isJumping", false);
    }
    
    //movement is done through an array of indexes to keep player on the grid in the correct lanes 
    // move left is decremented as its a negative posistion 
    void MoveLeft() {
        xPosIndex--;
        if (xPosIndex < 0) {
            xPosIndex = 0;
        }
    }
    // move right is incremented as its a positive posistion 
    void MoveRight()
    {
        xPosIndex++;
        if (xPosIndex > xPos.Length - 1)
        {
            xPosIndex = xPos.Length - 1;
        }
    }
}