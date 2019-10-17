using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovement : MonoBehaviour
{
    // Gets the keys from the player input.
    public PlayerInput myPlayerInput;
    public int reWiredId = 0;
    public float speed = 1.0f;
    // Player's input keys.
    private string up;
    private string down;
    private string left;
    private string right;
    // Rewired object.
    private Player player;

    // Awake is called as soon as the object is created.
    private void Awake()
    {
        player = ReInput.players.GetPlayer(reWiredId);
    }

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
        GetInput();
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
    // ReWired get input.
    void GetInput()
    {
        Vector3 tempPosition = transform.position;
        float xMove = player.GetAxis("MoveHorizontal");
        float yMove = player.GetAxis("MoveVertical");
        if(xMove != 0.0f)
        {
            print("ReWired Joystick " + reWiredId + " - Horizontal");
            tempPosition.x += xMove * speed * Time.deltaTime;
        }
        if(xMove != 0.0f)
        {
            print("ReWired Joystick " + reWiredId + " - Vertical");
            tempPosition.y += yMove * speed * Time.deltaTime;
        }
        transform.position = tempPosition;
    }
}
