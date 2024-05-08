using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeMovement : MonoBehaviour
{
    public Transform transform;
    public float coneSpeed = 5f;
  

    
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, coneSpeed * Time.deltaTime, 0);

      if(transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
        
    }

    
}

