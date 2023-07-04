using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemAttach : MonoBehaviour{

    public GameObject targetObject;
    public float followSpeed;
    private Vector3 velocity = Vector3.zero;
    
    

    // Update is called once per frame
    void Update(){
        targetObject.transform.position =
            Vector3.SmoothDamp(targetObject.transform.position,
            transform.position, ref velocity, followSpeed * Time.deltaTime);
        

    }
}
