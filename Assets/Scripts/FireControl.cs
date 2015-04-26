using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
    This class is aware of both the Loader and Launcher as a set.
    Loader items are ready for firing, and receive acceleration forces.
    Launcher items are immediately transported with their velocities.
  
 **/

public class FireControl : MonoBehaviour
{

    private Transform junkHold;
    public List<GameObject> junks;
    private List<GameObject> magicJunks; 

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
	        magicJunks = junks;
	    }
    }

    // Update is called once per frame
    void Update () {
	    
	}

    //Launch applies force to items in Loader bay.
    public void Launch()
    {
        float forceInside = 300f;

        foreach (GameObject junk in junks)
        {
            Rigidbody2D rb = junk.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * forceInside);
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

    public void Scoop()
    {
        
    }

    //for debugging purposes
    public void MagicRefill()
    {
        foreach (GameObject junk in magicJunks)
        {
            //from naked instantiation to ship... has side effects
            GameObject newJunk = Util.TransferJunk(junk, this.transform.Find("Loader").gameObject, "ShipBig", 1, junkHold.gameObject);
            GameObject fuck = (GameObject)Instantiate(newJunk, junkHold.position, junkHold.rotation);
            fuck.transform.position = this.transform.Find("Loader").position;
        }

    }
}
