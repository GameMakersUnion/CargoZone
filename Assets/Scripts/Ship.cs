using UnityEngine;
using System.Collections;

public class Ship : Damagable {

    private const float FORWARD_FORCE = 75;
    private const float BACKWARD_FORCE = 50;
    private const float ROTATION = 100;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 forward = new Vector2(-Mathf.Sin(transform.localEulerAngles.z*Mathf.PI/180),Mathf.Cos(transform.localEulerAngles.z*Mathf.PI/180));
        
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(forward * FORWARD_FORCE * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().AddForce(-forward * BACKWARD_FORCE * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, ROTATION * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -ROTATION * Time.deltaTime);
        }
	}
}
