using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEmitter : MonoBehaviour{

    public float delay;
    public AudioClip sound;
    
    private float timeSinceLastPlay = 0f;
    

    // Update is called once per frame
    void Update(){
        timeSinceLastPlay += Time.deltaTime;
        if (timeSinceLastPlay > delay) {
            gameObject.GetComponent<AudioSource>().PlayOneShot(sound);
            timeSinceLastPlay = 0f;
        } 
    }
}
