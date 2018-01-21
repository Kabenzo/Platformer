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

	public Animator PlayerAnim;

	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		PlayerAnim = GetComponent<Animator> ();

		
	}


	void Update () {

		//Check if Player is on the ground
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		#region Movement and Animations
		//Movement and Animations
		if (Mathf.Abs(Input.GetAxisRaw ("Horizontal")) != 0f) {
			rbody.velocity = new Vector3 (moveSpeed * Input.GetAxisRaw ("Horizontal"), rbody.velocity.y, 0f);

			//Flips Character Towards Direction he is moving in
			if (Input.GetAxisRaw ("Horizontal") == 1f) {
			transform.eulerAngles = new Vector3 (0,0,0);
			}
			else if (Input.GetAxisRaw ("Horizontal") == -1f) {
				transform.eulerAngles = new Vector3 (0,180,0);
			}

			//Sets Walking animation if player is moving and on the ground
			if (isGrounded == true) {
				PlayerAnim.SetBool ("IsWalking", true);
			}

		} else {

			rbody.velocity = new Vector3 (0f, rbody.velocity.y, 0f);
			PlayerAnim.SetBool ("IsWalking", false);
		}

			

		if (Input.GetButtonDown ("Jump") && isGrounded) {
			rbody.velocity = new Vector3 (rbody.velocity.x, jumpSpeed, 0f);
			PlayerAnim.SetBool ("IsWalking", false);

		}

		//Check if Jumping
		if (isGrounded == true) {
			PlayerAnim.SetBool ("IsJumping", false);
		}
		else if (Mathf.Sign (rbody.velocity.y) == 1) {
			PlayerAnim.SetBool ("IsJumping", true);
		}


		//Check if Falling
		 if (Mathf.Sign (rbody.velocity.y) == -1f) {
			PlayerAnim.SetBool ("IsFalling", true);

		} else {
			PlayerAnim.SetBool ("IsFalling", false);

		}


		#endregion 







	
	}


}
