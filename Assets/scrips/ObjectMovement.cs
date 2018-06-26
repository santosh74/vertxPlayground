using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class ObjectMovement : MonoBehaviour {

    public float movementSpeed = 10;
    // Use this for initialization
    void Start() {
        Debug.Log("init has been called");
    }

    // Update is called once per frame
    void Update() {
 
       

        // check for up arrow key
        if (Input.GetAxis("Vertical") > 0.5)
        {
            //  up 
            transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetAxis("Vertical") < -0.5)
        {
            // down
            transform.Translate(Vector3.down * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetAxis("Horizontal") < -0.5)
        {
            // Left arrow
            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetAxis("Horizontal") > 0.5)
        {
            // right
            transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetAxis("LeftHorizontal") > 0.5)
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * 60, 0));
        }
        else if (Input.GetAxis("LeftHorizontal") < -0.5)
        {
            transform.Rotate(new Vector3(0, -Time.deltaTime * 60, 0));
        }
        else if (Input.GetAxis("LeftVertical") > 0.5)
        {
            // forward
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetAxis("LeftVertical") < -0.5)
        {
            // backward
            transform.Translate(Vector3.back * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetButtonDown("A"))
        {
            Debug.Log("A button has been pressed!");
            PickupObject();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("collision detected");

        Debug.Log(other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay detected");
    }
    void OnCollisionEnter(Collision col)
    {

        Debug.Log("collision detected");

        Debug.Log(col.gameObject.name);
       
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay detected");
    }

    private void PickupObject()
    {
        
    }
}
