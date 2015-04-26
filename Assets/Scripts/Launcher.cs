using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {

    private Cannon cannon;
    private GameObject launchHere;
    private GameObject ship;

    // Use this for initialization
    void Start () {
        cannon = GameObject.Find("ShipAvalancheBigOld").GetComponent<Cannon>();
        if (cannon == null)
        {
            Debug.LogWarning("<color=maroon>Cannon not found </color>");
        }

        ship = GameObject.Find("ShipAvalanche");
        launchHere = ship.transform.Find("LaunchHere").gameObject;

    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerExit2D(Collider2D other)
    {
        //if (cannon != null && other.gameObject.tag == "Junk")
        {
            //other.GetComponent<Rigidbody2D>().velocity.Normalize();
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(ship.transform.up.x, ship.transform.up.y) * 10f;
            //other.GetComponent<Rigidbody2D>().AddForce(new Vector2(ship.transform.up.x, ship.transform.up.y) );

            other.transform.position = launchHere.transform.position;
            Debug.Log(ship.transform.up + " TELEPORTED");
        }

    }
}
