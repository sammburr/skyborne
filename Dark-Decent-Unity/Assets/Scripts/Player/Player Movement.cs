using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

//https://www.youtube.com/watch?v=f473C43s8nE
public class PlayerMovement : MonoBehaviour{

	public bool CanMove;
	public float moveSpeed;
	public float maxSpeed;

	private float horizontalInput;
	private float verticalInput;
	private bool shiftInput;

	private float maxStamina = 1000;
	private float staminaLossRate = 5;
	private float staminaGainRate = 3;
	private float stamina;
	
	public Transform orientation;
	
	private Rigidbody rb;




	private void GetInput(){
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
		shiftInput = Input.GetKey(KeyCode.LeftShift);
	}

	private void MovePlayer(){
		float mult = 1;
		if (shiftInput && stamina != 0) {
			mult = 4;
		}



		Vector3 force = horizontalInput * orientation.right * Time.fixedTime + 
		                verticalInput * orientation.forward * Time.fixedTime;

		Vector3 velocityXZ = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
		

		rb.AddForce(force.normalized * moveSpeed * mult, ForceMode.Force);
	}

	private void manageStamina(){
		if (shiftInput) {
			if (stamina > 0 + staminaLossRate) {
				stamina -= staminaLossRate;
			} else {
				stamina = 0;
			} 
		}
		else {
			if (stamina < maxStamina - staminaGainRate) {
				stamina += staminaGainRate;
			} else {
				stamina = maxStamina;
			}
		}
	}

	
	private void Start(){
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		stamina = maxStamina;
	}
	
	private void Update(){
		GetInput();
		manageStamina();
		Debug.Log(stamina);
	}

	private void FixedUpdate(){
		MovePlayer();
	}
}
