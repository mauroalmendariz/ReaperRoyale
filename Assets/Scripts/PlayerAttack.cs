using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerAttack : MonoBehaviour
{
    public GameObject pumpkinGrenade;

    private GameObject target;

    private void Start()
    {
        target = transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            target.SetActive(true);
        }
        else if (Input.GetKeyUp("space"))
        {
            Vector2 launchDirection = target.transform.position - transform.position;
            luanchPumpkinGrenaded(launchDirection);
            target.SetActive(false);
        }
    }

    private void luanchPumpkinGrenaded(Vector2 launchDirection)
    {
        pumpkinGrenade.GetComponent<PumpkinGrenadeDynamic>().launchDirection = launchDirection;
        Instantiate(pumpkinGrenade, transform.position, Quaternion.identity);
    }
}
