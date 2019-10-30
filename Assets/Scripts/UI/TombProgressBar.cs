using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombProgressBar : MonoBehaviour
{
    public TombPlayerDetector myTomb;
    public int fullHealth;
    public float defaultScale;
    private float newScale;
    private Vector3 tempScale;
    // Start is called before the first frame update
    void Start()
    {
        fullHealth = myTomb.tombHealth;
        defaultScale = this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        tempScale = this.transform.localScale;
        newScale = defaultScale * ((float)myTomb.tombHealth / (float)fullHealth);
        tempScale.x = newScale;
        this.transform.localScale = tempScale;
    }
}
