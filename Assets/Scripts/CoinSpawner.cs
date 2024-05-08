using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Declare a public GameObject to hold the coin profab

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(CoinSpawning()); // Start the 'CoinSpawning' coroutine when the game starts
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CoinSpawn() 
    {
        float rand = Random.Range(-2.02f, 1.78f); // Generate a random float value within the given range to spawn a coin

        // Spawn a new coin prefab at a random x position, and current y and z positions
        Instantiate(coinPrefab,new Vector3(rand, transform.position.y, transform.position.z), Quaternion.identity);
    }

    IEnumerator CoinSpawning()
    {
        while(true) // Infinite loop to keep spawning coins
        {
            int time = Random.Range(3, 8); // Spawn a coin within a random time of 3 to 8 seconds
            yield return new WaitForSeconds(time); // Wait for 'time' seconds before spawning the next coin
            CoinSpawn(); // Call this method to instantiate a new coin prefab in the scene
        }
    }
}




