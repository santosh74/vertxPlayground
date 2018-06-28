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

        Debug.Log("OnTriggerEnter");
        if (other.gameObject.tag == "EditorOnly")
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }
}
