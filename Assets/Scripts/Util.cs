using UnityEngine;
using System.Collections;

public class Util : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static GameObject TransferJunk(GameObject what, GameObject where, string layer, int order, GameObject papa)
    {
        what.transform.position = where.transform.position;
        what.gameObject.layer = LayerMask.NameToLayer(layer);
        what.GetComponent<SpriteRenderer>().sortingOrder = order;
        what.transform.parent = papa.transform;
        return what;
    }
}
