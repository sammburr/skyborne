using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttach : MonoBehaviour
{

    public Transform attachTo;

    void Update() {
		transform.position = attachTo.position;
    }
}
