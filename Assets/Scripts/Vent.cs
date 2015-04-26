using UnityEngine;
using System.Collections;

public class Vent : MonoBehaviour {

    private GameObject ship;
    private GameObject junkTop;
    private GameObject vent;
    private string aVent;

    // Use this for initialization
    void Start () {
        ship = GameObject.Find("ShipAvalanche");
        if (ship == null)
        {
            Debug.LogWarning("<color=maroon>Ship not found </color>");
        }

        junkTop = GameObject.Find("JunkUni");
        if (junkTop == null)
        {
            Debug.LogWarning("<color=maroon>Top level JunkUni item not found </color>");
        }

        aVent = this.name;
        vent = ship.transform.Find("Sides").Find(aVent).gameObject;
        if (vent == null)
        {
            Debug.LogWarning("<color=maroon>"+ aVent + " not found </color>");
        }


    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerExit2D(Collider2D other)
    {
        const float forceOutside = 5f;
        //if (ShipControl != null && other.gameObject.tag == "Junk")
        {
            //calc vect away!

            Debug.Log("VEL: " + other.GetComponent<Rigidbody2D>().velocity);
            int ventNum = int.Parse(aVent.Substring(aVent.Length - 1));
            int ventSide = (ventNum % 2 == 0) ? -1 : 1;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(ventSide * ship.transform.right.x * forceOutside, ship.transform.up.y) ;
            //Debug.Log( other.name +  " TELEPORTED");

            //change properties to be on different layers.
            Util.TransferJunk(other.gameObject, vent, "Default", 0, junkTop);

            other.gameObject.AddComponent<Drag>();

        }

    }

}
