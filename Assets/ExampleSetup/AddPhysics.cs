using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPhysics : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void NodeLink_Loaded()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "EditorOnly")
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }

    void OnGrabbed(string name)
    {
        Debug.Log("OnGrabbed : " + name);

        Player.grabbedList.Add(name);
    }

    void OnDropped(string name)
    {
        Debug.Log("OnDropped:  " + name);
        Player.grabbedList.Remove(name);
    }
}
