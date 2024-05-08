using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMove : MonoBehaviour
{
    public Renderer meshRenderer; // declares a public variable of type Renderer named "meshRenderer"
    public float trackSpeed = 0.5f; // this variable controls the speed at which the track on the mesh moves
    public AudioSource backgroundSound; // Declares a public variable to hold the background audio source

    // Start is called before the first frame update
    void Start()
    {
      backgroundSound.Play(); // Play the background sound effect when the game starts
    }

    // Update is called once per frame
    void Update()
    {
      // This ensures smooth vertical animation regardless of frame rate 
      meshRenderer.material.mainTextureOffset += new Vector2(0, trackSpeed * Time.deltaTime);    
    }

}


