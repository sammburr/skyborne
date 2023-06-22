using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	public float MouseSensitivity = 0.5f;
	public Transform Player;

	private void Start() {

		Cursor.lockState = CursorLockMode.Locked;

	}

	float mouseX = 0f;
	float mouseY = 0f;

	private void Update() {

		mouseX += Input.GetAxis("Mouse X") * MouseSensitivity;
		mouseY -= Input.GetAxis("Mouse Y") * MouseSensitivity;

		transform.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
		Player.rotation = Quaternion.Euler(0f, mouseX, 0f);

	}

}
