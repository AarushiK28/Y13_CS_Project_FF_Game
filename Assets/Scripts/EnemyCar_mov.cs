using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car1Move : MonoBehaviour
{
  public Transform transform; // Holds the car's transform component
  public float enemyCarSpeed; // Holds the speed at which enemy cars move
    
    // Start is called before the first frame update
    void Start()
    {
      // Initialise 'transform' by getting the Transform component attached to the enemy car this script is attached to
      transform = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
      // Update the car's position on every frame, moving it downward based on 'enemyCarSpeed' and time elapsed
      transform.position -= new Vector3(0, enemyCarSpeed * Time.deltaTime, 0);

      if(transform.position.y <= -10) // Check if the enemy car's y-position is less than or equal to -10
        {
            Destroy(gameObject); // Destroy the enemy car when it's y-position reaches or goes below -10
        }

    }
}
