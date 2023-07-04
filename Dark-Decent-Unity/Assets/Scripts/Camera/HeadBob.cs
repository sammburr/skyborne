using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//https://www.youtube.com/watch?v=5MbR2qJK8Tc
public class HeadBob : MonoBehaviour{
    
    [Header("Settings")]
    public bool enable = true;
    public float amplitude;
    public float frequency;
    public float runningAmplitude;
    public float runningFrequency;

    [Header("Transforms n shit")]
    public Transform cameraObject;
    public Transform cameraHolder;
    public GameObject player;
    private Rigidbody playerRigidBody;

    private float toggleSpeed = 0.01f;
    private Vector3 startPos;


    private void Awake(){
        startPos = cameraObject.localPosition;
        playerRigidBody = player.GetComponent<Rigidbody>();
    }

    
    private Vector3 FootStepMotion(){
        if (player.GetComponent<PlayerMovement>().running == false) {
            Vector3 pos = Vector3.zero;
            Debug.Log(Mathf.Sin(Time.time * frequency) * amplitude);
            pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
            pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude * 2;
            return pos;
        } else {
            Vector3 pos = Vector3.zero;
            pos.y += Mathf.Sin(Time.time * runningFrequency) * runningAmplitude;
            pos.x += Mathf.Cos(Time.time * runningFrequency / 2) * runningAmplitude * 2;
            return pos;
        }
    }

    private void PlayMotion(Vector3 motion){
        cameraObject.localPosition += motion;
    }
    private void CheckMotion(){
        float speed = new Vector3(playerRigidBody.velocity.x, 0, playerRigidBody.velocity.z).magnitude;

        if (speed < toggleSpeed) return;
        // if (rigidBody is grounded) return;
        
        PlayMotion(FootStepMotion());
    }

    private void ResetPosition(){
        if (cameraObject.localPosition == startPos) return;
        cameraObject.localPosition = Vector3.Lerp(cameraObject.localPosition, startPos, 0.1f);
    }

    private Vector3 FocusTarget(){
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + cameraHolder.localPosition.y,
            transform.position.z);
        pos += cameraHolder.forward * 15f;
        return pos;
        
    }
    
    void Update()
    {
        if (enable) {
            CheckMotion();
            ResetPosition();
            cameraObject.LookAt(FocusTarget());
        }
    }


}
