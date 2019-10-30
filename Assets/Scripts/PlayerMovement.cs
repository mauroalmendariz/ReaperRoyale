using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.0f;
    // Player's input keys.
    public PlayerInput myInput;
    private string up;
    private string down;
    private string left;
    private string right;
    private string fire;

    // Awake is called as soon as the object is created.
    private void Awake()
    {
        if (myInput == null)
        {
            myInput = GetComponent<PlayerInput>();
            SetInputFromPlayerInput();
        }
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
    void DefaultKeys()
    {
        up = "w";
        down = "s";
        left = "a";
        right = "d";
    }

    void SetInputFromPlayerInput()
    {
        up = myInput.playerUp;
        down = myInput.playerDown;
        left = myInput.playerLeft;
        right = myInput.playerRight;
        fire = myInput.fire;
    }

    // Handles the input from the player.
    void CheckInput()
    {
        if (Input.GetKey(fire))
            return;

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
}
