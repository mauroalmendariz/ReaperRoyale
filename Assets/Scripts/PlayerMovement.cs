using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Gets the keys from the player input.
    public PlayerInput myPlayerInput;
    public float speed = 1.0f;
    // Player's input keys.
    private string up;
    private string down;
    private string left;
    private string right;
    // Start is called before the first frame update
    void Start()
    {
        if(myPlayerInput == null)
        {
            //TestingKeys();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput360();
    }

    // Sets the keys to player 1.
    void TestingKeys()
    {
        up = "w";
        down = "s";
        left = "a";
        right = "d";
    }
    
    // Gets the keys assigned to the player from the PlayerInput script.
    void GetPlayerInputKeys()
    {
        up = myPlayerInput.playerUp;
        down = myPlayerInput.playerDown;
        left = myPlayerInput.playerLeft;
        right = myPlayerInput.playerRight;
    }

    // Handles the input from the player.
    void CheckInput()
    {
        // Get the current position.
        Vector3 tempPosition = transform.position;

        // Check all the keys.
        if (Input.GetKey(up))
        {
            print(up + " key was pressed.");
            tempPosition.y += speed;
        }
        if (Input.GetKey(down))
        {
            print(down + " key was pressed");
            tempPosition.y -= speed;
        }
        if (Input.GetKey(left))
        {
            print(left + " key was pressed");
            tempPosition.x -= speed;
        }
        if (Input.GetKey(right))
        {
            print(right + " key was pressed");
            tempPosition.x += speed;
        }

        // Assign the new position to the player.
        transform.position = tempPosition;
    }

    // Testing input from Xbox 360 controller.
    void CheckInput360()
    {
        Vector3 tempPosition = transform.position;

        if(Input.GetAxis("Player1_Horizontal") > 0.0f)
        {
            print("Player 1 Right");
            //tempPosition.x += Input.GetAxis("player1_horizontal");
            tempPosition.x += speed;
        }
        else if(Input.GetAxis("Player1_Horizontal") < 0.0f)
        {
            print("Player 1 Left");
            //tempPosition.x += Input.GetAxis("player1_horizontal");
            tempPosition.x -= speed;
        }

        transform.position = tempPosition;
    }
}
