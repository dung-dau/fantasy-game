using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 5f;
	public float jumpSpeed = 8f;
	private float movement = 0f;
	private Rigidbody2D playerRigidBody;
	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	private bool isTouchingGround;
	private Animator anim;

	void Start() {
		playerRigidBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update() {
		isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
		movement = Input.GetAxis("Horizontal");

		if(movement == 0) {
			anim.SetBool("isRunning", false);
		} else {
			anim.SetBool("isRunning", true);
		}

		if(movement > 0f) {
			playerRigidBody.velocity = new Vector2(movement * speed,playerRigidBody.velocity.y);
			transform.localScale = new Vector2(5f,5f);
		} else if(movement < 0f) {
			playerRigidBody.velocity = new Vector2(movement * speed,playerRigidBody.velocity.y);
			transform.localScale = new Vector2(-5f,5f);
		} else {
			playerRigidBody.velocity = new Vector2(0,playerRigidBody.velocity.y);
		}

		if(Input.GetKeyDown(KeyCode.UpArrow) && isTouchingGround) {
			playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpSpeed);
		}

	}
}
