using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //declare public variables
    public Transform target;

    //declare private variables
    private Vector3 offset;

	void Start()
    {
        //offset is the difference between the target and the camera
        offset = transform.position - target.position;
	}
	
	void Update()
    {
        //set camera position off of target
        transform.position = target.transform.position + offset;
    }
}
