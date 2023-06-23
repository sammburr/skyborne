using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttach : MonoBehaviour
{

    public Transform AttachTo;	

    [Header("Head Bob")]
    public float Amplitude = 0.015f;
    public float Frequency = 10f;

    void Update() {
		transform.position = AttachTo.position;
		//ur code sucks new Vector3(Mathf.Sin(Time.time * Frequency) * Amplitude, Mathf.Cos(Time.time * Frequency) * Amplitude, 0f);
		Vector3 displacement = Vector3.zero;
		displacement.y += Mathf.Sin(Time.time * Frequency) * Amplitude;
		displacement.x += Mathf.Cos(Time.time * Frequency / 2) * Amplitude * 2;
	    
	    transform.position += displacement;
    }
}
