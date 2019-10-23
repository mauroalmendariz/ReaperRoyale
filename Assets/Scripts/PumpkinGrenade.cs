using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinGrenade : PhysicsObject
{
    public float maxSpeed;

    private GameObject pumpkinGrenade;

    private void Start()
    {
        pumpkinGrenade = GameObject.FindGameObjectWithTag("Grenade");
        velocity.y = maxSpeed;
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = (new Vector2(1, 1)).normalized;

        targetVelocity = move * maxSpeed;
    }
}
