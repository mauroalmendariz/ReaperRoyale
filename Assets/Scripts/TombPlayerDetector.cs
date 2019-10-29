using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombPlayerDetector : MonoBehaviour
{
    public bool isActive = false;
    public int tombHealth = 100;
    public GameObject activePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive && activePlayer != null)
        {
            tombHealth -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name + " has entered " + this.name + " collider.");
        if(activePlayer == null && collision.tag == "Player")
        {
            SetActivePlayer(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name + " is still in " + this.name + " collider.");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.name + " has exited " + this.name + " collider.");
        if (activePlayer != null && collision.tag == "Player")
        {
            RemoveActivePlayer();
            tombHealth = 100;
        }
    }

    private void SetActivePlayer(Collider2D newActivePlayer)
    {
        activePlayer = newActivePlayer.gameObject;
        Debug.Log(activePlayer.name + " is the new activePlayer for " + this.name);
    }

    private void RemoveActivePlayer()
    {
        activePlayer = null;
        Debug.Log("activePlayer set to null for " + this.name);
    }
}
