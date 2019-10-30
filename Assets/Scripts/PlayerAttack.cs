using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerAttack : MonoBehaviour
{
    private string fireButton;
    public GameObject pumpkinGrenade;

    private GameObject target;

    private void Start()
    {
        // Set my input button if not set by designer.
        if (fireButton == null)
            fireButton = transform.GetComponentInParent<PlayerInput>().fire;

        target = transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(fireButton))
        {
            print(fireButton + " key was pressed");
            target.SetActive(true);
        }
        else if (Input.GetKeyUp(fireButton))
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
