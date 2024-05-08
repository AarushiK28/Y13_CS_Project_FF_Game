using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeSpawner : MonoBehaviour
{
    public GameObject conePrefab; // Declare a public GameObject to hold the cone prefab

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ConeSpawning());  // Start the 'ConeSpawning' coroutine when the game starts
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ConeSpawn()
    {
        float rand = Random.Range(-2.02f, 1.78f); // Generate a random float value within the given range to spawn a cone

        // Spawn a cone prefab at a random x position, and current y and z positions
        Instantiate(conePrefab,new Vector3(rand, transform.position.y, transform.position.z), Quaternion.identity);
    }

    IEnumerator ConeSpawning()
    {
        while(true) // Infinite loop to keep spawning cones
        {
            int time = Random.Range(5, 10); // Spawn a traffic cone within a random time of 5 to 10 seconds
            yield return new WaitForSeconds(time); // Wait for 'time' seconds before spawning the next cone
            ConeSpawn(); // Call this method to instantiate a new cone prefab in the scene
        }
    }
}

