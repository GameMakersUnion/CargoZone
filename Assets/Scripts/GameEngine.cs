using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour
{

    private Camera camera;

    // Use this for initialization
    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(p);

    }
}