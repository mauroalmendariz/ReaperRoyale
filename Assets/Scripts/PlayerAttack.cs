using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerAttack : MonoBehaviour
{
    public GameObject pumpkinGrenade;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(pumpkinGrenade, transform.position, Quaternion.identity);
        }
    }
}
