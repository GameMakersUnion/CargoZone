using UnityEngine;
using System.Collections;
//This enemy seeks out the player, no matter how far they are
public class Seeker : MonoBehaviour {
    public GameObject target;

    private const float SPEED = 50f;
    private const float ROTATION = 5f;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            //Apply force to face player
            Vector3 targetDir = target.transform.position - transform.position;
            Vector3 referenceRight = Vector3.Cross(Vector3.up, transform.forward);
            if (Vector2.Angle( transform.up, targetDir) > 10.0f) // More then 10 degrees
            {
                
                float sign = Mathf.Sign(Vector3.Dot(targetDir, referenceRight));
                if(sign > 0f)
                    GetComponent<Rigidbody2D>().AddTorque(-ROTATION * Time.deltaTime);
                else
                    GetComponent<Rigidbody2D>().AddTorque(ROTATION * Time.deltaTime);
                //Debug.Log(Vector2.Angle(transform.up, targetDir));
                //Debug.DrawLine(transform.forward, targetDir, Color.red);


            }
            else if(GetComponent<Rigidbody2D>().angularVelocity != 0)
            {
                //GetComponent<Rigidbody2D>().AddTorque(-GetComponent<Rigidbody2D>().angularVelocity * Time.deltaTime);
                GetComponent<Rigidbody2D>().angularVelocity = 0;
            }else
            {
                //:If too far away
                //Debug.Log(Vector2.Distance(target.transform.position, transform.position));
                if (Vector2.Distance(target.transform.position, transform.position) > 10f)
                {
                    //Apply forward force to towards player
                    GetComponent<Rigidbody2D>().AddForce(targetDir.normalized * SPEED * Time.deltaTime);
                }
            }
            

            //If too close
            //Apply force away from player
        }
    }
}
