using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryTarget : MonoBehaviour
{
    private Vector2 velocity;
    private Rigidbody2D rigBody;

    private void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Trajectory_Horizontal"), Input.GetAxisRaw("Trajectory_Vertical"));

        velocity = input.normalized * 2;
    }

    private void FixedUpdate()
    {
        rigBody.MovePosition(rigBody.position + velocity * Time.fixedDeltaTime);
    }
}
