using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// the main part of code below this! (above is the library got loaded)
// The name of the "class" must be the same as the object in unity 
// Grey means it is not been used in the script 


public class Player : MonoBehaviour
{

    [SerializeField] // This means although private, you could still interact with it in unity 
    private float _speed = 5f; // by creating variable "speed" you also have access to it in unity (if public, not now that is private!)

    [SerializeField] // you may see it in the Player "inspector"
    private GameObject _vaccinePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        // reset player position at start 
        transform.position = new Vector3(0,0,0); // start state of object in unity in 0,0,0
    }

    // Update is called once per frame
    void Update()
    {
        // calling a method, defined below 
        PlayerMovement();
        
        // if button (space bar) pressed
        // then instantiate vaccine prefab
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space bar Pressed!");
            Instantiate(_vaccinePrefab, transform.position, Quaternion.identity); //Quaternion, we don't care about rotation, just put 0,0,0
            
        }



    }
    
    
    
    

    // player movement function 
    void PlayerMovement()
    {
        
        // read player input on x and y axis 
        float horizontalInput = Input.GetAxis("Horizontal"); // you may access this from documentation in "input manger" / I push button it moves, of course you need to add to the transform 
        float verticalInput = Input.GetAxis("Vertical");
        
        // move horizontally and vertically 
        // apply player movement 
        Vector3 PlayerTranslate = new Vector3(
            1f * horizontalInput * _speed * Time.deltaTime , //moves it one frame to right per frame, it will go on till eternity, Time.deltaTime = moves slower 
            1f * verticalInput * _speed * Time.deltaTime,
            0f);
        
        transform.Translate(PlayerTranslate);
        
        // setting up the vertical boundaries for the player 
        // check if player position is greater than 0 on y-axis 
        if (transform.position.y >0f)
        {
            // keep player y position at 0;
            transform.position = new Vector3(transform.position.x,
                0f,
                0f);
        }
        // check for lower boundary 
        else if (transform.position.y < -4.5f)
        {
            // keep player within the lower boundary 
            transform.position = new Vector3(transform.position.x,
                -4.5f,
                0f);
        }
        
        // setting up the horizontal  boundaries for the player 
        // check if player escaped from right side  
        if (transform.position.x >11.3f)
        {
            // move player to the left side of the screen 
            transform.position = new Vector3(-11.2f,
                transform.position.y, //this is for y to stay the same
                0);
        }
        // check if player escaped from left side 
        else if (transform.position.x < -11.3f)
        {
            // move player to the right side of the screen
            transform.position = new Vector3(11.2f,
                transform.position.y,
                0);
        }
        
    }
    
    
}






































