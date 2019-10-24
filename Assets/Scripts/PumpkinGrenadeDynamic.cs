using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinGrenadeDynamic : MonoBehaviour
{
    public float launchForce;

    private Rigidbody2D rigBody;

    private void OnEnable()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 force = (new Vector2(1, 1)).normalized * launchForce;

        rigBody.AddForce(force);
    }
}
