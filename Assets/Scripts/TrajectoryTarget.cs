using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryTarget : MonoBehaviour
{
    private Vector2 velocity;
    private Rigidbody2D rigBody;

    private string up;
    private string down;
    private string left;
    private string right;

    private void Start()
    {
        if (up == null)
            up = GetComponentInParent<PlayerInput>().playerUp;
        if (down == null)
            down = GetComponentInParent<PlayerInput>().playerDown;
        if (left == null)
            left = GetComponentInParent<PlayerInput>().playerLeft;
        if (right == null)
            right = GetComponentInParent<PlayerInput>().playerRight;
        rigBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 input = new Vector2(0, 0);
        if (Input.GetKey(up))
            input = new Vector2(0, 1);
        if (Input.GetKey(down))
            input = new Vector2(0, -1);
        if (Input.GetKey(right))
            input = new Vector2(1, 0);
        if (Input.GetKey(left))
            input = new Vector2(-1, 0);

        velocity = input.normalized * 2;
    }

    private void FixedUpdate()
    {
        rigBody.MovePosition(rigBody.position + velocity * Time.fixedDeltaTime);
    }
}
