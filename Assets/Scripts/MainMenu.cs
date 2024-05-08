using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame() // Call this method when 'play' button is clicked
    {
        SceneManager.LoadScene(2); // Load scene with index 2 (level 1 scene)
    }


    public void QuitGame() // Call this method when 'Quit' button is clicked
    {
        Application.Quit(); // Exit the game
    }

     public void GoToHowToPlayMenu() // Call this method when 'How to Play' button is clicked
    {
        SceneManager.LoadScene(1); // Load scene with index 1 (How to Play menu scene)
    }

    public void GoToMainMenu() // Call this method when 'Back' button is clicked
    {
        SceneManager.LoadScene(0); // Load scene with index 0 (Main menu scene)
    
    }


    public void LoadCountdownScreen() // Call this method when the 'play' button is clicked.
    {
         SceneManager.LoadScene(4); // Load scene with index 4 (Countdown Screen)
    }


}

