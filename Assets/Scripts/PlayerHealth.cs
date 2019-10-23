using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        if (health == 0.0f)
            health = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
