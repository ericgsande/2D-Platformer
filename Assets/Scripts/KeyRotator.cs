using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotator : MonoBehaviour {

    //declare public vars
    public float rotSpeed;

	void Start()
    {
		
	}
	
	void Update()
    {
        //rotate Key along Y axis by public var
        transform.Rotate(0f, rotSpeed, 0f);
	}
}
