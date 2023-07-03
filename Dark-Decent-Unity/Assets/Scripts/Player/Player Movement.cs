using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

//https://www.youtube.com/watch?v=f473C43s8nE
public class PlayerMovement : MonoBehaviour{

	public bool CanMove;
	public float moveSpeed;
	public float maxSpeed;
	public bool running;

	private float horizontalInput;
	private float verticalInput;
	private bool shiftInput;

	private float maxStamina = 1000;
	private float staminaLossRate = 0.8f;
	private float staminaGainRate = 0.4f;
	private float stamina;
	
	public Transform orientation;
	//public GameObject staminaSlider;
	//private Slider slider;
	private Rigidbody rb;
	
	private void Start(){
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		stamina = maxStamina;
		//slider = staminaSlider.GetComponent<Slider>();
		running = false;
	}
	
	private void GetInput(){
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
		shiftInput = Input.GetKey(KeyCode.LeftShift);
	}
	private void MovePlayer(){
		float moveMult = 1;
		running = false;
		if (shiftInput && stamina != 0) {
			running = true;
			moveMult = 2;
		}

		Vector3 force = horizontalInput * orientation.right * Time.fixedTime + 
		                verticalInput * orientation.forward * Time.fixedTime;

		Vector3 velocityXZ = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
		

		rb.AddForce(force.normalized * moveSpeed * moveMult, ForceMode.Force);
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

	private void updateSlider(){
		//slider.value = stamina / maxStamina;
	}
	

	
	private void Update(){
		GetInput();
		manageStamina();
		updateSlider();
		Debug.Log(stamina);
	}

	private void FixedUpdate(){
		MovePlayer();
	}
}
