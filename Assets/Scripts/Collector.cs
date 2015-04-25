using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour {

    private Hold hold;

	// Use this for initialization
	void Start () {
        //hold = GameObject.Find("ShipBig").GetComponent<Hold>();

        if (hold == null)
        {
            Debug.Log("Hold missing!");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Junk" && hold != null)
        {
            //hold.put(other.gameObject);
        }
    }
}
