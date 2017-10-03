using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour {

	/*
	 *	player controller cript for Level1_Jump
	 *		-builds from Level0_Movement and adds jumping capabilites
	 *		
	 */

	//declare public global vars
	public float moveSpeed;					//speed of player movement
	public float jumpSpeed;					//speed of player jump
	public GameObject doorClosed;			//closed door sprite
	public GameObject doorOpen;             //open door sprite
	public LayerMask groundLayer;           //layer of ground in scene
	public Transform groundCheck;			//location of ground in scene

	//declare private global vars
	//private bool keyStatus = false;		//has the key been picked up?
	private bool isGrounded = false;		//is the player grounded?

	//declare player characteristics
	Rigidbody2D myRB; //RigidBody for physics

	private void Start()
	{

		//init player characteristics
		myRB = GetComponent<Rigidbody2D>(); //RigidBody

	}

	private void Update()
	{

		//get horizontal speed
		float move = Input.GetAxis("Horizontal");
		myRB.velocity = new Vector2(move * moveSpeed, myRB.velocity.y);

		//add force from jump and update grounded var
		if (isGrounded && Input.GetAxis("Jump") > 0)
		{
			myRB.velocity = new Vector2(myRB.velocity.x, 0f);
			myRB.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
			//Debug.Log("setting jump to false!");
			isGrounded = false;
		}

		//check if ground check obj intersects with ground layer and update grounded var
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);

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
			SceneManager.LoadScene("Level0_Movement");
		}

	}

}
