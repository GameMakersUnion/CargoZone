using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Drag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    Rigidbody2D rigid;
    float decelleration;

    void Start()
    {
        decelleration = 1;
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {

        //get pos
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        float speed = Mathf.Sqrt(Mathf.Pow(curPosition.x - transform.position.x, 2) + Mathf.Pow(curPosition.y - transform.position.y, 2));

        //not in hold area
        if (gameObject.layer != 8)
        {
            //make follow mouse directly
            rigid.velocity = (curPosition - transform.position).normalized * speed / Time.deltaTime;

        }
        else
        {
            decelleration /= 2f;
            rigid.velocity = (curPosition - transform.position).normalized * speed / Time.deltaTime * decelleration;
            Debug.Log(rigid.velocity); 
        }
    }
}
