using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;



public class CameraMovement : MonoBehaviour{

	public float MouseSensitivity = 0.5f;
	public Transform Player;
	public GameObject heldItem;

	public Transform defaultLocation;

	private Vector3 velocity = Vector3.zero;
	public float returnStrength;

	
	
	float mouseX = 0f;
	float mouseY = 0f;
	
	private float prevMouseX = 0f;
	private float prevMouseY = 0f;
	
	private void Start() {
		Cursor.lockState = CursorLockMode.Locked;
		heldItem.transform.position = defaultLocation.position;
	}

	private void Update() {
		mouseX += Input.GetAxis("Mouse X") * MouseSensitivity;
		mouseY -= Input.GetAxis("Mouse Y") * MouseSensitivity;

		heldItem.transform.position -= transform.right * Time.deltaTime * (mouseX - prevMouseX);
		heldItem.transform.position += transform.up * Time.deltaTime * (mouseY - prevMouseY);
		
		//todo: add limit to distance item can travel on the screen
		
		heldItem.transform.position = Vector3.Lerp(heldItem.transform.position,
				defaultLocation.position, returnStrength * Time.deltaTime);

		transform.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
		Player.rotation = Quaternion.Euler(0f, mouseX, 0f);

		prevMouseX = mouseX;
		prevMouseY = mouseY;
	}

}
 