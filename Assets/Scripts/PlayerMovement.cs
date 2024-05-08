using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public Transform transform; // Declaring a Transform type variable to hold the car's transform component
   public float carSpeed; // this float variable controls the speed of the player car

   public float rotationSpeed = 10f; // Set the rotation speed to 10f

   public AudioSource crashSound; // Declares a public variable of type Audio Source named crashSound

   public ScoreManager scoreValue; // Declaring a public variable to keep track of the score value in 'ScoreManager' script
   
   Vector3 position; // holds the car's position

   public AudioSource coinSound; // Declares a public variable to hold the audio clip assigned to the audio source

   public GameObject gameOverPanel; // Declares a GameObject to represent the UI panel

   public AudioSource coneSound; // Declares a public variable to hold the audio clip assigned to the audio source
  
  
    // Start is called before the first frame update
    void Start()
    {
      gameOverPanel.SetActive(false); // Disable the panel when the game starts
      Time.timeScale = 1; // Restart the game when the button is clicked
    }
    
    // Update is called once per frame
     void Update()
    {
      Movement(); // This function handles the movement of the car
      Clamp(); // Restrict car position within boundaries
      
    }

    void Movement()
    {
      if (Input.GetKey(KeyCode.RightArrow)) // checking if the right arrow key is pressed
        {
          transform.position += new Vector3(carSpeed * Time.deltaTime, 0, 0); // move the car to the right
          transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -45), rotationSpeed * Time.deltaTime); // Rotate the car to 45 degrees to simulate turning right
        }

        if (Input.GetKey(KeyCode.LeftArrow)) // check if the left arrow key is pressed
        {
          transform.position -= new Vector3(carSpeed * Time.deltaTime, 0, 0); // Move the car to the left
          transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 45), rotationSpeed * Time.deltaTime); // Rotate the car to 45 degrees to simulate turning left
        }

        if (transform.rotation.z != 90) 
        {
          transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotationSpeed * Time.deltaTime); // Gradually reset rotation when neither arrow key is pressed
        }
    }    
      
    void Clamp()
    {
       // Restrict movement of the player car
       Vector3 position = transform.position;
       position.x = Mathf.Clamp(position.x, -2.02f, 1.78f); // Car's x-coordinate is clamped within the coordnates (-2.02, 1.78)
       transform.position = position;
    }

    // Declares a private method that takes a parameter of type 'Collider2D' 
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.tag == "carCollide") // Checks if the game object involved in the collision has the tag 'carCollide'
      {
        crashSound.Play(); // Play the crash sound effect when called
        Time.timeScale = 0; // Pauses the game by setting the time scale to 0
        gameOverPanel.SetActive(true); // Activate the game over panel
        
      }

      if(collision.gameObject.tag == "Coins") // Check if the collided game object is tagged as 'Coins'
      {
        
        scoreValue.score += 5; // Increase the score by 5 when a coin is collected
        Destroy(collision.gameObject); // Destroy the coin after collision with player car
        coinSound.Play(); // Play the coin sound effect when called
      }

      if(collision.gameObject.tag == "Cone") // Check if the collided game object is tagged as 'Cone'
      {
        scoreValue.score -= 3; // Deduct 3 points from the score upon collision with the cone
        Destroy(collision.gameObject); // Destroy the cone after collision with player car
        coneSound.Play(); // Play the sound effect when called

      }

    }
     

}



