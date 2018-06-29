using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class Player : MonoBehaviour {

    public float movementSpeed = 10;
    private GameObject chosenObject;
    
    private bool isGrabbed = false;

    private Transform parent;

    public static List<string> grabbedList;

    // Use this for initialization

    private void Start()
    {
        grabbedList = new List<string>();
    }
    /*IEnumerator Start()
    {

       yield return new WaitForSeconds(5);

       NodeLink[] vertxObj=  FindObjectsOfType<NodeLink>();
        foreach (NodeLink nodelink in vertxObj)
        {
            Debug.Log("Name : " + nodelink.name + "GUID : "  +nodelink.Guid);

            //nodelink.AddComponent<Rigidbody>();
        }
    }*/

    // Update is called once per frame
    void Update()
    {
 
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
            transform.Translate(-transform.right * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetAxis("Horizontal") < -0.5)
        {
            // right
            transform.Translate(transform.right * Time.deltaTime * movementSpeed);
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
            transform.Translate(-transform.forward * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetAxis("LeftVertical") < -0.5)
        {
            // backward
            transform.Translate(transform.forward * Time.deltaTime * movementSpeed);
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

        if (chosenObject != null && targetObject != null)
        {
            chosenObject.transform.position = targetObject.transform.position;
            chosenObject.transform.rotation = targetObject.transform.rotation;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision : " + other.gameObject.tag);

        if (canBeGrabbed(other))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (canBeGrabbed(other))
        {
            chosenObject = other.gameObject.FindNodeLink();
            Debug.Log("OnTriggerStay => " + other.gameObject.tag);
            if(other.gameObject.GetComponent<NodeLink>() != null)
            {
                //chosenObject = other.gameObject.FindNodeLink();
            }
            
        }
    }


    private bool canBeGrabbed(Collider other)
    {
        return !(other.gameObject.CompareTag("EditorOnly") || other.gameObject.CompareTag("warehouse") || other.gameObject.CompareTag("wall"));

    }

    private void OnTriggerExit(Collider other)
    {
        //chosenObject = null;
        if (canBeGrabbed(other))
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
           
    }

    GameObject targetObject = null;

    void PickupObject()
    {

        if(chosenObject != null)
        {
            if (targetObject != null)
            {
                Destroy(targetObject);
                targetObject = null;
            }
            // check if chosenObject exists in the grabbed list
            if(grabbedList.Contains(chosenObject.name))
            {
                return;
            }
           GameObject newTarget = new GameObject("newTarget");
            targetObject = newTarget;
            targetObject.transform.parent = gameObject.transform;
            targetObject.transform.position = chosenObject.transform.position;

            GetComponent<Renderer>().material.color = Color.red;
            isGrabbed = true;
            chosenObject.GetComponent<Rigidbody>().isKinematic = false;
            chosenObject.GetComponent<Rigidbody>().useGravity = false;

            // send message to all vertx object
            chosenObject.GetComponent<NodeLink>().Fire("OnMessageReceive", chosenObject.name);
        }

    }

    void DropObject()
    {
        Debug.Log("DRop object::");
        isGrabbed = false;
        GetComponent<Renderer>().material.color = Color.white;
        chosenObject.GetComponent<Rigidbody>().useGravity = true;
        // send message to all vertx object
        chosenObject.GetComponent<NodeLink>().Fire("OnMessageReceive", chosenObject.name);
        //chosenObject.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(targetObject);
        targetObject = null;
        chosenObject = null;
        

    }
}
