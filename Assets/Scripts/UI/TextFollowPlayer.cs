using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFollowPlayer : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject myPlayer;
    public Text myText;
    private Vector3 screenPos;
    // Start is called before the first frame update
    void Start()
    {
        if(gameCamera == null)
        {
            gameCamera = FindObjectOfType<Camera>();
        }
        if (myPlayer == null)
        {
            if (this.gameObject.tag == "Player")
            {
                myPlayer = this.gameObject;
            }
        }
        if(myText == null)
        {
            myText = GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Get the screen position of the player.
        screenPos = gameCamera.WorldToScreenPoint(myPlayer.transform.position);
        // Set the text position to the found position.
        myText.transform.position = screenPos;
    }
}
