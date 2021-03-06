﻿using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {

    private ShipControl shipControl;
    private GameObject smallCannon;
    private GameObject ship;
    private GameObject junkTop;

    // Use this for initialization
    void Start () {
        shipControl = GameObject.Find("ShipAvalancheBigOld").GetComponent<ShipControl>();
        if (shipControl == null)
        {
            Debug.LogWarning("<color=maroon>ShipControl not found </color>");
        }

        ship = GameObject.Find("ShipAvalanche");
        if (ship == null)
        {
            Debug.LogWarning("<color=maroon>Ship not found </color>");
        }


        smallCannon = ship.transform.Find("SmallCannon").gameObject;
        if (smallCannon == null)
        {
            Debug.LogWarning("<color=maroon>SmallCannon not found </color>");
        }

        junkTop = GameObject.Find("JunkUni");
        if (junkTop == null)
        {
            Debug.LogWarning("<color=maroon>Top level JunkUni item not found </color>");
        }

    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerExit2D(Collider2D other)
    {
        const float forceOutside = 10f;
        //if (ShipControl != null && other.gameObject.tag == "Junk")
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(ship.transform.up.x, ship.transform.up.y) * forceOutside;
            //Debug.Log( other.name +  " TELEPORTED");

            //change properties to be on different layers.
            Util.TransferJunk(other.gameObject, smallCannon, "Default", 0, junkTop);

            other.gameObject.AddComponent<Drag>();

        }

    }
}
