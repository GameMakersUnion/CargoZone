using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{

    private FireControl fireControl;

    void Start()
    {
        fireControl = GameObject.Find("ShipAvalancheBigOld").GetComponent<FireControl>();
        if (fireControl == null)
        {
            Debug.LogWarning("<color=maroon>FireControl not found </color>");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (fireControl != null && other.gameObject.tag == "Junk")
        {
            fireControl.junks.Remove(other.gameObject);
            //Debug.Log("Rmoved junk from FireControl's junks list");
        }
    }
}
