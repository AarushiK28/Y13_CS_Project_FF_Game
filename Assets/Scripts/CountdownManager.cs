using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownManager : MonoBehaviour
{
    public float countdownDuration = 3f; // Set the countdown duration to 3 in seconds
    private bool isCountingDown = false; // Countdown has not started

    public GameObject CountDown; // Declare a public gamobject CountDown
    public AudioSource threeSound; // Declare a variable to hold the audio source for text '3'
    public AudioSource twoSound; // Declare a variable to hold the audio source for text '2'
    public AudioSource oneSound; // Declare a variable to hold the audio source for text '1'
    public AudioSource readySound; // Declare a variable to hold the audio source for text 'GO!'

    // Start is called before the first frame update
    private void Start()
    {
       StartCountdown();
       StartCoroutine(CountDownRoutine()); // Start the coroutine when the game starts
    }

    // Update is called once per frame
    private void Update()
    {
        if (isCountingDown) // Checks if the countdown has started
        {
            countdownDuration -= Time.deltaTime; // Decrease countdown duration by the time passed since last frame

            if (countdownDuration <= 0) // Check if countdown has finished 
            {
                LoadNextScene(); // load the next scene when the countdown ends
            }
        }    
    }

    private void StartCountdown()
    {        
        isCountingDown = true; // Set the game to be paused at start
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(2); // Load scene with index 2 (level 1 scene)
        
    }

    IEnumerator CountDownRoutine()
    {
        yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds
        CountDown.GetComponent<Text>().text = "3"; //Set countdown text to '3'
        threeSound.Play(); // Play the corresponding sound
        CountDown.SetActive(true); // Activate the countdown panel

        yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds
        CountDown.SetActive(false); // Disable the panel after 0.5 seconds
        CountDown.GetComponent<Text>().text = "2"; //Set countdown text to '2' 
        twoSound.Play(); // Play the corresponding sound
        CountDown.SetActive(true); // Activate the countdown panel

        yield return new WaitForSeconds(0.7f); // Wait for 0.7 seconds
        CountDown.SetActive(false); // Disable the panel after 0.7 seconds
        CountDown.GetComponent<Text>().text = "1"; //Set countdown text to '1'
        oneSound.Play(); // Play the corresponding sound
        CountDown.SetActive(true); // Activate the countdown panel

        yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds
        CountDown.SetActive(false); // Disable the panel after 0.5 seconds
        CountDown.GetComponent<Text>().text = "GO!"; //Set countdown text to 'GO!'
        readySound.Play(); // Play the corresponding sound
        CountDown.SetActive(true); // Activate the countdown panel
    }
}

