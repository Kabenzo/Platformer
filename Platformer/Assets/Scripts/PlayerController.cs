using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	Rigidbody2D rbody;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool isGrounded;

	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		
	}


	void Update () {

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (Mathf.Abs(Input.GetAxisRaw ("Horizontal")) != 0f) {
			rbody.velocity = new Vector3 (moveSpeed * Input.GetAxis ("Horizontal"), rbody.velocity.y, 0f);

		} else {

			rbody.velocity = new Vector3 (0f, rbody.velocity.y, 0f);
		}
			

		if (Input.GetButtonDown ("Jump") && isGrounded) {

			rbody.velocity = new Vector3 (rbody.velocity.x, jumpSpeed, 0f);
		}






	
	}


}
