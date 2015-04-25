using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
    This class is aware of both the Loader and Launcher as a set.
    Loader items are ready for firing, and receive acceleration forces.
    Launcher items are immediately transported with their velocities.
  
 **/

public class Cannon : MonoBehaviour
{

    private Transform junkHold;
    public List<GameObject> junks;
    private float forceFactorMult = 5f;

	// Use this for initialization
	void Start ()
	{
        junkHold = this.transform.Find("Loader").Find("Junk");
	    if (junkHold == null)
	    {
	        Debug.LogWarning("<color=maroon>Yo dingus! The Hold is missing the Junk empty game object!</color>");
	    }
	    else
	    {
            ReadJunk();
	        launch();
	    }
    }

    // Update is called once per frame
    void Update () {
	    
	}

    //Launch applies force to items in Loader bay.
    void launch()
    {
        foreach (GameObject junk in junks)
        {
            Rigidbody2D rb = junk.GetComponent<Rigidbody2D>();
            rb.velocity += Vector2.up; // * forceFactorMult;
        }
        ReadJunk();
    }

    private void ReadJunk()
    {
        //reset
        junks = new List<GameObject>();
        foreach (Transform child in junkHold)
        {
            if (child.tag == "Junk")
            {
                junks.Add(child.gameObject);
            }
        }
    }
}
