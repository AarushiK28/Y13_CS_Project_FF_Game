using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePanelControl : MonoBehaviour
{
    public Text highScoreText; // Create a public Text variable to refer to high score text UI
    public Text scoreText; // Create a public Text variable to refer to current score text UI
    public int score; // Declares the current score during gameplay
    public int highScore; // Declares the highest score achieved
    public ScoreManager scoreManager; // Declare a public variable 'scoreManager' to get score and highscore values from 'ScoreManager' script

    public GameObject gamePausePanel; // Declare a public GameObject variable to control the pause panel visibility
    public GameObject gamePauseButton; // Declare a public GameObject variable to control the pause button visibility
    public bool IsPaused = false; // Declare a boolean variable and set it to false, so the game is not paused at the start

    // Start is called before the first frame update
    void Start()
    {
        gamePausePanel.SetActive(false); // Set the pause panel to to be inactive when the game starts 
        gamePauseButton.SetActive(true); // Enable the pause button when the game starts
    
    }

    // Update is called once per frame
    void Update()
    {
        
        highScore = PlayerPrefs.GetInt("high_score"); // Retrieve high score value 
        score = scoreManager.score; // Get the score value from 'ScoreManager' script

        highScoreText.text = "HIGH SCORE : " + highScore.ToString(); // Update the Text UI with the current high score value
        scoreText.text = "SCORE : " + score.ToString(); // Update the Text UI with the current score value

        if(Input.GetKeyDown(KeyCode.P)) // Check if 'p' key is pressed 
        {
            IsPaused = true; // Pause the game 
            if(IsPaused)
            {
                PauseGame(); // Call this method if game is paused and display the pause panel
            }
        }

    }

    public void Restart() 
    {
        SceneManager.LoadScene(2); // Load scene with index 2 (Level 1 scene)
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0); // Load scene with index 0 (main menu scene)

    }

    public void PauseGame()
    {
        Time.timeScale = 0; // Pauses the game
        gamePausePanel.SetActive(true); // Activate the pause panel when pause button is pressed
        gamePauseButton.SetActive(false); // Disable the pause button for the user
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // resumes the game with the current score
        gamePausePanel.SetActive(false); // Deactivate the pause panel when game is resumed 
        gamePauseButton.SetActive(true); // Enable the pause button for the user
        IsPaused = false; // Game is no longer paused after clicking on the resume button

    }


}




