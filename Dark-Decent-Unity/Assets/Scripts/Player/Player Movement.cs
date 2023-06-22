using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	[Header("Flags")]
	public bool CanMove = true;

	[Header("Movement")]
	public Rigidbody rb;
	public Transform facing;

	public float speed;

	private void Start() {

		rb.freezeRotation = true;

	}	

	private void FixedUpdate() {

		if(CanMove)
			MovePlayer();

	}

	private void MovePlayer() {

		float movementX = Input.GetAxis("Horizontal");
		float movementY = Input.GetAxis("Vertical");

		Vector3 force = movementX * facing.right * Time.fixedTime + 
			movementY * facing.forward * Time.fixedTime;

		Vector3 velocityXZ = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

		if(velocityXZ.magnitude > speed) {
			
			Vector3 limitedVel = velocityXZ.normalized * speed;
			rb.velocity = new Vector3(limitedVel.x, velocityXZ.y, limitedVel.z);

		} else {

			rb.AddForce(speed * force.normalized, ForceMode.Force);

		}

	}

}
