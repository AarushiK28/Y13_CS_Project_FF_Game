using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawning : MonoBehaviour
{
    public GameObject[] externalCars; // Declares a public GameObject to hold externalCars prefab

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(SpawnCars()); // Starts SpawnCars coroutine when the game begins
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Cars()
    {
        int rand = Random.Range(0, externalCars.Length); // Generate a random index from the array
        float randXPos = Random.Range(-2.02f, 1.78f); // Generate a random x position within this range

        // Spawn the first car stored in the array at the current transform position with no rotation
        Instantiate(externalCars[rand], new Vector3(randXPos, transform.position.y, transform.position.z),Quaternion.identity); 

    }
    IEnumerator SpawnCars() // Coroutine to contiuously spawn cars
    {
        while(true) // Creates an infinite loop to contiuously spawn cars
        {
            yield return new WaitForSeconds(2); // Waits for 2 seconds before spawning the next car
            Cars(); // Calls the Cars method to instantiate a new car prefab
        }
        
    }
}



