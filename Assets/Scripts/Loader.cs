using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{

    private Cannon cannon;

    void Start()
    {
        cannon = GameObject.Find("ShipAvalancheBigOld").GetComponent<Cannon>();
        if (cannon == null)
        {
            Debug.LogWarning("<color=maroon>Cannon not found </color>");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (cannon != null && other.gameObject.tag == "Junk")
        {
            cannon.junks.Remove(other.gameObject);
            //Debug.Log("Rmoved junk from Cannon's junks list");
        }
    }
}
