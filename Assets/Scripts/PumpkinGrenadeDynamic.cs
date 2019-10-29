using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinGrenadeDynamic : MonoBehaviour
{
    public float launchForce;

    [HideInInspector]
    public Vector2 launchDirection;

    private Rigidbody2D rigBody;

    private void OnEnable()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 force = launchDirection * launchForce;

        rigBody.AddForce(force);
    }
}
