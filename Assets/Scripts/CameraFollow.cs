using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float offsetX = 0.0f;
    public float offsetY = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(target != null)
        {
            transform.position = new Vector3(target.position.x+ offsetX, target.position.y+ offsetY, transform.position.z);
        }
	}
}
