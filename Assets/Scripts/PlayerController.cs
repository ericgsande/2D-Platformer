using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //declare global variables
    public float moveSpeed; //speed of player movement

    //declare player characteristics
    Rigidbody2D myRB; //RigidBody for physics

	private void Start()
    {

        //init player characteristics
        myRB = GetComponent<Rigidbody2D>(); //RigidBody

	}
	
	private void Update()
    {

        //get horizontal speed and apply to player
        float move = Input.GetAxis("Horizontal");
        myRB.velocity = new Vector2(move * moveSpeed, myRB.velocity.y);

	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        /* Compare tag of collided object
         * 
         *  Key: destory key, open door
         * 
         */
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            //open door, allow player to complete level
        }

    }

}
