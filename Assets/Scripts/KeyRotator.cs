using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotator : MonoBehaviour {

    public float rotSpeed = 5f;

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        transform.Rotate(0f, rotSpeed, 0f);
	}
}
