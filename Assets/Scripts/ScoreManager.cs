using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Declare a public integer variable 'score' and initialising it with 0

    public Text scoreText; // Declare a public Text variable to display the score on the UI

    public int highScore; // Declare a public integer variable to store the high score value
    
    public Text highScoreText; // Declare a public Text variable to display the highscore on the UI


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Score()); // Starting the coroutine

        highScore = PlayerPrefs.GetInt("high_score",0); // Retrieving the high score value from "high_score" and initialise the value to 0 if played for the first time
        highScoreText.text = "HighScore: " + highScore.ToString(); // Update 'highScoreText' with the retrieved value stored in 'high_score'
        
    }

     // Update is called once per frame
    void Update()
    {
       scoreText.text = score.ToString(); // Update the UI text element with the current score value each frame and conver the score value to string

       if(score > highScore) // Checks if current score is greater than the high score stored
       {
        highScore = score; // Update the score if true
        PlayerPrefs.SetInt("high_score", highScore); // Storing the new highscore for future reference
        Debug.Log("High score is: " + highScore); // Print the new updated highscore to console
       }     

    }

    
    IEnumerator Score() // Declaring a method named 'Score'
    {
        while(true) // An infinite loop to continuously update the score
        {
           yield return new WaitForSeconds(0.9f); // Pausing the execution for 0.9 seconds before next iteration
           score = score + 1; // Increment score by 1 in each iteration
                 
        }

    }  


}

