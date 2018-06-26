using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaygroundController : MonoBehaviour {

    public float movementSpeed = 10;
    // Use this for initialization
    public GameObject hand;
    public float damping = 1;
    Vector3 offset;

    void Start () {

        offset = hand.transform.position - transform.position;

    }
	

    private void LateUpdate()
    {

        Quaternion rotation = Quaternion.Euler(0, hand.transform.eulerAngles.y, 0);
        transform.position = hand.transform.position - (rotation * offset);

        transform.LookAt(hand.transform);
    }


}
