﻿using UnityEngine;
using System.Collections;

public class Ship : Damagable {

    private const float FORWARD_FORCE = 600;
    private const float BACKWARD_FORCE = 500;
    private const float ROTATION = 500;
    private const float MAX_HEALTH = 5;

    private Cannon cannon;

    private GameObject cannonObject;

	// Use this for initialization
	void Start () {
        //cannon = GameObject.Find("ShipBig").GetComponent<Cannon>();

        health = MAX_HEALTH;

        cannonObject = GameObject.Find("SmallCannon");
        
        if (cannon == null)
        {
            Debug.Log("Cannon missing!");
        }
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 forward = new Vector2(-Mathf.Sin(transform.localEulerAngles.z*Mathf.PI/180),Mathf.Cos(transform.localEulerAngles.z*Mathf.PI/180));
        //Debug.Log(health);
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
            //transform.Rotate(0, 0, ROTATION * Time.deltaTime);
            GetComponent<Rigidbody2D>().AddTorque(ROTATION * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(0, 0, -ROTATION * Time.deltaTime);
            GetComponent<Rigidbody2D>().AddTorque(-ROTATION * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && cannon != null)
        {
            //cannon.launch();
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        takeDamage();
    }

    void fire(GameObject junk)
    {
        junk.transform.position = cannonObject.transform.position;
    }

}