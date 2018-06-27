using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class Player : MonoBehaviour {

    public float movementSpeed = 10;

    private bool isGrabbed = false;

    private GameObject tempParent = null;

    private GameObject chosenObject;

    private Transform parent;

    // Use this for initialization
    IEnumerator Start()
    {

       yield return new WaitForSeconds(5);

       NodeLink[] vertxObj=  FindObjectsOfType<NodeLink>();

        foreach (NodeLink nodelink in vertxObj)
        {
            Debug.Log("Name : " + nodelink.name + "GUID : "  +nodelink.Guid);
        }

       
    }

    // Update is called once per frame
    void Update()
    {

       // Debug.Log(isGrabbed);
      
        if(isGrabbed)
        {
            chosenObject.transform.position = transform.position;
        }
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
        else if (Input.GetAxis("Horizontal") > 0.5)
        {
            // Left arrow
            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetAxis("Horizontal") < -0.5)
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
        else if (Input.GetButtonDown("B"))
        {
            Debug.Log("B button has been pressed!");

            DropObject();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision : " + other.gameObject.tag);

        chosenObject = other.gameObject.FindNodeLink();
    }



    private void OnTriggerExit(Collider other)
    {
        //chosenObject = null;
    }

    void PickupObject()
    {
       
        parent = chosenObject.transform.parent;
        isGrabbed = true;
        chosenObject.transform.parent = transform;

    }

    void DropObject()
    {
        isGrabbed = false;
        //chosenObject.transform.parent = null;
        //chosenObject.transform = transform;
        chosenObject.transform.parent = parent;
        //chosenObject.transform.
    }
}
