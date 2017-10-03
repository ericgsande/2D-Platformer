using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController0 : MonoBehaviour {

	/*	
	 *	player controller script for Level0_Movement
	 *		-only supports basic, horizontal movement
	 * 
	 */

    //declare global vars
    public float moveSpeed;             //speed of player movement
    public GameObject doorClosed;       //closed door sprite
    public GameObject doorOpen;         //open door sprite
    //private bool keyStatus = false;     //has the key been picked up?

    //declare player characteristics
    Rigidbody2D myRB; //RigidBody for physics

	private void Start()
    {

        //init player characteristics
        myRB = GetComponent<Rigidbody2D>(); //RigidBody

	}
	
	private void Update()
    {

        //get horizontal speed and apply to player with global var
        float move = Input.GetAxis("Horizontal");
        myRB.velocity = new Vector2(move * moveSpeed, myRB.velocity.y);

	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        /* Compare tag of collided object
         * 
         *  Key: destory key, open door
         *  DoorOpen: load next level
         * 
         */
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            doorClosed.SetActive(false);    //hack, hide closed door
            doorOpen.SetActive(true);       //hack, show open door
            //keyStatus = true;
        }
        else if (other.gameObject.CompareTag("DoorOpen"))// && keyStatus)
        {
            SceneManager.LoadScene("Level1_Jump");
        }

    }

}
