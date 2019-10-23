using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public int reWiredId = 0;
    // Player's input keys.
    public string up;
    public string down;
    public string left;
    public string right;
    // Rewired object.
    private Player player;

    // Awake is called as soon as the object is created.
    private void Awake()
    {
        TestingKeys();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    // Sets the keys to player 1.
    void TestingKeys()
    {
        up = "w";
        down = "s";
        left = "a";
        right = "d";
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
            tempPosition.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(down))
        {
            print(down + " key was pressed");
            tempPosition.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(left))
        {
            print(left + " key was pressed");
            tempPosition.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(right))
        {
            print(right + " key was pressed");
            tempPosition.x += speed * Time.deltaTime;
        }

        // Assign the new position to the player.
        transform.position = tempPosition;
    }
    // ReWired get input.
    void ReWiredInput()
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
