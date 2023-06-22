using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttach : MonoBehaviour
{

    public Transform AttachTo;	

    [Header("Head Bob")]
    public float Amplitude = 0.015f;
    public float Frequency = 10f;

    void Update()
    {
	transform.position = AttachTo.position;
	transform.position += new Vector3(Mathf.Sin(Time.time * Frequency) * Amplitude, Mathf.Cos(Time.time * Frequency) * Amplitude, 0f);
    }
}
