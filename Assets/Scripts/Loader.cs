using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{

    private ShipControl shipControl;

    void Start()
    {
        shipControl = GameObject.Find("ShipAvalancheBigOld").GetComponent<ShipControl>();
        if (shipControl == null)
        {
            Debug.LogWarning("<color=maroon>ShipControl not found </color>");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (shipControl != null && other.gameObject.tag == "Junk")
        {
            shipControl.junks.Remove(other.gameObject);
            //Debug.Log("Rmoved junk from ShipControl's junks list");
        }
    }
}
